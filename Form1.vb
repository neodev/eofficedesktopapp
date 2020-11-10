﻿Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Reflection
Imports System.ComponentModel

Public Class Form1

    Inherits System.Windows.Forms.Form

    Private _inactiveTimeRetriever As cIdleTimeStool

    'Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As Long, lpdwProcessId As Long) As Long

    'Public Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As Long
    Declare Auto Function SetForegroundWindow Lib "user32.dll" _
    Alias "SetForegroundWindow" (ByVal hWnd As IntPtr) As Integer

    Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As Integer
    Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As Integer) As Integer
    Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
    Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As Long, lpdwProcessId As Long) As Long

    Dim lastscreensaver As Date
    Dim inactstart As Date
    Dim inactend As Date
    Dim inactsec As Integer

    Dim minsec As Integer = 200 'Take screenshort every X seconds irrespctive of winow changed or not

    Dim logincookie As CookieContainer

    Dim systrayalert As Boolean = True

    'Registery values

    Dim startwithos As String
    Dim CurrentVersion As String
    Dim AutoLoginReg As String

    Dim AutoSelProjectReg As String
    Dim LastProjectReg As String
    Dim LastTaskReg As String

    Dim SaveCredentialReg As String
    Dim UsernameReg As String
    Dim PasswordReg As String


    Dim applicationName As String = Application.ProductName
    Dim applicationPath As String = Application.ExecutablePath

    Dim flaglasttask As Boolean = True 'Disable saving selected task
    Dim shorturl As String = "http:///www.brwz.in/"
    Dim islogin As Boolean = False 'flag varibale to restrcit project and task auto selection
    Dim apiurl As String = "http://kenprotechnologies.comx/eofficedesktopapp/api/"
    'Dim apiurl As String = "http://dfwwebexpert/eofficedesktopwebapp/api/"

    Dim sssavepath As String = Application.StartupPath() & "\screengrabs\" '"d:\screengrabs\"

    Dim mysqldateformat As String = "yyyy-MM-dd hh:mm:ss"
    Dim lastactwnw As String

    Dim taskkey As String
    Dim projectkey As String
    Dim SendDataRes As String
    Dim allprocesslist As String
    Dim processlist As Integer()
    Dim intavail As Boolean
    Dim apidown As Boolean = False

    Private Sub scrnsvr_Tick(sender As Object, e As EventArgs) Handles scrnsvr.Tick

        'Dim lastscreensaver = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)

        Dim seconds As Long = DateDiff(DateInterval.Second, lastscreensaver, Now)

        Console.WriteLine(seconds)

        If (seconds > minsec) Then
            ''Dim unused = MsgBox(milliseconds)
            Dim sgfilename As String
            Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
            sgfilename = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds) & ".jpg"
            screenGrab.Save(sssavepath & Now.ToString("MM-dd-yyyy") & "\" & "MS" & sgfilename)
            ''or screenGrab.Save("C:\screenGrab.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            lastscreensaver = Now

        End If

    End Sub


    ' Return the window's title.
    Private Function GetWindowTitle(ByVal window_hwnd As Integer) As String
        ' See how long the window's title is.
        Dim length As Integer
        length = GetWindowTextLength(window_hwnd) + 1
        If length <= 1 Then
            ' There's no title. Use the hWnd.
            Return "<" & window_hwnd & ">"
        Else
            ' Get the title.
            Dim buf As String = Space$(length)
            length = GetWindowText(window_hwnd, buf, length)
            Return buf.Substring(0, length)
        End If
    End Function
    Private m_LastHwnd As Integer
    Private m_LastWndTile As String
    Private Sub tmrGetFgWindow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGetFgWindow.Tick

        Dim wnwtimestamp As String
        ' Get the window's handle.
        Dim fg_hwnd As Long = GetForegroundWindow()
        Dim fg_wndttle As String = GetWindowTitle(fg_hwnd)

        ' If this is the same as the previous foreground window,
        ' let that one remain the most recent entry.
        If m_LastHwnd = fg_hwnd And m_LastWndTile = fg_wndttle Then Exit Sub

        m_LastHwnd = fg_hwnd
        m_LastWndTile = fg_wndttle

        ' Display the time and the window's title.
        Dim list_item As System.Windows.Forms.ListViewItem
        wnwtimestamp = Now.ToString(mysqldateformat)
        list_item = lvwFGWindow.Items.Add(wnwtimestamp)

        list_item.SubItems.Add(fg_hwnd)
        list_item.SubItems.Add(fg_wndttle)
        'Take screenshot if active window is changed
        lastscreensaver = Now
        Dim sgfilename As String
        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)

        Try
            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

        sgfilename = "WC" & CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds) & ".jpg"
        screenGrab.Save(sssavepath & Now.ToString("MM-dd-yyyy") & "\" & sgfilename)

        list_item.SubItems.Add(sgfilename)
        lastactwnw = "awt=" & wnwtimestamp & "&wh=" & fg_hwnd & "&ss=" & sgfilename
        SendDataRes = SendGetData("d=W&" & lastactwnw & "&wt=" & fg_wndttle)
        list_item.SubItems.Add(SendDataRes)
        list_item.EnsureVisible()

        Dim processitem As Dictionary(Of String, String)
        Dim processfound As Boolean = False

        For i = 0 To lstboxhandels.Items.Count - 1

            processitem = ParseJSON(lstboxhandels.Items(i).ToString)

            If (fg_hwnd = processitem("wh")) Then
                Console.WriteLine(("Process Item window handler " & processitem("wh")))
                processfound = True
                Exit For
            End If
            Console.WriteLine("Process : " & i)
            Console.WriteLine(("Process Item " & lstboxhandels.Items(i).ToString))

        Next
        'Proceee not in list
        'Wait for timer to run process list atleat once - intial form load
        If processfound = False And lstboxhandels.Items.Count > 0 Then

            getAllProcess()

        End If

    End Sub

    Private Sub allprocess_Tick(sender As Object, e As EventArgs) Handles allprocess.Tick

        allprocess.Interval = 120000

        getAllProcess()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If (Not System.IO.Directory.Exists(sssavepath)) Then
            System.IO.Directory.CreateDirectory(sssavepath)
        End If

        If (Not System.IO.Directory.Exists(sssavepath & Now.ToString("MM-dd-yyyy"))) Then
            System.IO.Directory.CreateDirectory(sssavepath & Now.ToString("MM-dd-yyyy"))
        End If

        intavail = HaveInternetConnection()
        'Console.Clear()

        Console.WriteLine("Form Load : " & Now.ToString(mysqldateformat))

        'Me.Height = 450
        'Me.Width = 326
        'Me.WindowState = vbNormal

        Me.CenterToScreen()
        Me.CenterToParent()

        Dim checkregkey As String = applicationName

        Dim versionNumber As Version
        versionNumber = Assembly.GetExecutingAssembly().GetName().Version

        'flaglasttask = True

        GetRegValues()

        _inactiveTimeRetriever = New cIdleTimeStool


        'If version number mismatching or missing write to registery
        If CurrentVersion <> versionNumber.ToString Then

            'Assume the application is loading first time or someone modified the version key mannully

            My.Computer.Registry.CurrentUser.CreateSubKey(applicationName)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "CurrentVersion", versionNumber.ToString)

            My.Computer.Registry.CurrentUser.CreateSubKey(applicationName)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", applicationName, """" & applicationPath & """")
            autostart.Checked = True

            desktopshortcut.Checked = True

        Else

            If startwithos = "" Then

                autostart.Checked = False

            ElseIf startwithos = """" & applicationPath & """" Then

                autostart.Checked = True

            ElseIf startwithos <> "" And startwithos <> """" & applicationPath & """" Then

                My.Computer.Registry.CurrentUser.CreateSubKey(applicationName)
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", applicationName, """" & applicationPath & """")
                autostart.Checked = True

            End If

        End If

        If AutoLoginReg = "True" Then

            autologin.Checked = True

            If UsernameReg <> "" And PasswordReg <> "" And intavail Then

                Button1.Enabled = False
                animate.Enabled = True

            End If

        End If

        If SaveCredentialReg = "True" Then

            SetLoginCredentials()
            savelogin.Checked = True

        End If

        Button1.Select()

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            ''NotifyIcon1.Icon = SystemIcons.Application
            'NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            'NotifyIcon1.BalloonTipText = "I'm here in your Systray for your help!"
            'NotifyIcon1.BalloonTipTitle = "Happy Coding!"
            'NotifyIcon1.ShowBalloonTip(2000)
            ''Me.Hide()
            ShowInTaskbar = False
        End If

        If Me.WindowState <> FormWindowState.Minimized Then

            ShowInTaskbar = True

        End If

    End Sub

    Private Sub InactivityTimer_Tick(sender As Object, e As EventArgs) Handles InactivityTimer.Tick

        'Calculates for how long we have been idle
        Dim inactiveTime = _inactiveTimeRetriever.GetInactiveTime
        Dim sendRes As String
        Dim sendPostData As String

        If (inactiveTime Is Nothing) Then
            'Unknow state

        ElseIf (inactiveTime.Value.TotalSeconds > 5) Then

            'Idle
            inactsec = inactiveTime.Value.TotalSeconds.ToString("#")
            Console.WriteLine(sendPostData & " <> " & "d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat))
            If (inactsec Mod 120) = 0 And sendPostData <> "d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat) Then

                'inactivitylogs.Items.Add(inactsec & "|" & Now.ToString(mysqldateformat))
                sendPostData = "d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat)
                sendRes = SendGetData("d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat))
                Console.WriteLine(sendRes & " & " & sendPostData)
                'no internet connection or data not posted to API
                If sendPostData = sendRes Then
                    inactivitylogs.Items.Add(inactsec & " - " & Now.ToString(mysqldateformat))
                Else
                    inactivitylogs.Items.Add(inactsec & " - " & Now.ToString(mysqldateformat) & "&res=" & sendRes)
                End If

            End If

            DoSomething()

        Else
            'Active

            If inactsec > 0 Then

                'inactivitylogs.Items.Add(inactsec & "|" & Now.ToString(mysqldateformat))
                sendPostData = "d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat)
                sendRes = SendGetData("d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat))
                Console.WriteLine(sendRes & " & " & sendPostData)
                'no internet connection or data not posted to API
                If sendPostData = sendRes Then
                    inactivitylogs.Items.Add(inactsec & " - " & Now.ToString(mysqldateformat))
                Else
                    inactivitylogs.Items.Add(inactsec & " - " & Now.ToString(mysqldateformat) & "&res=" & sendRes)
                End If

                inactsec = 0

            End If

        End If

    End Sub

    Private Sub DoSomething()
        'With ProgressBar1
        'If .Value >= .Maximum Then
        '.Value = 0
        'End If
        ' .Value += 1
        ' End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        GetRegValues()
        SaveLoginCredentials()

        If TextBox1.Text = "" Or TextBox2.Text = "" Then

            MessageBox.Show("Email ID and Password is required", "My Time Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            GetAuthKey()
            islogin = Login()

            If (islogin) Then

                SetProjects()
                SetProjectTask()
                SetAutoProjectTask()

            End If

        End If

    End Sub



    Public Function HaveInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            intavail = False
            Return False
        End Try

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        SetProjects()
        SetProjectTask()

    End Sub

    Private Sub project_SelectedIndexChanged(sender As Object, e As EventArgs) Handles project.SelectedIndexChanged

        If islogin Then
            SetTasks()
        End If

        If autoselproject.Checked And islogin Then
            SaveLastProjectTask()
        End If

        If islogin = True Then
            projectkey = DirectCast(project.SelectedItem, KeyValuePair(Of String, String)).Key
        End If

    End Sub

    Private Sub task_SelectedIndexChanged(sender As Object, e As EventArgs) Handles task.SelectedIndexChanged

        If autoselproject.Checked And islogin Then

            SaveLastProjectTask()

        End If

        If islogin Then
            taskkey = DirectCast(task.SelectedItem, KeyValuePair(Of String, String)).Key
        End If

        If taskkey!= "" Then
            taskdetailslink.Visible = False
        Else
            taskdetailslink.Visible = True
        End If


    End Sub



    Private Sub autostart_CheckedChanged(sender As Object, e As EventArgs) Handles autostart.CheckedChanged
        Dim applicationName As String = Application.ProductName
        Dim applicationPath As String = Application.ExecutablePath


        If autostart.Checked Then

            My.Computer.Registry.CurrentUser.CreateSubKey(applicationName)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", applicationName, """" & applicationPath & """")

        Else

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", applicationName, "")

        End If
    End Sub



    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If e.CloseReason = CloseReason.UserClosing Then

            If systrayalert = True Then
                MessageBox.Show("I'm residing in your Systray for your help!", "My Time Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                systrayalert = False
            End If

            Me.WindowState = FormWindowState.Minimized
            e.Cancel = True

            ShowInTaskbar = False

        End If
        MyBase.OnFormClosing(e)
    End Sub


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        If systrayalert = True Then
            MessageBox.Show("I'm residing in your Systray for your help!", "My Time Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information)
            systrayalert = False
        End If
        Me.WindowState = 1
        ShowInTaskbar = False

    End Sub

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click

        islogin = False

        SendDataRes = SendGetData("d=L")

        scrnsvr.Enabled = False
        inactivitylogs.Enabled = False
        tmrGetFgWindow.Enabled = False
        allprocess.Enabled = False

        afterlogin.Visible = False
        beforelogin.Visible = True
        taskdetailslink.Visible = False

        task.DataSource = Nothing
        task.Items.Clear()

        project.DataSource = Nothing
        project.Items.Clear()

        autoselproject.Checked = False

        If savelogin.Checked = False Then
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If
        Button1.Enabled = True
    End Sub

    Private Sub autologin_CheckedChanged(sender As Object, e As EventArgs) Handles autologin.CheckedChanged

        If autostart.Checked Then

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoLogin", autologin.Checked)

        Else

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoLogin", "")

        End If

    End Sub

    Private Sub autoselproject_CheckedChanged(sender As Object, e As EventArgs) Handles autoselproject.CheckedChanged
        If islogin = True Then
            If autoselproject.Checked Then

                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", autoselproject.Checked)

            Else

                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", "")

            End If
            SaveLastProjectTask()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(shorturl & "mutkmc")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start(shorturl & "txyrwx")
    End Sub

    Private Sub taskdetailslink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles taskdetailslink.LinkClicked
        Dim key As String = DirectCast(task.SelectedItem, KeyValuePair(Of String, String)).Key
        System.Diagnostics.Process.Start(shorturl & "gyasev?cf=" & key)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        System.Diagnostics.Process.Start(shorturl & "ctpwvl")
    End Sub

    Public Function SaveLastProjectTask()

        If autoselproject.Checked Then

            Dim projectkey As String = DirectCast(project.SelectedItem, KeyValuePair(Of String, String)).Key
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastProject", projectkey)

            Dim taskkey As String = DirectCast(task.SelectedItem, KeyValuePair(Of String, String)).Key
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastTask", taskkey)

        Else

            'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastProject", "")
            'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastTask", "")

        End If

        Return True

    End Function

    Public Function GetRegValues() As Boolean

        startwithos = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", applicationName, Nothing)

        CurrentVersion = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "CurrentVersion", Nothing)
        AutoLoginReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoLogin", Nothing)

        AutoSelProjectReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", Nothing)
        LastProjectReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastProject", Nothing)
        LastTaskReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastTask", Nothing)

        SaveCredentialReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "SaveCredential", Nothing)
        UsernameReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "Username", Nothing)
        PasswordReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "Password", Nothing)

        Return True

    End Function

    Public Function SetProjects() As Boolean

        Dim projectindex As Integer
        Dim itemindex As Integer

        Dim httpresp As String
        httpresp = SendGetData("uid=" & authkey.Text & "&r=p")
        RichTextBox1.Text = httpresp

        Dim jss As New JavaScriptSerializer()
        Dim datadict As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(httpresp)

        RichTextBox1.Text = datadict("p").ToString

        Dim mailItems = New List(Of Task)
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("", "Select Project")

        For Each item As Object In datadict("p")

            comboSource.Add(item.key, item.Value)

            If item.key = LastProjectReg Then

                projectindex = projectindex + 1
                itemindex = projectindex

            Else

                projectindex = projectindex + 1

            End If
        Next

        project.DataSource = New BindingSource(comboSource, Nothing)
        project.DisplayMember = "Value"
        project.ValueMember = "Key"

        Return True

    End Function

    Public Function SetTasks() As Boolean

        Dim taskindex As Integer
        Dim itemindex As Integer

        Dim key As String = DirectCast(project.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim value As String = DirectCast(project.SelectedItem, KeyValuePair(Of String, String)).Value

        If key <> "" Then

            Dim postData As String = "uid=" & authkey.Text & "&r=t&p=" & key

            Dim httpres As String
            httpres = SendGetData(postData)
            RichTextBox1.Text = httpres

            If httpres.Replace(vbCr, "").Replace(vbLf, "") <> "" Then

                Dim jss As New JavaScriptSerializer()
                Dim datadict As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(httpres)

                If datadict("t").ToString <> "" Then

                    RichTextBox1.Text = datadict("t").ToString

                    Dim comboSource As New Dictionary(Of String, String)()
                    comboSource.Add("", "Select Task")

                    For Each item As Object In datadict("t")

                        comboSource.Add(item.key, item.Value)

                        If item.key = LastTaskReg Then
                            taskindex = taskindex + 1
                            itemindex = taskindex
                        Else
                            taskindex = taskindex + 1
                        End If
                    Next

                    task.DataSource = New BindingSource(comboSource, Nothing)
                    task.DisplayMember = "Value"
                    task.ValueMember = "Key"

                End If

            Else

                Dim comboSource As New Dictionary(Of String, String)()
                comboSource.Add("", "No Task found")
                task.DataSource = New BindingSource(comboSource, Nothing)
                task.DisplayMember = "Value"
                task.ValueMember = "Key"

            End If
        Else

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("", "Select Task")
            task.DataSource = New BindingSource(comboSource, Nothing)
            task.DisplayMember = "Value"
            task.ValueMember = "Key"

        End If

        Return True

    End Function

    Public Function SetProjectTask() As Boolean

        If AutoSelProjectReg = "True" Then

            Dim itemindex As Integer

            For Each item As Object In project.DataSource

                Console.WriteLine(item.key & " - " & item.Value)
                If item.key = LastProjectReg And LastProjectReg <> "" Then
                    project.SelectedIndex = itemindex
                End If
                itemindex = itemindex + 1

            Next

            Dim taskindex As Integer
            For Each item As Object In task.DataSource

                Console.WriteLine(item.key & " - " & item.Value)
                If item.key = LastTaskReg And LastTaskReg <> "" Then
                    task.SelectedIndex = taskindex
                End If
                taskindex = taskindex + 1

            Next

        End If
        Return True
    End Function

    Public Function SetAutoProjectTask() As Boolean

        If AutoSelProjectReg = "True" Then
            autoselproject.Checked = True
        End If

    End Function



    Private Sub initializer_Tick(sender As Object, e As EventArgs) Handles initializer.Tick

        If HaveInternetConnection() Then
            'MsgBox("Initialise")
            Console.WriteLine("Initialise Timer : " & Now.ToString(mysqldateformat))
            'Console.WriteLine("Initialise")
            InitializeApp()
            initializer.Enabled = False
        Else
            initializer.Interval = 60000
        End If

    End Sub

    Public Function InitializeApp() As Boolean

        If AutoLoginReg = "True" Then

            If TextBox1.Text <> "" And TextBox2.Text <> "" Then

                GetAuthKey()
                islogin = Login()
                If islogin Then
                    SetProjects()
                    SetProjectTask()
                    SetAutoProjectTask()
                End If

            End If

        End If
        animate.Enabled = False
        Button1.Text = "Login"
        Return islogin

    End Function

    Public Function Login() As Boolean

        'Successfully logined
        If (authkey.Text <> "") Then

            islogin = True
            scrnsvr.Enabled = True
            inactivitylogs.Enabled = True
            tmrGetFgWindow.Enabled = True
            allprocess.Enabled = True

            afterlogin.Visible = True
            beforelogin.Visible = False
            afterlogin.Top = beforelogin.Top

            Return True

        Else

            If apidown = False Then

                initializer.Enabled = False
                MessageBox.Show("Login error! Wrong Eail ID or Password", "My Time Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Button1.Enabled = True
                Return False

            Else
                Button1.Enabled = True
                initializer.Interval = 60000
                Return False
            End If


        End If

    End Function


    Public Function SaveLoginCredentials()

        If savelogin.Checked Then

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "SaveCredential", savelogin.Checked)

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "Username", TextBox1.Text)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "Password", TextBox2.Text)

        Else

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "SaveCredential", savelogin.Checked)

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "Username", "")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "Password", "")

        End If

        Return True

    End Function

    Private Sub savelogin_CheckedChanged(sender As Object, e As EventArgs) Handles savelogin.CheckedChanged

        SaveLoginCredentials()

    End Sub

    Public Function SetLoginCredentials()

        TextBox1.Text = UsernameReg
        TextBox2.Text = PasswordReg

        Return True

    End Function


    Private Sub TextBox4_Click(sender As Object, e As EventArgs)
        TextBox1.Select()
    End Sub


    Private Sub TextBox3_Click(sender As Object, e As EventArgs)
        TextBox2.Select()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_MouseClick(sender As Object, e As MouseEventArgs)
        TextBox1.Select()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        TextBox1.Select()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        TextBox2.Select()
    End Sub


    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus

        SaveLoginCredentials()

    End Sub


    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus

        SaveLoginCredentials()

    End Sub


    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click

        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
            Me.Activate()
        Else
            Me.WindowState = FormWindowState.Minimized
        End If

    End Sub

    Private Sub animate_Tick(sender As Object, e As EventArgs) Handles animate.Tick

        If AutoLoginReg = "True" And TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Button1.Text = " " & Button1.Text & "."
            If (Button1.Text = "      Login......") Then
                Button1.Text = "Login"
            End If
        End If

    End Sub

    Public Function SendGetData(postData As String) As String

        Console.WriteLine("Calling SendGetData... : " & postData)
        Dim thepage As String

        If intavail And apidown = False Then

            Dim currnettime As String = Now.ToString(mysqldateformat)
            Dim querystring As String = "&ct=" & currnettime & "&islogin=" & islogin & "&t=" & taskkey & "&p=" & projectkey & "&uid=" & authkey.Text & "&" & postData & "&" & lastactwnw

            Dim tempCookies As New CookieContainer
            Dim encoding As New UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(querystring)

            Try

                Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(apiurl), HttpWebRequest)
                postReq.Method = "POST"
                postReq.KeepAlive = True
                postReq.CookieContainer = tempCookies
                postReq.ContentType = "application/x-www-form-urlencoded"
                postReq.Referer = apiurl
                postReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:81.0) Gecko/20100101 Firefox/81.0"
                postReq.ContentLength = byteData.Length

                Dim postreqstream As Stream = postReq.GetRequestStream()
                postreqstream.Write(byteData, 0, byteData.Length)
                postreqstream.Close()

                Dim postresponse As HttpWebResponse
                postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                tempCookies.Add(postresponse.Cookies)
                logincookie = tempCookies

                Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
                thepage = postreqreader.ReadToEnd

            Catch ex As Exception

                intavail = HaveInternetConnection()
                If intavail And ex.GetType.ToString = "System.Net.WebException" Then

                    apidown = True
                    Console.WriteLine("apidown : " & apidown)

                End If

            End Try

            RichTextBox1.Text = thepage

            Return thepage
        Else
            Return postData
        End If

    End Function

    Public Function GetAuthKey() As String

        authkey.Text = ""

        Dim currnettime As String = Now.ToString(mysqldateformat)
        Dim thepage As String

        If (TextBox1.Text <> "" And TextBox2.Text <> "") Then

            Dim postData As String = "un=" & TextBox1.Text & "&pw=" & TextBox2.Text & "&ct=" & currnettime
            Dim tempCookies As New CookieContainer
            Dim encoding As New UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(postData)

            Try

                Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(apiurl), HttpWebRequest)
                postReq.Method = "POST"
                postReq.KeepAlive = True
                postReq.CookieContainer = tempCookies
                postReq.ContentType = "application/x-www-form-urlencoded"
                postReq.Referer = apiurl
                postReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:81.0) Gecko/20100101 Firefox/81.0"
                postReq.ContentLength = byteData.Length

                Dim postreqstream As Stream = postReq.GetRequestStream()
                postreqstream.Write(byteData, 0, byteData.Length)
                postreqstream.Close()

                Dim postresponse As HttpWebResponse
                postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                tempCookies.Add(postresponse.Cookies)
                logincookie = tempCookies

                Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
                thepage = postreqreader.ReadToEnd

            Catch ex As Exception

                intavail = HaveInternetConnection()

                If intavail And ex.GetType.ToString = "System.Net.WebException" Then

                    apidown = True

                    Console.WriteLine("apidown : " & apidown)

                End If


                Console.WriteLine("ex.GetType.ToString : " & ex.GetType.ToString)
                Console.WriteLine("ex.Message : " & ex.Message)

            End Try

            RichTextBox1.Text = thepage


            Dim datadict As Dictionary(Of String, String) = ParseJSON(thepage)

            If datadict Is Nothing Then

            Else

                authkey.Text = datadict("uid")

            End If

            If authkey.Text <> "" Then
                    Return True
                Else
                    Return False
                End If

            End If

    End Function

    Public Function ParseJSON(jsonData As String) As Dictionary(Of String, String)

        Dim datadict As Dictionary(Of String, String)

        Try

            Dim jss As New JavaScriptSerializer()
            datadict = jss.Deserialize(Of Dictionary(Of String, String))(jsonData)

        Catch ex As Exception

            Console.WriteLine("Invalid JSON")   'Invalid JSON

        End Try

        Return datadict

    End Function

    Public Function getAllProcess() As Boolean

        lstboxhandels.Items.Clear()
        'LstBoxHWNDCaptions.Items.Clear()

        Dim p As Process
        Dim prslist As String
        Dim fn As String

        'Process.GetProcessById();

        For Each p In Process.GetProcesses(System.Environment.MachineName)
            'Only add proccess that there HWND is not 0
            If p.MainWindowHandle.ToString <> IntPtr.Zero.ToString Then

                Try
                    'lstboxhandels.Items.Add(Now.ToString(mysqldateformat) + "|" + p.MainWindowHandle.ToString + " | Process ID : " + p.Id.ToString + " | Process Name : " + p.ProcessName.ToString _
                    ' + " | File Name : " + p.MainModule.FileName.ToString + " | Machine : " + p.MachineName.ToString + " | File Description : " + p.MainModule.FileVersionInfo.FileDescription
                    ' )
                    fn = p.MainModule.FileName.ToString
                    fn = fn.Replace("\", "\\")
                    prslist = "{""wh"": """ & p.MainWindowHandle.ToString & """, ""pid"": """ & p.Id.ToString & """,""pn"":""" & p.ProcessName.ToString & """,""fn"":""" & fn & """,""fd"":""" & p.MainModule.FileVersionInfo.FileDescription & """}"
                    lstboxhandels.Items.Add(prslist)
                    allprocesslist = allprocesslist & prslist & ","
                Catch
                    ' lstboxhandels.Items.Add(Now.ToString(mysqldateformat) + "|" + p.MainWindowHandle.ToString + " | Process ID : " + p.Id.ToString + " | Process Name : " + p.ProcessName.ToString _
                    ' + " | File Name : " + " | Machine : " + p.MachineName.ToString
                    ' )
                    prslist = "{""wh"": """ & p.MainWindowHandle.ToString & """, ""pid"": """ & p.Id.ToString & """,""pn"":""" & p.ProcessName.ToString & """,""fn"":""" & """,""fd"":""" & """}"
                    lstboxhandels.Items.Add(prslist)
                    allprocesslist = allprocesslist & prslist & ","
                End Try


                'lstboxhandels.Items.Add(p.MainWindowTitle.ToString)
            End If
        Next p
        allprocesslist.Trim(" ")
        allprocesslist.Trim(",")

        allprocesslist = "{""mn"":""" & p.MachineName.ToString & """,""pt"":""" & Now.ToString(mysqldateformat) & """,""ap"":[" & allprocesslist.Trim(", ") & "]}"
        Console.WriteLine(allprocesslist)
        'If islogin Then
        SendDataRes = SendGetData("d=P&ap=" & allprocesslist)
        'End If

        allprocesslist = String.Empty

        Return True

    End Function

    Private Function CreateDektopShortCut(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String) As Boolean

        Dim oShell As Object
        Dim oLink As Object

        Try

            oShell = CreateObject("WScript.Shell")
            oLink = oShell.CreateShortcut(ShortCutPath & "\" & ShortCutName & ".lnk")

            oLink.TargetPath = TargetName
            oLink.WindowStyle = 1
            oLink.Save()

        Catch ex As Exception

        End Try

    End Function

    Private Sub desktopshortcut_CheckedChanged(sender As Object, e As EventArgs) Handles desktopshortcut.CheckedChanged

        If desktopshortcut.Checked Then

            Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            CreateDektopShortCut(applicationPath, desktopPath, "My Time Tracker")

        End If

    End Sub

    Private Sub AboutEOfficeDesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutEOfficeDesktopToolStripMenuItem.Click
        System.Diagnostics.Process.Start(shorturl & "3s5gid")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        System.Diagnostics.Process.Start(shorturl & "os7gut")
    End Sub


    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        System.Diagnostics.Process.Start(shorturl & "fdfbva")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        System.Diagnostics.Process.Start(shorturl & "fmdptk")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub


End Class
