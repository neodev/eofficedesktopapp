﻿Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Text

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




    Private Sub scrnsvr_Tick(sender As Object, e As EventArgs) Handles scrnsvr.Tick

        'Dim lastscreensaver = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)

        Dim seconds As Long = DateDiff(DateInterval.Second, lastscreensaver, Now)

        Console.WriteLine(seconds)

        If (seconds > minsec) Then
            ''Dim unused = MsgBox(milliseconds)

            Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
            screenGrab.Save("d:\screengrabs\MS" & CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds) & ".jpg")
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
        list_item.SubItems.Add(fg_wndttle)

        'Take screenshot if active window is changed
        lastscreensaver = Now

        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        screenGrab.Save("d:\screengrabs\WC" & CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds) & ".jpg")

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
        'NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        'NotifyIcon1.BalloonTipText = "I'm here in your Sys tray for your help!"
        'NotifyIcon1.BalloonTipTitle = "Happy Coding!"
        'NotifyIcon1.ShowBalloonTip(2000)
        _inactiveTimeRetriever = New cIdleTimeStool
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
            ShowInTaskbar = False
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

        ' Dim httpClient = New HttpClient()

        'Dim req As New Chilkat.HttpRequest


        'Dim postData As String = "referer=https%3A%2F%2Ffaketestjson.herokuapp.com?un=" & TextBox1.Text & "&pw=" & TextBox2.Text
        'Dim postData As String = "https%3A%2F%2Ffaketestjson.herokuapp.com?un=" & TextBox1.Text & "&pw=" & TextBox2.Text
        Dim postData As String = "un=" & TextBox1.Text & "&pw=" & TextBox2.Text

        MsgBox(postData)
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

    End Sub



    Public Function HaveInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebBrowser1.DocumentText = RichTextBox1.Text
    End Sub
End Class
