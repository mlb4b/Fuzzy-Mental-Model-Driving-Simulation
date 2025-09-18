<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        lblDriveMode = New Label()
        picWheel = New PictureBox()
        picShifter = New PictureBox()
        timerAnimation = New Timer(components)
        picAnimation = New PictureBox()
        Button1 = New Button()
        PictureBox1 = New PictureBox()
        lblInstructions = New Label()
        Button2 = New Button()
        CType(picWheel, ComponentModel.ISupportInitialize).BeginInit()
        CType(picShifter, ComponentModel.ISupportInitialize).BeginInit()
        CType(picAnimation, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblDriveMode
        ' 
        lblDriveMode.AutoSize = True
        lblDriveMode.Location = New Point(1981, 547)
        lblDriveMode.Name = "lblDriveMode"
        lblDriveMode.Size = New Size(27, 32)
        lblDriveMode.TabIndex = 0
        lblDriveMode.Text = "P"
        lblDriveMode.Visible = False
        ' 
        ' picWheel
        ' 
        picWheel.Image = My.Resources.Resources.car_160115_1280
        picWheel.Location = New Point(48, 517)
        picWheel.Name = "picWheel"
        picWheel.Size = New Size(1280, 1277)
        picWheel.SizeMode = PictureBoxSizeMode.AutoSize
        picWheel.TabIndex = 1
        picWheel.TabStop = False
        ' 
        ' picShifter
        ' 
        picShifter.Image = My.Resources.Resources.shifter
        picShifter.Location = New Point(1370, 777)
        picShifter.Name = "picShifter"
        picShifter.Size = New Size(539, 326)
        picShifter.SizeMode = PictureBoxSizeMode.AutoSize
        picShifter.TabIndex = 2
        picShifter.TabStop = False
        ' 
        ' timerAnimation
        ' 
        timerAnimation.Enabled = True
        timerAnimation.Interval = 25
        ' 
        ' picAnimation
        ' 
        picAnimation.Image = My.Resources.Resources.r10
        picAnimation.Location = New Point(-716, 1)
        picAnimation.Name = "picAnimation"
        picAnimation.Size = New Size(3644, 510)
        picAnimation.SizeMode = PictureBoxSizeMode.StretchImage
        picAnimation.TabIndex = 3
        picAnimation.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(1558, 559)
        Button1.Name = "Button1"
        Button1.Size = New Size(118, 55)
        Button1.TabIndex = 4
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(905, 645)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(423, 458)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' lblInstructions
        ' 
        lblInstructions.BackColor = SystemColors.GradientInactiveCaption
        lblInstructions.BorderStyle = BorderStyle.FixedSingle
        lblInstructions.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblInstructions.Location = New Point(981, 806)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Size = New Size(273, 136)
        lblInstructions.TabIndex = 6
        lblInstructions.Text = "Wait for instructions"
        lblInstructions.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(1713, 558)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 56)
        Button2.TabIndex = 7
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2059, 1333)
        Controls.Add(Button2)
        Controls.Add(lblInstructions)
        Controls.Add(PictureBox1)
        Controls.Add(Button1)
        Controls.Add(picAnimation)
        Controls.Add(picShifter)
        Controls.Add(picWheel)
        Controls.Add(lblDriveMode)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmMain"
        CType(picWheel, ComponentModel.ISupportInitialize).EndInit()
        CType(picShifter, ComponentModel.ISupportInitialize).EndInit()
        CType(picAnimation, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblDriveMode As Label
    Friend WithEvents picWheel As PictureBox
    Friend WithEvents picShifter As PictureBox
    Friend WithEvents timerAnimation As Timer
    Friend WithEvents picAnimation As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblInstructions As Label
    Friend WithEvents Button2 As Button

End Class
