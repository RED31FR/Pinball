<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDMD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UserControlCPinball1 = New Pinball.UserControlCPinball()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'UserControlCPinball1
        '
        Me.UserControlCPinball1.Location = New System.Drawing.Point(0, 0)
        Me.UserControlCPinball1.Name = "UserControlCPinball1"
        Me.UserControlCPinball1.PinballDMD = Nothing
        Me.UserControlCPinball1.Size = New System.Drawing.Size(164, 191)
        Me.UserControlCPinball1.TabIndex = 0
        '
        'FormDMD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.UserControlCPinball1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.KeyPreview = True
        Me.Name = "FormDMD"
        Me.Text = "FormDMD"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserControlCPinball1 As UserControlCPinball
    Friend WithEvents Timer1 As Timer
End Class
