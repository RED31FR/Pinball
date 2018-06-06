<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPlayField
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
        Me.UserControlLaneRight = New Pinball.UserControlLane()
        Me.UserControlLaneLeft = New Pinball.UserControlLane()
        Me.UserControlLaneRightExit = New Pinball.UserControlLane()
        Me.UserControlLaneLeftExit = New Pinball.UserControlLane()
        Me.UserControlSwitchSlingshotRight = New Pinball.UserControlSwitch()
        Me.UserControlSwitchSlingshotLeft = New Pinball.UserControlSwitch()
        Me.UserControlSwitchBallExit = New Pinball.UserControlSwitch()
        Me.UserControlBumper3 = New Pinball.UserControlBumper()
        Me.UserControlBumper2 = New Pinball.UserControlBumper()
        Me.UserControlBumper1 = New Pinball.UserControlBumper()
        Me.UserControlLanes1 = New Pinball.UserControlLanes()
        Me.UserControlTargets1 = New Pinball.UserControlTargets()
        Me.SuspendLayout()
        '
        'UserControlLaneRight
        '
        Me.UserControlLaneRight.Lane = Nothing
        Me.UserControlLaneRight.Location = New System.Drawing.Point(415, 644)
        Me.UserControlLaneRight.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlLaneRight.Name = "UserControlLaneRight"
        Me.UserControlLaneRight.Size = New System.Drawing.Size(30, 120)
        Me.UserControlLaneRight.TabIndex = 13
        '
        'UserControlLaneLeft
        '
        Me.UserControlLaneLeft.Lane = Nothing
        Me.UserControlLaneLeft.Location = New System.Drawing.Point(67, 644)
        Me.UserControlLaneLeft.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlLaneLeft.Name = "UserControlLaneLeft"
        Me.UserControlLaneLeft.Size = New System.Drawing.Size(30, 120)
        Me.UserControlLaneLeft.TabIndex = 13
        '
        'UserControlLaneRightExit
        '
        Me.UserControlLaneRightExit.Lane = Nothing
        Me.UserControlLaneRightExit.Location = New System.Drawing.Point(463, 684)
        Me.UserControlLaneRightExit.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlLaneRightExit.Name = "UserControlLaneRightExit"
        Me.UserControlLaneRightExit.Size = New System.Drawing.Size(30, 120)
        Me.UserControlLaneRightExit.TabIndex = 12
        '
        'UserControlLaneLeftExit
        '
        Me.UserControlLaneLeftExit.Lane = Nothing
        Me.UserControlLaneLeftExit.Location = New System.Drawing.Point(16, 684)
        Me.UserControlLaneLeftExit.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlLaneLeftExit.Name = "UserControlLaneLeftExit"
        Me.UserControlLaneLeftExit.Size = New System.Drawing.Size(30, 120)
        Me.UserControlLaneLeftExit.TabIndex = 12
        '
        'UserControlSwitchSlingshotRight
        '
        Me.UserControlSwitchSlingshotRight.Location = New System.Drawing.Point(367, 684)
        Me.UserControlSwitchSlingshotRight.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlSwitchSlingshotRight.Name = "UserControlSwitchSlingshotRight"
        Me.UserControlSwitchSlingshotRight.Size = New System.Drawing.Size(40, 37)
        Me.UserControlSwitchSlingshotRight.Switch = Nothing
        Me.UserControlSwitchSlingshotRight.TabIndex = 11
        '
        'UserControlSwitchSlingshotLeft
        '
        Me.UserControlSwitchSlingshotLeft.Location = New System.Drawing.Point(115, 684)
        Me.UserControlSwitchSlingshotLeft.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlSwitchSlingshotLeft.Name = "UserControlSwitchSlingshotLeft"
        Me.UserControlSwitchSlingshotLeft.Size = New System.Drawing.Size(40, 37)
        Me.UserControlSwitchSlingshotLeft.Switch = Nothing
        Me.UserControlSwitchSlingshotLeft.TabIndex = 10
        '
        'UserControlSwitchBallExit
        '
        Me.UserControlSwitchBallExit.Location = New System.Drawing.Point(240, 848)
        Me.UserControlSwitchBallExit.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlSwitchBallExit.Name = "UserControlSwitchBallExit"
        Me.UserControlSwitchBallExit.Size = New System.Drawing.Size(40, 37)
        Me.UserControlSwitchBallExit.Switch = Nothing
        Me.UserControlSwitchBallExit.TabIndex = 9
        '
        'UserControlBumper3
        '
        Me.UserControlBumper3.Bumper = Nothing
        Me.UserControlBumper3.Location = New System.Drawing.Point(327, 341)
        Me.UserControlBumper3.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlBumper3.Name = "UserControlBumper3"
        Me.UserControlBumper3.Size = New System.Drawing.Size(60, 60)
        Me.UserControlBumper3.TabIndex = 4
        '
        'UserControlBumper2
        '
        Me.UserControlBumper2.Bumper = Nothing
        Me.UserControlBumper2.Location = New System.Drawing.Point(220, 244)
        Me.UserControlBumper2.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlBumper2.Name = "UserControlBumper2"
        Me.UserControlBumper2.Size = New System.Drawing.Size(60, 60)
        Me.UserControlBumper2.TabIndex = 3
        '
        'UserControlBumper1
        '
        Me.UserControlBumper1.Bumper = Nothing
        Me.UserControlBumper1.Location = New System.Drawing.Point(115, 341)
        Me.UserControlBumper1.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlBumper1.Name = "UserControlBumper1"
        Me.UserControlBumper1.Size = New System.Drawing.Size(60, 60)
        Me.UserControlBumper1.TabIndex = 2
        '
        'UserControlLanes1
        '
        Me.UserControlLanes1.Lanes = Nothing
        Me.UserControlLanes1.Location = New System.Drawing.Point(160, 10)
        Me.UserControlLanes1.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlLanes1.Name = "UserControlLanes1"
        Me.UserControlLanes1.Size = New System.Drawing.Size(358, 185)
        Me.UserControlLanes1.TabIndex = 1
        '
        'UserControlTargets1
        '
        Me.UserControlTargets1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.UserControlTargets1.Location = New System.Drawing.Point(115, 439)
        Me.UserControlTargets1.Margin = New System.Windows.Forms.Padding(5)
        Me.UserControlTargets1.Name = "UserControlTargets1"
        Me.UserControlTargets1.Size = New System.Drawing.Size(292, 79)
        Me.UserControlTargets1.TabIndex = 0
        Me.UserControlTargets1.Targets = Nothing
        '
        'FormPlayField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(628, 864)
        Me.Controls.Add(Me.UserControlLaneRight)
        Me.Controls.Add(Me.UserControlLaneLeft)
        Me.Controls.Add(Me.UserControlLaneRightExit)
        Me.Controls.Add(Me.UserControlLaneLeftExit)
        Me.Controls.Add(Me.UserControlSwitchSlingshotRight)
        Me.Controls.Add(Me.UserControlSwitchSlingshotLeft)
        Me.Controls.Add(Me.UserControlSwitchBallExit)
        Me.Controls.Add(Me.UserControlBumper3)
        Me.Controls.Add(Me.UserControlBumper2)
        Me.Controls.Add(Me.UserControlBumper1)
        Me.Controls.Add(Me.UserControlLanes1)
        Me.Controls.Add(Me.UserControlTargets1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormPlayField"
        Me.Text = "FormPlayField"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserControlTargets1 As UserControlTargets
    Friend WithEvents UserControlLanes1 As UserControlLanes
    Friend WithEvents UserControlBumper1 As UserControlBumper
    Friend WithEvents UserControlBumper2 As UserControlBumper
    Friend WithEvents UserControlBumper3 As UserControlBumper
    Friend WithEvents UserControlSwitchBallExit As UserControlSwitch
    Friend WithEvents UserControlSwitchSlingshotLeft As UserControlSwitch
    Friend WithEvents UserControlSwitchSlingshotRight As UserControlSwitch
    Friend WithEvents UserControlLaneLeftExit As UserControlLane
    Friend WithEvents UserControlLaneLeft As UserControlLane
    Friend WithEvents UserControlLaneRightExit As UserControlLane
    Friend WithEvents UserControlLaneRight As UserControlLane
End Class
