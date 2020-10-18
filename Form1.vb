Public Class Form1


    Private Sub scrnsvr_Tick(sender As Object, e As EventArgs) Handles scrnsvr.Tick
        Dim lastscreensaver = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)
        ''Dim unused = MsgBox(milliseconds)

        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        screenGrab.Save("d:\screengrabs\ss_" & lastscreensaver & ".jpg")
        ''or screenGrab.Save("C:\screenGrab.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipText = "Welcome to TutorialsPanel.com!!"
        NotifyIcon1.BalloonTipTitle = "Welcome Message"
        NotifyIcon1.ShowBalloonTip(2000)
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            'NotifyIcon1.Icon = SystemIcons.Application
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.BalloonTipTitle = "Verificador corriendo"
            NotifyIcon1.BalloonTipText = "Verificador corriendo"
            NotifyIcon1.ShowBalloonTip(50000)
            'Me.Hide()
            ShowInTaskbar = False
        End If
    End Sub


    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        'Me.Show()
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

    End Sub
End Class



