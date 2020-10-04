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

End Class
