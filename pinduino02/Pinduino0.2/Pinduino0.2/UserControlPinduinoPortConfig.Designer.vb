<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlPinduinoPortConfig
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Input = New System.Windows.Forms.RadioButton()
        Me.Output = New System.Windows.Forms.RadioButton()
        Me.PortNumber = New System.Windows.Forms.ComboBox()
        Me.CharCode = New System.Windows.Forms.TextBox()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Input
        '
        Me.Input.AutoSize = True
        Me.Input.Checked = True
        Me.Input.Location = New System.Drawing.Point(3, 3)
        Me.Input.Name = "Input"
        Me.Input.Size = New System.Drawing.Size(49, 17)
        Me.Input.TabIndex = 0
        Me.Input.TabStop = True
        Me.Input.Text = "Input"
        Me.Input.UseVisualStyleBackColor = True
        '
        'Output
        '
        Me.Output.AutoSize = True
        Me.Output.Location = New System.Drawing.Point(3, 26)
        Me.Output.Name = "Output"
        Me.Output.Size = New System.Drawing.Size(57, 17)
        Me.Output.TabIndex = 1
        Me.Output.TabStop = True
        Me.Output.Text = "Output"
        Me.Output.UseVisualStyleBackColor = True
        '
        'PortNumber
        '
        Me.PortNumber.FormattingEnabled = True
        Me.PortNumber.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53"})
        Me.PortNumber.Location = New System.Drawing.Point(66, 3)
        Me.PortNumber.Name = "PortNumber"
        Me.PortNumber.Size = New System.Drawing.Size(121, 21)
        Me.PortNumber.TabIndex = 2
        '
        'CharCode
        '
        Me.CharCode.Location = New System.Drawing.Point(194, 3)
        Me.CharCode.Name = "CharCode"
        Me.CharCode.Size = New System.Drawing.Size(31, 20)
        Me.CharCode.TabIndex = 3
        Me.CharCode.Text = "a"
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Location = New System.Drawing.Point(232, 3)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAdd.TabIndex = 4
        Me.ButtonAdd.Text = "Add"
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'UserControlPinduinoPortConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ButtonAdd)
        Me.Controls.Add(Me.CharCode)
        Me.Controls.Add(Me.PortNumber)
        Me.Controls.Add(Me.Output)
        Me.Controls.Add(Me.Input)
        Me.Name = "UserControlPinduinoPortConfig"
        Me.Size = New System.Drawing.Size(317, 48)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Input As RadioButton
    Friend WithEvents Output As RadioButton
    Friend WithEvents PortNumber As ComboBox
    Friend WithEvents CharCode As TextBox
    Friend WithEvents ButtonAdd As Button
End Class
