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
        picWheel = New PictureBox()
        picShifter = New PictureBox()
        timerAnimation = New Timer(components)
        picAnimation = New PictureBox()
        PictureBox1 = New PictureBox()
        lblInstructions = New Label()
        groupDebug = New GroupBox()
        TextBox1 = New TextBox()
        Button3 = New Button()
        Button2 = New Button()
        Button6 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        Button1 = New Button()
        lblSelected = New Label()
        lblAssigned = New Label()
        lblDriveMode = New Label()
        lblStartAt = New Label()
        Label1 = New Label()
        CType(picWheel, ComponentModel.ISupportInitialize).BeginInit()
        CType(picShifter, ComponentModel.ISupportInitialize).BeginInit()
        CType(picAnimation, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        groupDebug.SuspendLayout()
        SuspendLayout()
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
        lblInstructions.Font = New Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblInstructions.Location = New Point(981, 818)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Size = New Size(273, 194)
        lblInstructions.TabIndex = 6
        lblInstructions.TextAlign = ContentAlignment.TopCenter
        ' 
        ' groupDebug
        ' 
        groupDebug.Controls.Add(TextBox1)
        groupDebug.Controls.Add(Button3)
        groupDebug.Controls.Add(Button2)
        groupDebug.Controls.Add(Button6)
        groupDebug.Controls.Add(Button5)
        groupDebug.Controls.Add(Button4)
        groupDebug.Controls.Add(Button1)
        groupDebug.Controls.Add(lblSelected)
        groupDebug.Controls.Add(lblAssigned)
        groupDebug.Controls.Add(lblDriveMode)
        groupDebug.Location = New Point(1351, 517)
        groupDebug.Name = "groupDebug"
        groupDebug.Size = New Size(696, 254)
        groupDebug.TabIndex = 9
        groupDebug.TabStop = False
        groupDebug.Text = "groupDebug"
        groupDebug.Visible = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(401, 122)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(268, 103)
        TextBox1.TabIndex = 16
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(139, 48)
        Button3.Name = "Button3"
        Button3.Size = New Size(112, 56)
        Button3.TabIndex = 14
        Button3.Text = "FuzzyInput"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(257, 48)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 56)
        Button2.TabIndex = 15
        Button2.Text = "Enqueue"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(257, 122)
        Button6.Name = "Button6"
        Button6.Size = New Size(118, 55)
        Button6.TabIndex = 10
        Button6.Text = "Surprise"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(139, 122)
        Button5.Name = "Button5"
        Button5.Size = New Size(112, 55)
        Button5.TabIndex = 11
        Button5.Text = "Demographics"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(15, 122)
        Button4.Name = "Button4"
        Button4.Size = New Size(118, 55)
        Button4.TabIndex = 12
        Button4.Text = "State?"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(15, 48)
        Button1.Name = "Button1"
        Button1.Size = New Size(118, 55)
        Button1.TabIndex = 13
        Button1.Text = "FuzzyState"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' lblSelected
        ' 
        lblSelected.AutoSize = True
        lblSelected.Location = New Point(605, 48)
        lblSelected.Name = "lblSelected"
        lblSelected.Size = New Size(92, 32)
        lblSelected.TabIndex = 9
        lblSelected.Text = "(P) Park"
        ' 
        ' lblAssigned
        ' 
        lblAssigned.AutoSize = True
        lblAssigned.Location = New Point(507, 48)
        lblAssigned.Name = "lblAssigned"
        lblAssigned.Size = New Size(92, 32)
        lblAssigned.TabIndex = 9
        lblAssigned.Text = "(P) Park"
        ' 
        ' lblDriveMode
        ' 
        lblDriveMode.AutoSize = True
        lblDriveMode.Location = New Point(409, 48)
        lblDriveMode.Name = "lblDriveMode"
        lblDriveMode.Size = New Size(92, 32)
        lblDriveMode.TabIndex = 9
        lblDriveMode.Text = "(P) Park"
        ' 
        ' lblStartAt
        ' 
        lblStartAt.BackColor = SystemColors.GradientInactiveCaption
        lblStartAt.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStartAt.Location = New Point(981, 729)
        lblStartAt.Name = "lblStartAt"
        lblStartAt.Size = New Size(273, 68)
        lblStartAt.TabIndex = 6
        lblStartAt.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.BackColor = SystemColors.GradientInactiveCaption
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(981, 797)
        Label1.Name = "Label1"
        Label1.Size = New Size(273, 21)
        Label1.TabIndex = 6
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(2059, 1333)
        Controls.Add(groupDebug)
        Controls.Add(Label1)
        Controls.Add(lblStartAt)
        Controls.Add(lblInstructions)
        Controls.Add(PictureBox1)
        Controls.Add(picAnimation)
        Controls.Add(picShifter)
        Controls.Add(picWheel)
        FormBorderStyle = FormBorderStyle.FixedDialog
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmMain"
        CType(picWheel, ComponentModel.ISupportInitialize).EndInit()
        CType(picShifter, ComponentModel.ISupportInitialize).EndInit()
        CType(picAnimation, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        groupDebug.ResumeLayout(False)
        groupDebug.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents picWheel As PictureBox
    Friend WithEvents picShifter As PictureBox
    Friend WithEvents timerAnimation As Timer
    Friend WithEvents picAnimation As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblInstructions As Label
    Friend WithEvents groupDebug As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lblDriveMode As Label
    Friend WithEvents lblAssigned As Label
    Friend WithEvents lblSelected As Label
    Friend WithEvents lblStartAt As Label
    Friend WithEvents Label1 As Label

End Class
