<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RMCCM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RMCCM))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMinecraftPath = New System.Windows.Forms.TextBox()
        Me.btnChooseCustomDirectory = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnStartPatching = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Minecraft-Path"
        '
        'txtMinecraftPath
        '
        Me.txtMinecraftPath.Location = New System.Drawing.Point(88, 13)
        Me.txtMinecraftPath.Name = "txtMinecraftPath"
        Me.txtMinecraftPath.ReadOnly = True
        Me.txtMinecraftPath.Size = New System.Drawing.Size(353, 20)
        Me.txtMinecraftPath.TabIndex = 1
        Me.txtMinecraftPath.TabStop = False
        '
        'btnChooseCustomDirectory
        '
        Me.btnChooseCustomDirectory.Location = New System.Drawing.Point(449, 12)
        Me.btnChooseCustomDirectory.Name = "btnChooseCustomDirectory"
        Me.btnChooseCustomDirectory.Size = New System.Drawing.Size(155, 23)
        Me.btnChooseCustomDirectory.TabIndex = 2
        Me.btnChooseCustomDirectory.Text = "Choose custom directory"
        Me.btnChooseCustomDirectory.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMinecraftPath)
        Me.GroupBox1.Controls.Add(Me.btnChooseCustomDirectory)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 39)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuration"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ProgressBar)
        Me.GroupBox2.Controls.Add(Me.btnStartPatching)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(610, 80)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Load Mods"
        '
        'btnStartPatching
        '
        Me.btnStartPatching.Location = New System.Drawing.Point(9, 19)
        Me.btnStartPatching.Name = "btnStartPatching"
        Me.btnStartPatching.Size = New System.Drawing.Size(595, 23)
        Me.btnStartPatching.TabIndex = 3
        Me.btnStartPatching.Text = "Start patching"
        Me.btnStartPatching.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(9, 48)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(595, 26)
        Me.ProgressBar.TabIndex = 4
        '
        'RMCCM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 145)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(649, 184)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(649, 184)
        Me.Name = "RMCCM"
        Me.Text = "RMCCM"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMinecraftPath As System.Windows.Forms.TextBox
    Friend WithEvents btnChooseCustomDirectory As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStartPatching As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar

End Class
