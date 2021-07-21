Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Reflection
Imports System.ComponentModel

Public Class Form1


    Inherits System.Windows.Forms.Form

    Private Const DESKTOPVERTRES As Integer = &H75
    Private Const DESKTOPHORZRES As Integer = &H76
    Private objMutex As System.Threading.Mutex

    Private _inactiveTimeRetriever As cIdleTimeStool

    'Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As Long, lpdwProcessId As Long) As Long

    'Public Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As Long
    Declare Auto Function SetForegroundWindow Lib "user32.dll" Alias "SetForegroundWindow" (ByVal hWnd As IntPtr) As Integer

    Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As Integer
    Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As Integer) As Integer
    Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
    Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As Long, lpdwProcessId As Long) As Long
    Declare Function GetDeviceCaps Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal nIndex As Integer) As Integer



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
    Dim apiurl As String = "http://kenprotechnologies.com/eofficedesktopapp/api/"
    Dim testapiurl As String = "http://dfwwebexpert/eofficedesktopwebapp/api/"

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

    Dim actwidth As Integer
    Dim actheight As Integer
    Dim production = True
    Dim querystring As String
    Dim wnwtimestamp As String
    Dim sgfilename As String

    Public Sub New()

        On Error Resume Next

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Function FormatBytes(ByVal bytes As Long) As String

        If bytes < 1000 Then
            Return CStr(bytes) & "B"
        ElseIf bytes < 1000000 Then
            Return FormatNumber(bytes / 1024, 2) & "KB"
        ElseIf bytes < 1000000000 Then
            Return FormatNumber(bytes / 1048576, 2) & "MB"
        Else
            Return FormatNumber(bytes / 1073741824, 2) & "GB"
        End If

    End Function

    Private Class AsmComparer
        Implements IComparer(Of Assembly)

        Public Function Compare(x As System.Reflection.Assembly, y As System.Reflection.Assembly) As Integer Implements System.Collections.Generic.IComparer(Of System.Reflection.Assembly).Compare
            Return String.Compare(x.ToString(), y.ToString())
        End Function
    End Class

    Private Sub scrnsvr_Tick(sender As Object, e As EventArgs) Handles scrnsvr.Tick



        'Dim lastscreensaver = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)

        Dim seconds As Long = DateDiff(DateInterval.Second, lastscreensaver, Now)

        Console.WriteLine(seconds)

        If (seconds > minsec) Then

            Dim fg_hwnd As Long = GetForegroundWindow()
            Dim fg_wndttle As String = GetWindowTitle(fg_hwnd)

            SetActWidthHeight()

            wnwtimestamp = Now.ToString(mysqldateformat)

            ''Dim unused = MsgBox(milliseconds)
            'Dim sgfilename As String
            Dim screenSize As Size = New Size(actwidth, actheight)
            Dim screenGrab As New Bitmap(actwidth, actheight)

            sgfilename = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds) & ".jpg"

            Try

                Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
                g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
                screenGrab.Save(sssavepath & Now.ToString("MM-dd-yyyy") & "\" & "MS" & sgfilename)
                ''or screenGrab.Save("C:\screenGrab.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                lastscreensaver = Now

            Catch ex As Exception
                sgfilename = "F" & sgfilename
                Console.WriteLine(ex)
                LogException(ex)
            End Try


            lastactwnw = "awt=" & wnwtimestamp & "&wh=" & fg_hwnd & "&ss=" & sgfilename
            SendDataRes = SendGetData("d=W&" & lastactwnw & "&wt=" & fg_wndttle)

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

        'Take screenshot if active window is changed
        lastscreensaver = Now

        Dim screenSize As Size = New Size(actwidth, actheight)
        Dim screenGrab As New Bitmap(actwidth, actheight)

        Console.WriteLine("My.Computer.Screen.Bounds.Width : " & My.Computer.Screen.Bounds.Width)
        Console.WriteLine("My.Computer.Screen.Bounds.Height : " & My.Computer.Screen.Bounds.Height)

        SetActWidthHeight()

        sgfilename = "WC" & CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds) & ".jpg"

        Try

            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
            screenGrab.Save(sssavepath & Now.ToString("MM-dd-yyyy") & "\" & sgfilename)

        Catch ex As Exception

            sgfilename = "F" & sgfilename
            Console.WriteLine(ex)
            LogException(ex)

        End Try

        lastactwnw = "awt=" & wnwtimestamp & "&wh=" & fg_hwnd & "&ss=" & sgfilename
        SendDataRes = SendGetData("d=W&" & lastactwnw & "&wt=" & fg_wndttle)

        If SendDataRes = "d=W&" & lastactwnw & "&wt=" & fg_wndttle Then

            list_item = lvwFGWindow.Items.Add(wnwtimestamp)
            list_item.SubItems.Add(fg_hwnd)
            list_item.SubItems.Add(fg_wndttle)
            list_item.SubItems.Add(sgfilename)
            list_item.SubItems.Add(querystring)
            list_item.EnsureVisible()

        Else

            'Dim pos As Int32
            'Dim listItem As ListViewItem

            'For pos = lvwFGWindow.Items.Count - 1 To 0 Step -1
            '    listItem = lvwFGWindow.Items(pos)
            '    'If listItem.SubItems(4).Text = "testvalue" Then
            '    lvwFGWindow.Items.Remove(listItem)
            '    'End If
            '    Console.WriteLine("listItem.SubItems(4).Text : " & listItem.SubItems(4).Text)
            'Next

        End If

        Dim processitem As Dictionary(Of String, String)
        Dim processfound As Boolean = False

        For i = 0 To lstboxhandels.Items.Count - 1

            processitem = ParseJSON(lstboxhandels.Items(i).ToString)

            If processitem("wh") IsNot Nothing And fg_hwnd = processitem("wh") Then
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


        If production Then

            Me.Height = 450
            Me.Width = 326

            'Check to prevent running twice
            objMutex = New System.Threading.Mutex(False, "MyTimeTracker")
            If objMutex.WaitOne(0, False) = False Then
                objMutex.Close()
                objMutex = Nothing
                End
            End If
            'If you get to this point it's frist instance

            NotifyIcon1.Text = Me.Text & " - " & Application.ProductVersion & " (Live) "
            Me.Text = Me.Text & " - " & Application.ProductVersion & " (Live) "
        Else

            NotifyIcon1.Text = Me.Text & " - " & Application.ProductVersion & " (Development) "
            Me.Text = Me.Text & " - " & Application.ProductVersion & " (Development) "

            apiurl = testapiurl
            Me.WindowState = WindowState.Maximized


        End If

        If (Not System.IO.Directory.Exists(sssavepath)) Then
            System.IO.Directory.CreateDirectory(sssavepath)
        End If

        If (Not System.IO.Directory.Exists(sssavepath & Now.ToString("MM-dd-yyyy"))) Then
            System.IO.Directory.CreateDirectory(sssavepath & Now.ToString("MM-dd-yyyy"))
        End If

        Handle_NetworkAvailabilityChanged()

        intavail = HaveInternetConnection()
        'Console.Clear()

        Console.WriteLine("Form Load : " & Now.ToString(mysqldateformat))



        'Me.WindowState = vbNormal

        Me.CenterToScreen()
        Me.CenterToParent()

        Dim checkregkey As String = applicationName

        Dim versionNumber As Version
        versionNumber = Assembly.GetExecutingAssembly().GetName().Version

        'flaglasttask = True

        GetRegValues()

        SetActWidthHeight()

        _inactiveTimeRetriever = New cIdleTimeStool


        'If version number mismatching or missing write to registery
        If CurrentVersion <> versionNumber.ToString And production = True Then

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

            ElseIf startwithos <> "" And startwithos <> """" & applicationPath & """" And production = True Then

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

            'if development mode show all form controlls
            If production Then
                ShowInTaskbar = True
            Else
                Me.WindowState = WindowState.Maximized
                ShowInTaskbar = True
            End If

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

                'ixnactivitylogs.Items.Add(inactsec & "|" & Now.ToString(mysqldateformat))
                sendPostData = "d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat)
                sendRes = SendGetData("d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat))
                Console.WriteLine(sendRes & " & " & sendPostData)
                'no internet connection or data not posted to API
                If sendPostData = sendRes Then
                    inactivitylogs.Items.Add(inactsec & " - " & Now.ToString(mysqldateformat) & "&res=" & sendRes)
                Else

                End If

            End If

            DoSomething()

        Else
            'Active

            If inactsec > 0 Then

                'inxactivitylogs.Items.Add(inactsec & "|" & Now.ToString(mysqldateformat))
                sendPostData = "d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat)
                sendRes = SendGetData("d=I&tis=" & inactsec & "&ie=" & Now.ToString(mysqldateformat))
                Console.WriteLine(sendRes & " & " & sendPostData)
                'no internet connection or data not posted to API
                If sendPostData = sendRes Then

                    'Issue ID #1
                    Try
                        inactivitylogs.Items.Add(querystring)
                    Catch ex As Exception
                        Console.WriteLine("Empty Query String")
                        LogException(ex)
                    End Try

                Else

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
            internetchkr.Enabled = True
            Return False
        End Try

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If intavail Then

            SetProjects()
            SetProjectTask()

        End If


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

    Public Function SendGetData(postData As String, Optional ByVal resync As String = "N") As String

        Console.WriteLine("Calling SendGetData... : " & postData)
        Dim thepage As String

        If intavail And apidown = False Then

            Dim currnettime As String = Now.ToString(mysqldateformat)

            If resync = "Y" Then
                querystring = postData
            Else
                querystring = "&ct=" & currnettime & "&islogin=" & islogin & "&t=" & taskkey & "&p=" & projectkey & "&uid=" & authkey.Text & "&" & postData & "&" & lastactwnw
            End If



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
        Dim httpres As String

        If (TextBox1.Text <> "" And TextBox2.Text <> "") Then

            Dim postData As String = "un=" & TextBox1.Text & "&pw=" & TextBox2.Text & "&ct=" & currnettime

            Try

                httpres = SendGetData(postData)

            Catch ex As Exception

                intavail = HaveInternetConnection()
                If intavail And ex.GetType.ToString = "System.Net.WebException" Then

                    apidown = True

                End If

                Console.WriteLine("ex.GetType.ToString : " & ex.GetType.ToString)
                Console.WriteLine("ex.Message : " & ex.Message)

            End Try

            RichTextBox1.Text = httpres

            Dim datadict As Dictionary(Of String, String) = ParseJSON(httpres)

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
            LogException(ex)

        End Try

        Return datadict

    End Function

    Public Function getAllProcess() As Boolean

        Dim p As Process
        Dim prslist As String
        Dim fn As String
        Dim SendAllPDataRes As String

        'Process.GetProcessById();

        'lstboxhandels.Items.Clear()

        For Each p In Process.GetProcesses(System.Environment.MachineName)
            'Only add proccess that there HWND is not 0
            If p.MainWindowHandle.ToString <> IntPtr.Zero.ToString Then

                Try
                    'lstboxhandels.Items.Add(Now.ToString(mysqldateformat) + "|" + p.MainWindowHandle.ToString + " | Process ID : " + p.Id.ToString + " | Process Name : " + p.ProcessName.ToString _
                    ' + " | File Name : " + p.MainModule.FileName.ToString + " | Machine : " + p.MachineName.ToString + " | File Description : " + p.MainModule.FileVersionInfo.FileDescription
                    ' )
                    fn = p.MainModule.FileName.ToString
                    fn = fn.Replace("\", "\\")

                    'm_LastHwnd = fg_hwnd
                    'm_LastWndTile = fg_wndttle

                    'lastactwnw = "awt=" & wnwtimestamp & "&wh=" & fg_hwnd & "&ss=" & sgfilename
                    'SendDataRes = SendGetData("d=W&" & lastactwnw & "&wt=" & fg_wndttle)


                    prslist = "{""pt"":""" & Now.ToString(mysqldateformat) & """,""uid"":""" & authkey.Text & """,""t"": """ & taskkey & """,""p"": """ & projectkey & """,""awttl"": """ & m_LastWndTile & """,""awh"":""" & m_LastHwnd & """,""aws"":""" & sgfilename & """,""awt"": """ & wnwtimestamp & """,""wh"": """ & p.MainWindowHandle.ToString & """, ""pid"": """ & p.Id.ToString & """,""pn"":""" & p.ProcessName.ToString & """,""fn"":""" & fn & """,""fd"":""" & p.MainModule.FileVersionInfo.FileDescription & """}"

                    'querystring = "&ct=" & currnettime & "&islogin=" & islogin & "&t=" & taskkey & "&p=" & projectkey & "&uid=" & authkey.Text & "&" & postData & "&" & lastactwnw

                    lstboxhandels.Items.Add(prslist)
                    allprocesslist = allprocesslist & prslist & ","
                Catch ex As Exception
                    ' lstboxhandels.Items.Add(Now.ToString(mysqldateformat) + "|" + p.MainWindowHandle.ToString + " | Process ID : " + p.Id.ToString + " | Process Name : " + p.ProcessName.ToString _
                    ' + " | File Name : " + " | Machine : " + p.MachineName.ToString
                    ' )

                    ' prslist = "{""pt"": """ & Now.ToString(mysqldateformat) & """,""wh"": """ & p.MainWindowHandle.ToString & """, ""pid"": """ & p.Id.ToString & """,""pn"":""" & p.ProcessName.ToString & """,""fn"":""" & """,""fd"":""" & """}"

                    prslist = "{""pt"":""" & Now.ToString(mysqldateformat) & """,""uid"":""" & authkey.Text & """,""t"": """ & taskkey & """,""p"": """ & projectkey & """,""awttl"": """ & m_LastWndTile & """,""awh"":""" & m_LastHwnd & """,""aws"":""" & sgfilename & """,""awt"": """ & wnwtimestamp & """,""wh"": """ & p.MainWindowHandle.ToString & """, ""pid"": """ & p.Id.ToString & """,""pn"":""" & p.ProcessName.ToString & """,""fn"":""" & """,""fd"":""" & """}"

                    lstboxhandels.Items.Add(prslist)
                    allprocesslist = allprocesslist & prslist & ","
                    LogException(ex)
                End Try


                'lstboxhandels.Items.Add(p.MainWindowTitle.ToString)
            End If
        Next p
        allprocesslist.Trim(" ")
        allprocesslist.Trim(",")

        allprocesslist = "{""mn"":""" & p.MachineName.ToString & """,""pt"":""" & Now.ToString(mysqldateformat) & """,""ap"":[" & allprocesslist.Trim(", ") & "]}"
        Console.WriteLine("allprocesslist : " & allprocesslist)


        'If islogin Then
        SendAllPDataRes = SendGetData("d=P&ap=" & allprocesslist)

        If intavail = True And SendAllPDataRes <> "d=P&ap=" & allprocesslist Then
            lstboxhandels.Items.Clear()
        End If

        Console.WriteLine("SendAllPDataRes : " & SendAllPDataRes)
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
            LogException(ex)
        End Try

    End Function

    Public Function LogException(ByVal ex As Exception) As Boolean

        Dim FILE_NAME As String = Application.StartupPath() & "\logs\error_logs_" & Now.ToString("MM-dd-yyyy") & ".txt"
        Dim i As Integer
        Dim aryText(6) As String

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)

        ' Add any initialization after the InitializeComponent() call.
        objWriter.WriteLine("==================" & Now.ToString(mysqldateformat) & "=========================")
        objWriter.WriteLine("Product Name:      " & My.Application.Info.ProductName)
        objWriter.WriteLine("Product Version:   " & My.Application.Info.Version.ToString())


        Dim asms As New List(Of Assembly)

        For Each asm As Assembly In My.Application.Info.LoadedAssemblies
            asms.Add(asm)
        Next asm

        'Assemblies are listed in the order they are loaded - I prefer them alphabetical.
        'But if the order in which assemblies are being loaded is important, then don't do the sort.
        Dim asmc As New AsmComparer()
        asms.Sort(asmc)


        For Each asm As Assembly In asms
            'Many of the assemblies are core .Net assemblies. I do not care about them.
            'If you do, comemnt out this next line:
            ''If IO.Path.GetDirectoryName(asm.Location).ToUpper() <> My.Application.Info.DirectoryPath.ToUpper() Then Continue For

            'Included in this list is the executable path - which is meaningless.
            'Have to cast to Upper (or lower), because one of the paths returns as .EXE, and the other .exe
            If asm.Location.ToUpper() = Application.ExecutablePath.ToUpper() Then Continue For

            objWriter.WriteLine("Loaded Assembly:   " & asm.ToString())
        Next asm

        objWriter.WriteLine(vbNewLine)
        objWriter.WriteLine("OS Name:           " & My.Computer.Info.OSFullName)
        objWriter.WriteLine("OS Version:        " & My.Computer.Info.OSVersion)

        ''IMPORTANT: This next line is .Net 4.0 only.
        ''           If you need to know if it is a 64 bit OS or not, you will need to use
        ''           a different method for any .Net older than 4.0
        objWriter.WriteLine("OS Platform:       " & IIf(Environment.Is64BitOperatingSystem, "x64", "x86"))

        objWriter.WriteLine("Physical Memory:   " & FormatBytes(My.Computer.Info.AvailablePhysicalMemory) & " / " & FormatBytes(My.Computer.Info.TotalPhysicalMemory) & " (Free / Total)")
        objWriter.WriteLine("Virtual Memory:    " & FormatBytes(My.Computer.Info.AvailableVirtualMemory) & " / " & FormatBytes(My.Computer.Info.TotalVirtualMemory) & " (Free / Total)")

        objWriter.WriteLine(vbNewLine)
        objWriter.WriteLine("Error Output:")

        'aryText(3) = ex.Source
        'aryText(4) = ex.HelpLink

        objWriter.WriteLine(ex.Message)
        objWriter.WriteLine(ex.StackTrace)

        objWriter.Close()

    End Function
    Private Function SetActWidthHeight() As Boolean

        actwidth = My.Computer.Screen.Bounds.Width
        actheight = My.Computer.Screen.Bounds.Height

        Try

            Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
                Dim hdc As IntPtr = g.GetHdc
                Dim TrueScreenSize As New Size(GetDeviceCaps(hdc, DESKTOPHORZRES), GetDeviceCaps(hdc, DESKTOPVERTRES))
                Dim sclX As Single = CSng(Math.Round((TrueScreenSize.Width / Screen.PrimaryScreen.Bounds.Width), 2))
                Dim sclY As Single = CSng(Math.Round((TrueScreenSize.Height / Screen.PrimaryScreen.Bounds.Height), 2))
                g.ReleaseHdc(hdc)

                'show the true screen size
                Console.WriteLine("Screen Width:  " & TrueScreenSize.Width.ToString & vbLf &
                          "Screen Height: " & TrueScreenSize.Height.ToString & vbLf & vbLf &
                          "Scale X: " & sclX.ToString & vbLf &
                          "Scale Y: " & sclY.ToString)
                actwidth = TrueScreenSize.Width.ToString
                actheight = TrueScreenSize.Height.ToString
            End Using

        Catch ex As Exception

            Console.WriteLine(ex)
            LogException(ex)

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

    Private Sub internetchkr_Tick(sender As Object, e As EventArgs) Handles internetchkr.Tick
        intavail = HaveInternetConnection()
        If intavail Then
            async.Enabled = True
            internetchkr.Enabled = False
        Else
            async.Enabled = False
        End If
    End Sub

    Private Sub async_Tick(sender As Object, e As EventArgs) Handles async.Tick

        Dim listitem As ListViewItem
        Dim SyncDataRes As String

        For i As Integer = lvwFGWindow.Items.Count - 1 To 0 Step -1
            listitem = lvwFGWindow.Items(i)
            SyncDataRes = SendGetData("sync=y" & listitem.SubItems(4).Text, "y")
            If SyncDataRes = "sync=y" & listitem.SubItems(4).Text Then
            Else
                lvwFGWindow.Items.Remove(listitem)
            End If

            Console.WriteLine("listitem.subitems(4).text : " & listitem.SubItems(4).Text)
            Exit For
        Next

        For i As Integer = 0 To inactivitylogs.Items.Count - 1

            Console.WriteLine(" Count " & i)
            Console.WriteLine(" Text " & inactivitylogs.Items(i).ToString)
            SyncDataRes = SendGetData("sync=y" & inactivitylogs.Items(i).ToString, "Y")

            Console.WriteLine(" SyncDataRes : " & SyncDataRes)

            If SyncDataRes = "sync=y" & inactivitylogs.Items(i).ToString Then

            Else
                inactivitylogs.Items.RemoveAt(i)
            End If

            Exit For

        Next



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click



        Dim ctl As Control
        'ctl.Text = "This will throw a null exception!"

    End Sub

    Private Sub DisplayAvailability(available As Boolean)

        intavail = available.ToString

        If (available.ToString) Then
            NotifyIcon1.Text = "My Time Tracker" & " - " & Application.ProductVersion & " (Live) "
            Me.Text = "My Time Tracker" & " - " & Application.ProductVersion & " (Live) "
        Else

            NotifyIcon1.Text = "My Time Tracker" & " - " & Application.ProductVersion & " (Offline) "
            Me.Text = "My Time Tracker" & " - " & Application.ProductVersion & " (Offline) "
        End If

    End Sub

    Private Sub MyComputerNetwork_NetworkAvailabilityChanged(
        sender As Object,
        e As Devices.NetworkAvailableEventArgs)

        DisplayAvailability(e.IsNetworkAvailable)
    End Sub

    Private Sub Handle_NetworkAvailabilityChanged()
        AddHandler My.Computer.Network.NetworkAvailabilityChanged,
           AddressOf MyComputerNetwork_NetworkAvailabilityChanged
        DisplayAvailability(My.Computer.Network.IsAvailable)
    End Sub

End Class
