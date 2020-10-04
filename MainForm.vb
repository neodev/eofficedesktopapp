Public Class MainForm

    Public Sub New()
        InitializeTrayComponent()
        Icon = My.Resources.TrayIcon
    End Sub

    Private Sub InitializeTrayComponent()
        Me.SuspendLayout()
        '
        'MainForm
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Name = "MainForm"
        Me.ResumeLayout(False)

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub InitializeComponent()
    '    Me.SuspendLayout()
    '    '
    '    'MainForm
    '    '
    '    Me.ClientSize = New System.Drawing.Size(284, 261)
    '    Me.Name = "MainForm"
    '    Me.ResumeLayout(False)

    'End Sub

    Private Sub MainForm_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class