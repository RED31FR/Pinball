<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDMD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.UserControlCPinball1 = New Pinball.UserControlCPinball()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'SerialPort2
        '
        Me.SerialPort2.BaudRate = 115200
        Me.SerialPort2.PortName = "COM4"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(981, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Open Pinduino"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(981, 101)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(149, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Init Pinduino"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(981, 130)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(149, 20)
        Me.TextBox1.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(981, 42)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(149, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Close Pinduino"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(981, 157)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(149, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Run Command"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(981, 72)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(149, 23)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Start Run Mode"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'UserControlCPinball1
        '
        Me.UserControlCPinball1.Location = New System.Drawing.Point(0, 0)
        Me.UserControlCPinball1.Margin = New System.Windows.Forms.Padding(4)
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
        Me.ClientSize = New System.Drawing.Size(1142, 362)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UserControlCPinball1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.KeyPreview = True
        Me.Name = "FormDMD"
        Me.Text = "FormDMD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UserControlCPinball1 As UserControlCPinball
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SerialPort2 As IO.Ports.SerialPort
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
