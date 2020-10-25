Imports System.Web
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

    Dim AutoSelProjectReg As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", Nothing)
    Dim LastProjectReg As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastProject", Nothing)
    Dim LastTaskReg As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastTask", Nothing)

    Dim flaglasttask As Boolean = True 'Disable saving selected task
    Dim shorturl As String = "http:///www.brwz.in/"

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
            screenGrab.Save("d:\screengrabs\MS" & sgfilename)
            ''or screenGrab.Save("C:\screenGrab.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            lastscreensaver = Now

        End If

    End Sub
    Private m_LastHwnd As Integer
    Private m_LastWndTile As String


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
        list_item = lvwFGWindow.Items.Add(text:=Now.ToString("dd:MM:yy hh:mm:ss"))

        list_item.SubItems.Add(fg_hwnd)
        list_item.SubItems.Add(fg_wndttle)


        'Take screenshot if active window is changed
        lastscreensaver = Now
        Dim sgfilename As String
        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        sgfilename = "WC" & CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds) & ".jpg"
        screenGrab.Save("d:\screengrabs\" & sgfilename)

        list_item.SubItems.Add(sgfilename)

        list_item.EnsureVisible()
    End Sub

    Private Sub allprocess_Tick(sender As Object, e As EventArgs) Handles allprocess.Tick
        lstboxhandels.Items.Clear()
        'LstBoxHWNDCaptions.Items.Clear()

        Dim p As Process

        'Process.GetProcessById();

        For Each p In Process.GetProcesses(System.Environment.MachineName)
            'Only add proccess that there HWND is not 0
            If p.MainWindowHandle.ToString <> IntPtr.Zero.ToString Then
                lstboxhandels.Items.Add(Now.ToString("dd:MM:yy hh:mm:ss") + "|" + p.MainWindowHandle.ToString + " | Process ID : " + p.Id.ToString + " | Process Name : " + p.ProcessName.ToString _
                + " | File Name : " + p.MainModule.FileName.ToString + " | Machine : " + p.MachineName.ToString + " | File Description : " + p.MainModule.FileVersionInfo.FileDescription
                )
                'LstBoxHWNDCaptions.Items.Add(p.MainWindowTitle.ToString)
            End If
        Next p
    End Sub

    Private Sub lvwFGWindow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwFGWindow.SelectedIndexChanged

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        flaglasttask = True

        AutoSelProjectReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", Nothing)
        LastProjectReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastProject", Nothing)
        LastTaskReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastTask", Nothing)
        Me.Height = 450
        Me.Width = 326
        Me.CenterToScreen()
        Me.CenterToParent()
        'NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        'NotifyIcon1.BalloonTipText = "I'm here in your Sys tray for your help!"
        'NotifyIcon1.BalloonTipTitle = "Happy Coding!"
        'NotifyIcon1.ShowBalloonTip(2000)
        _inactiveTimeRetriever = New cIdleTimeStool

        Dim applicationName As String = Application.ProductName
        Dim applicationPath As String = Application.ExecutablePath
        Dim checkregkey As String = applicationName

        Dim startwithos As String
        Dim versionNumber As Version

        Dim CurrentVersion As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "CurrentVersion", Nothing)
        Dim AutoLoginReg As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoLogin", Nothing)
        startwithos = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", applicationName, Nothing)

        versionNumber = Assembly.GetExecutingAssembly().GetName().Version

        'If version number mismatching or missing write to registery
        If CurrentVersion <> versionNumber.ToString Then

            MsgBox("versionNumber is mismatching")

            'Assume the application is loading first time or someone modified the version key mannully

            My.Computer.Registry.CurrentUser.CreateSubKey(applicationName)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "CurrentVersion", versionNumber.ToString)

            My.Computer.Registry.CurrentUser.CreateSubKey(applicationName)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", applicationName, """" & applicationPath & """")
            autostart.Checked = True

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
            Button1.PerformClick()

        End If

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            'NotifyIcon1.Icon = SystemIcons.Application
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.BalloonTipText = "I'm here in your Systray for your help!"
            NotifyIcon1.BalloonTipTitle = "Happy Coding!"
            NotifyIcon1.ShowBalloonTip(2000)
            'Me.Hide()
            'ShowInTaskbar = False
        End If

        If Me.WindowState <> FormWindowState.Minimized Then

            'MsgBox(Me.WindowState)
            ShowInTaskbar = True

        End If

    End Sub

    Private Sub InactivityTimer_Tick(sender As Object, e As EventArgs) Handles InactivityTimer.Tick
        'Calculates for how long we have been idle
        Dim inactiveTime = _inactiveTimeRetriever.GetInactiveTime

        If (inactiveTime Is Nothing) Then
            'Unknow state

        ElseIf (inactiveTime.Value.TotalSeconds > 5) Then

            'Idle
            inactsec = inactiveTime.Value.TotalSeconds.ToString("#")
            DoSomething()

        Else
            'Active

            If inactsec > 0 Then
                inactivitylogs.Items.Add(inactsec & "|" & Now.ToString("dd:MM:yy hh:mm:ss"))
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
        'MsgBox(HaveInternetConnection())

        AutoSelProjectReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", Nothing)
        LastProjectReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastProject", Nothing)
        LastTaskReg = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastTask", Nothing)

        Dim postData As String = "un=" & TextBox1.Text & "&pw=" & TextBox2.Text

        'Dim postData As String = "uid=" & TextBox5.Text


        'MsgBox(postData)
        Dim tempCookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://faketestjson.herokuapp.com"), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.CookieContainer = tempCookies
        postReq.ContentType = "application/x-www-form-urlencoded"
        postReq.Referer = "https://faketestjson.herokuapp.com"
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

        Dim thepage As String = postreqreader.ReadToEnd

        RichTextBox1.Text = thepage


        Dim jss As New JavaScriptSerializer()
        Dim datadict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(thepage)

        authkey.Text = datadict("uid")

        'https://www.youtube.com/watch?v=2VJfYboYVpI
        'Dim jss As New JavaScriptSerializer()
        'Dim dict As Object = New JavaScriptSerializer().Deserialize(Of List(Of Object))(RichTextBox1.Text)

        'Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(thepage)
        'MsgBox(Convert.ToInt32(JObject.Parse(thepage)("id")))

        ' Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rawresp)
        'Dim firstItem = jsonResulttodict.item("id")
        'authkey.Text = dict.item("uid").GetType
        '
        'For Each item As Object In dict

        'MsgBox(item("uid"))

        'Next
        If (authkey.Text <> "") Then
            scrnsvr.Enabled = True
            inactivitylogs.Enabled = True
            tmrGetFgWindow.Enabled = True
            allprocess.Enabled = True


            afterlogin.Visible = True
            beforelogin.Visible = False
            afterlogin.Top = beforelogin.Top
            'afterlogin.Left = beforelogin.Top
            Button2.PerformClick()
        End If

    End Sub



    Public Function HaveInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        flaglasttask = True
        Dim projectindex As Integer
        Dim itemindex As Integer

        If AutoSelProjectReg = "True" Then

            autoselproject.Checked = True

        End If
        'WebBrowser1.DocumentText = RichTextBox1.Text

        'MsgBox(HaveInternetConnection())


        Dim postData As String = "uid=" & authkey.Text & "&r=p"

        'Dim postData As String = "uid=" & TextBox5.Text


        'MsgBox(postData)
        Dim tempCookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://faketestjson.herokuapp.com"), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.CookieContainer = tempCookies
        postReq.ContentType = "application/x-www-form-urlencoded"
        postReq.Referer = "https://faketestjson.herokuapp.com"
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

        Dim thepage As String = postreqreader.ReadToEnd

        RichTextBox1.Text = thepage

        Dim jss As New JavaScriptSerializer()
        Dim datadict As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(thepage)

        RichTextBox1.Text = datadict("p").ToString


        'Dim jss As New JavaScriptSerializer()
        ' Dim datadict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(thepage)

        'authkey.Text = datadict("uid")

        'https://www.youtube.com/watch?v=2VJfYboYVpI
        'Dim jss As New JavaScriptSerializer()
        ' Dim dict As Object = New JavaScriptSerializer().Deserialize(Of List(Of Object))(thepage)

        'datadict("uid")

        'Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(thepage)
        'MsgBox(Convert.ToInt32(JObject.Parse(thepage)("p")))

        ' Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rawresp)
        'Dim firstItem = jsonResulttodict.item("id")
        'authkey.Text = dict.item("uid").GetType
        '
        Dim mailItems = New List(Of Task)
        'project.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add("", "Select Project")

        For Each item As Object In datadict("p")

            'MsgBox(item.key)
            'MsgBox(item.Value)
            'project.Items.ad(item.value.ToString)

            comboSource.Add(item.key, item.Value)

            If item.key = LastProjectReg Then
                'MsgBox("Last Project : " & LastProjectReg)
                projectindex = projectindex + 1
                itemindex = projectindex
            Else
                projectindex = projectindex + 1
            End If
        Next

        project.DataSource = New BindingSource(comboSource, Nothing)
        project.DisplayMember = "Value"
        project.ValueMember = "Key"

        'If (authkey.Text <> "") Then
        'scrnsvr.Enabled = True
        'inactivitylogs.Enabled = True
        'tmrGetFgWindow.Enabled = True
        'allprocess.Enabled = True
        'End If
        If AutoSelProjectReg = "True" Then

            'If item.key = LastProjectReg Then
            'MsgBox("Last Project : " & LastProjectReg)
            project.SelectedIndex = itemindex
            ' End If

        End If
    End Sub

    Private Sub project_SelectedIndexChanged(sender As Object, e As EventArgs) Handles project.SelectedIndexChanged

        Dim taskindex As Integer
        Dim itemindex As Integer
        'task.Items.Clear()
        Dim key As String = DirectCast(project.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim value As String = DirectCast(project.SelectedItem, KeyValuePair(Of String, String)).Value

        'MsgBox(key + " : " + value)

        'WebBrowser1.DocumentText = RichTextBox1.Text

        'MsgBox(HaveInternetConnection())

        Dim AutoSelProjectReg As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", Nothing)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastProject", key)

        If key <> "" Then
            Dim postData As String = "uid=" & authkey.Text & "&r=t&p=" & key

            'Dim postData As String = "uid=" & TextBox5.Text


            'MsgBox(postData)
            Dim tempCookies As New CookieContainer
            Dim encoding As New UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(postData)

            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://faketestjson.herokuapp.com"), HttpWebRequest)
            postReq.Method = "POST"
            postReq.KeepAlive = True
            postReq.CookieContainer = tempCookies
            postReq.ContentType = "application/x-www-form-urlencoded"
            postReq.Referer = "https://faketestjson.herokuapp.com"
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

            Dim thepage As String = postreqreader.ReadToEnd

            RichTextBox1.Text = thepage


            If thepage.Replace(vbCr, "").Replace(vbLf, "") <> "" Then



                Dim jss As New JavaScriptSerializer()
                Dim datadict As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(thepage)

                If datadict("t").ToString <> "" Then


                    RichTextBox1.Text = datadict("t").ToString


                    'Dim jss As New JavaScriptSerializer()
                    ' Dim datadict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(thepage)

                    'authkey.Text = datadict("uid")

                    'https://www.youtube.com/watch?v=2VJfYboYVpI
                    'Dim jss As New JavaScriptSerializer()
                    ' Dim dict As Object = New JavaScriptSerializer().Deserialize(Of List(Of Object))(thepage)

                    'datadict("uid")

                    'Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(thepage)
                    'MsgBox(Convert.ToInt32(JObject.Parse(thepage)("p")))

                    ' Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rawresp)
                    'Dim firstItem = jsonResulttodict.item("id")
                    'authkey.Text = dict.item("uid").GetType
                    '
                    Dim mailItems = New List(Of Task)
                    'task.Items.Clear()

                    Dim comboSource As New Dictionary(Of String, String)()

                    comboSource.Add("", "Select Task")

                    For Each item As Object In datadict("t")

                        'MsgBox(item.key)
                        'MsgBox(item.Value)
                        'project.Items.ad(item.value.ToString)

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

                    'If (authkey.Text <> "") Then
                    'scrnsvr.Enabled = True
                    'inactivitylogs.Enabled = True
                    'tmrGetFgWindow.Enabled = True
                    'allprocess.Enabled = True
                    'End If

                End If

            Else
                'Empty tasks combo

                'MsgBox("Empty tasks list")
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

        If AutoSelProjectReg = "True" Then

            task.SelectedIndex = itemindex
            flaglasttask = False

        End If

    End Sub

    Private Sub task_SelectedIndexChanged(sender As Object, e As EventArgs) Handles task.SelectedIndexChanged
        Dim key As String = DirectCast(task.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim value As String = DirectCast(task.SelectedItem, KeyValuePair(Of String, String)).Value

        'MsgBox(key + " : " + value)
        If flaglasttask = False Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "LastTask", key)
        End If

        If key <> "" Then
            taskdetailslink.Visible = True
        Else
            taskdetailslink.Visible = False
        End If

    End Sub

    Private Sub syncact_Tick(sender As Object, e As EventArgs) Handles syncact.Tick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub autostart_CheckedChanged(sender As Object, e As EventArgs) Handles autostart.CheckedChanged
        Dim applicationName As String = Application.ProductName
        Dim applicationPath As String = Application.ExecutablePath

        'MsgBox(autostart.Checked)

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
                MsgBox("I'm here in your Systray for your help!")
                systrayalert = False
            End If

            Me.WindowState = FormWindowState.Minimized
            e.Cancel = True

            ShowInTaskbar = False

        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        System.Diagnostics.Process.Start(shorturl & "supprt")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        System.Diagnostics.Process.Start(shorturl & "gvfdbk")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If systrayalert = True Then
            MsgBox("I'm here in your Systray for your help!")
            systrayalert = False
        End If
        Me.WindowState = 1
        ShowInTaskbar = False

    End Sub

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        scrnsvr.Enabled = False
        inactivitylogs.Enabled = False
        tmrGetFgWindow.Enabled = False
        allprocess.Enabled = False

        afterlogin.Visible = False
        beforelogin.Visible = True
        taskdetailslink.Visible = False

    End Sub

    Private Sub autologin_CheckedChanged(sender As Object, e As EventArgs) Handles autologin.CheckedChanged


        If autostart.Checked Then

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoLogin", autologin.Checked)

        Else

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoLogin", "")

        End If

    End Sub

    Private Sub autoselproject_CheckedChanged(sender As Object, e As EventArgs) Handles autoselproject.CheckedChanged

        If autoselproject.Checked Then

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", autoselproject.Checked)

        Else

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\DTL\EOffice\", "AutoSelProject", "")

        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(shorturl & "fptpass")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start(shorturl & "cnewact")
    End Sub

    Private Sub taskdetailslink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles taskdetailslink.LinkClicked
        Dim key As String = DirectCast(task.SelectedItem, KeyValuePair(Of String, String)).Key
        System.Diagnostics.Process.Start(shorturl & "tskdtls?cf=" & key)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        System.Diagnostics.Process.Start(shorturl & "myaccnt")
    End Sub
End Class
