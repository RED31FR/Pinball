<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControlPinduinoControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ButtonRunMode = New System.Windows.Forms.Button()
        Me.ButtonSetupMode = New System.Windows.Forms.Button()
        Me.ButtonOpenClose = New System.Windows.Forms.Button()
        Me.ButtonSendCommand = New System.Windows.Forms.Button()
        Me.CommandLine = New System.Windows.Forms.TextBox()
        Me.SerialReport = New System.Windows.Forms.RichTextBox()
        Me.CheckBoxAutoStart = New System.Windows.Forms.CheckBox()
        Me.ButtonLoad = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.UserControlPinduinoPortConfig1 = New Pinduino0._2.UserControlPinduinoPortConfig()
        Me.SuspendLayout()
        '
        'ButtonRunMode
        '
        Me.ButtonRunMode.Enabled = False
        Me.ButtonRunMode.Location = New System.Drawing.Point(614, 30)
        Me.ButtonRunMode.Name = "ButtonRunMode"
        Me.ButtonRunMode.Size = New System.Drawing.Size(75, 23)
        Me.ButtonRunMode.TabIndex = 11
        Me.ButtonRunMode.Text = "Run mode"
        Me.ButtonRunMode.UseVisualStyleBackColor = True
        '
        'ButtonSetupMode
        '
        Me.ButtonSetupMode.Enabled = False
        Me.ButtonSetupMode.Location = New System.Drawing.Point(458, 30)
        Me.ButtonSetupMode.Name = "ButtonSetupMode"
        Me.ButtonSetupMode.Size = New System.Drawing.Size(150, 23)
        Me.ButtonSetupMode.TabIndex = 10
        Me.ButtonSetupMode.Text = "Setup mode (CLEAR config)"
        Me.ButtonSetupMode.UseVisualStyleBackColor = True
        '
        'ButtonOpenClose
        '
        Me.ButtonOpenClose.Location = New System.Drawing.Point(376, 31)
        Me.ButtonOpenClose.Name = "ButtonOpenClose"
        Me.ButtonOpenClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpenClose.TabIndex = 9
        Me.ButtonOpenClose.Text = "Open"
        Me.ButtonOpenClose.UseVisualStyleBackColor = True
        '
        'ButtonSendCommand
        '
        Me.ButtonSendCommand.Enabled = False
        Me.ButtonSendCommand.Location = New System.Drawing.Point(695, 30)
        Me.ButtonSendCommand.Name = "ButtonSendCommand"
        Me.ButtonSendCommand.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSendCommand.TabIndex = 8
        Me.ButtonSendCommand.Text = "Send"
        Me.ButtonSendCommand.UseVisualStyleBackColor = True
        '
        'CommandLine
        '
        Me.CommandLine.Location = New System.Drawing.Point(376, 4)
        Me.CommandLine.Name = "CommandLine"
        Me.CommandLine.Size = New System.Drawing.Size(394, 20)
        Me.CommandLine.TabIndex = 7
        '
        'SerialReport
        '
        Me.SerialReport.Location = New System.Drawing.Point(3, 3)
        Me.SerialReport.Name = "SerialReport"
        Me.SerialReport.Size = New System.Drawing.Size(366, 373)
        Me.SerialReport.TabIndex = 6
        Me.SerialReport.Text = ""
        '
        'CheckBoxAutoStart
        '
        Me.CheckBoxAutoStart.AutoSize = True
        Me.CheckBoxAutoStart.Location = New System.Drawing.Point(695, 60)
        Me.CheckBoxAutoStart.Name = "CheckBoxAutoStart"
        Me.CheckBoxAutoStart.Size = New System.Drawing.Size(70, 17)
        Me.CheckBoxAutoStart.TabIndex = 13
        Me.CheckBoxAutoStart.Text = "AutoStart"
        Me.CheckBoxAutoStart.UseVisualStyleBackColor = True
        '
        'ButtonLoad
        '
        Me.ButtonLoad.Enabled = False
        Me.ButtonLoad.Location = New System.Drawing.Point(690, 320)
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLoad.TabIndex = 14
        Me.ButtonLoad.Text = "Load..."
        Me.ButtonLoad.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Enabled = False
        Me.ButtonSave.Location = New System.Drawing.Point(690, 349)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSave.TabIndex = 15
        Me.ButtonSave.Text = "Save..."
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'UserControlPinduinoPortConfig1
        '
        Me.UserControlPinduinoPortConfig1.Enabled = False
        Me.UserControlPinduinoPortConfig1.Location = New System.Drawing.Point(376, 60)
        Me.UserControlPinduinoPortConfig1.Name = "UserControlPinduinoPortConfig1"
        Me.UserControlPinduinoPortConfig1.Size = New System.Drawing.Size(319, 48)
        Me.UserControlPinduinoPortConfig1.TabIndex = 12
        '
        'UserControlPinduinoControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonLoad)
        Me.Controls.Add(Me.CheckBoxAutoStart)
        Me.Controls.Add(Me.UserControlPinduinoPortConfig1)
        Me.Controls.Add(Me.ButtonRunMode)
        Me.Controls.Add(Me.ButtonSetupMode)
        Me.Controls.Add(Me.ButtonOpenClose)
        Me.Controls.Add(Me.ButtonSendCommand)
        Me.Controls.Add(Me.CommandLine)
        Me.Controls.Add(Me.SerialReport)
        Me.Name = "UserControlPinduinoControl"
        Me.Size = New System.Drawing.Size(773, 385)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonRunMode As Button
    Friend WithEvents ButtonSetupMode As Button
    Friend WithEvents ButtonOpenClose As Button
    Friend WithEvents ButtonSendCommand As Button
    Friend WithEvents CommandLine As TextBox
    Friend WithEvents SerialReport As RichTextBox
    Friend WithEvents UserControlPinduinoPortConfig1 As UserControlPinduinoPortConfig
    Friend WithEvents CheckBoxAutoStart As CheckBox
    Friend WithEvents ButtonLoad As Button
    Friend WithEvents ButtonSave As Button
End Class
