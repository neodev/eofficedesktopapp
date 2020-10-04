Public Class Form1

    Inherits System.Windows.Forms.Form

    Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As Integer
    Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As Integer) As Integer
    Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer


    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
    Private Declare Function GetActiveWindow Lib "user32.dll" () As Long

    Dim AppHwnd As String
    Dim lastWindowTitle As String
    Dim lastprocessId As String

    Dim ssxsecs As Boolean = False
    Dim actprcss As Boolean = False
    Dim mingap As Integer = 2
    'Dim startTime As New DateTime(Now.ToString("dd:MM:yy hh:mm:ss"))    ' 10:30 AM today
    Dim startTime As Date = Date.Now


    ' The hWnd and title of the most recently found window.
    Private m_LastHwnd As Integer
    Private m_LastWndTile As String
    Public Sub New()
        'Turn visual styles back on
        Application.EnableVisualStyles()

        'Run the application using AppContext
        Application.Run(New AppContext)

        ''You can also run the application using a main form
        'Application.Run(New MainForm)

        ''Or in a default context with no user interface at all
        'Application.Run()
    End Sub

    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            My.Computer.Network.Ping("www.google.com")
            Return True
        Catch
            Return False
        End Try
    End Function



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


    'Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr

    Private Declare Function GetWindowRect Lib "user32" _
                (ByVal hwnd As IntPtr,
                ByRef lpRect As RECT) _
                As Integer

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        AppHwnd = Space(255)
        GetActiveWindow.ToString()
        'Dim Caption = GetWindowText(GetActiveWindow, AppHwnd, Len(AppHwnd)) & "-" & GetActiveWindow & "-" & AppHwnd & "-" & Len(AppHwnd)
        MsgBox(GetActiveWindow.ToString())

        lstboxhandels.Items.Add(GetActiveWindow.ToString())


        'Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        'Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        'Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
        'g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        'screenGrab.Save("d:\screenGrab.jpg")
        'or screenGrab.Save("C:\screenGrab.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

        'Dim r As New RECT
        'GetWindowRect(GetActiveWindow, r)
        'Dim img As New Bitmap(r.Right - r.Left, r.Bottom - r.Top)
        'Dim gr As Graphics = Graphics.FromImage(img)
        'gr.CopyFromScreen(New Point(r.Left, r.Top), Point.Empty, img.Size)

        'img.Save("d:\grabtest.png")
        ''Process.Start("d:\grabtest.png")



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim milliseconds = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)
        ''Dim unused = MsgBox(milliseconds)

        'Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        'Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        'Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
        'g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        'screenGrab.Save("d:\screengrabs\" & milliseconds & ".jpg")
        ''or screenGrab.Save("C:\screenGrab.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim r As New RECT
        Dim unused = GetWindowRect(GetActiveWindow, r)
        Dim img As New Bitmap(r.Right - r.Left, r.Bottom - r.Top)
        Dim gr As Graphics = Graphics.FromImage(img)
        gr.CopyFromScreen(New Point(r.Left, r.Top), Point.Empty, img.Size)

        img.Save("d:\screengrabs\active_" & milliseconds & ".jpg")
        'Process.Start("d:\screengrabs\active_" & milliseconds & ".jpg")


    End Sub

    Private Sub scrnsvr_Tick(sender As Object, e As EventArgs) Handles scrnsvr.Tick


        ' Dim endTime As New DateTime(2020, 1, 1, 13, 25, 6)

        'Dim duration As TimeSpan = endTime - startTime        'Subtract start time from end time


        Dim totalgap As Integer = DateTime.Now.Subtract(startTime).TotalMinutes



        If ssxsecs Or totalgap > mingap Then
            Dim lastscreensaver = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)
            ''Dim unused = MsgBox(milliseconds)

            Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
            screenGrab.Save("d:\screengrabs\ss_" & lastscreensaver & ".jpg")
            ''or screenGrab.Save("C:\screenGrab.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            ssxsecs = False

            ' Console.WriteLine(DateTime.Now.Subtract(startTime).TotalMinutes)

            ' MsgBox(startTime)


            startTime = Date.Now

        End If


    End Sub

    Private Sub ButGetAllPorccess_Click(sender As Object, e As EventArgs) Handles ButGetAllPorccess.Click
        'Clear Listboxs
        lstboxhandels.Items.Clear()
        LstBoxHWNDCaptions.Items.Clear()

        Dim p As Process


        For Each p In Process.GetProcesses(System.Environment.MachineName)
            'Only add proccess that there HWND is not 0
            If p.MainWindowHandle.ToString <> IntPtr.Zero.ToString Then
                lstboxhandels.Items.Add(p.MainWindowHandle.ToString)
                LstBoxHWNDCaptions.Items.Add(p.MainWindowTitle.ToString)
            End If
        Next p
    End Sub

    Private Sub actvprcs_Tick(sender As Object, e As EventArgs) Handles actvprcs.Tick

        If actprcss Then

            lstboxhandels.Items.Clear()
            LstBoxHWNDCaptions.Items.Clear()

            Dim p As Process
            Dim pl As String
            pl = ""

            Dim fileName As String
            Dim fileDescription As String
            Dim ProductName As String
            Dim processName As String
            Dim windowTitle As String

            'Process foregroundProcess = Process.GetProcessById(processId);

            For Each p In Process.GetProcesses(System.Environment.MachineName)
                'Only add proccess that there HWND is not 0
                If p.MainWindowHandle.ToString <> IntPtr.Zero.ToString Then
                    pl = pl & p.MainWindowHandle.ToString & "|"
                    pl = pl & p.MainWindowTitle.ToString & "-"



                    lstboxhandels.Items.Add(p.MainWindowHandle.ToString)
                    LstBoxHWNDCaptions.Items.Add(p.MainWindowTitle.ToString)
                End If
            Next p
            'MsgBox(pl)

            actprcss = False

        End If
    End Sub

    Private Sub actvwndw_Tick(sender As Object, e As EventArgs) Handles actvwndw.Tick


        ' Get the window's handle.
        Dim fg_hwnd As Long = GetForegroundWindow()
        Dim fg_wndttle As String = GetWindowTitle(fg_hwnd)

        ' If this is the same as the previous foreground window,
        ' let that one remain the most recent entry.
        If m_LastHwnd = fg_hwnd And m_LastWndTile = fg_wndttle Then Exit Sub


        ssxsecs = True
        actprcss = True

        m_LastHwnd = fg_hwnd
        m_LastWndTile = fg_wndttle

        ' Display the time and the window's title.
        Dim list_item As System.Windows.Forms.ListViewItem
        list_item = lvwFGWindow.Items.Add(text:=Now.ToString("dd:MM:yy hh:mm:ss"))
        list_item.SubItems.Add(fg_wndttle)
        list_item.EnsureVisible()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButSendText_Click(sender As Object, e As EventArgs) Handles ButSendText.Click
        MsgBox(CheckForInternetConnection)
    End Sub

    Private Sub traffic_Tick(sender As Object, e As EventArgs) Handles traffic.Tick

        Dim ipv4Stats As System.Net.NetworkInformation.IPv4InterfaceStatistics
        'MsgBox(System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces.Length)

        ipv4Stats = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces(4).GetIPv4Statistics
        Label3.Text = ipv4Stats.BytesReceived.ToString
        Label4.Text = ipv4Stats.BytesSent.ToString




    End Sub
End Class
