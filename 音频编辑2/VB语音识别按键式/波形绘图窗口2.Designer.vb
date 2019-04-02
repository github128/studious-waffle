<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class 波形绘图窗口
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.XPosScrol = New System.Windows.Forms.HScrollBar()
        Me.FScaleScol = New System.Windows.Forms.VScrollBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbdatalen = New System.Windows.Forms.Label()
        Me.lbcurpos = New System.Windows.Forms.Label()
        Me.DataViewBox = New System.Windows.Forms.PictureBox()
        Me.lbScale = New System.Windows.Forms.Label()
        Me.lbamp = New System.Windows.Forms.Label()
        Me.lbDisplayPointCount = New System.Windows.Forms.Label()
        Me.TbSetDisPlayPoints = New System.Windows.Forms.TextBox()
        Me.BtnSetDisplayPoint = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LbSelectRegion = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.播放ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.录音ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.新建ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.显示全部ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.选择区域保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.显示区域保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全部保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FFT保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LBSelectCount = New System.Windows.Forms.Label()
        Me.lbMousePoint = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataViewBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XPosScrol
        '
        Me.XPosScrol.LargeChange = 1
        Me.XPosScrol.Location = New System.Drawing.Point(24, 269)
        Me.XPosScrol.Maximum = 0
        Me.XPosScrol.Name = "XPosScrol"
        Me.XPosScrol.Size = New System.Drawing.Size(766, 31)
        Me.XPosScrol.TabIndex = 2
        '
        'FScaleScol
        '
        Me.FScaleScol.LargeChange = 1
        Me.FScaleScol.Location = New System.Drawing.Point(805, 89)
        Me.FScaleScol.Maximum = 20
        Me.FScaleScol.Minimum = 1
        Me.FScaleScol.Name = "FScaleScol"
        Me.FScaleScol.Size = New System.Drawing.Size(21, 113)
        Me.FScaleScol.TabIndex = 9
        Me.FScaleScol.Value = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(803, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "幅值"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 315)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(874, 22)
        Me.StatusStrip1.TabIndex = 73
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel1
        '
        Me.StatusLabel1.Name = "StatusLabel1"
        Me.StatusLabel1.Size = New System.Drawing.Size(64, 17)
        Me.StatusLabel1.Text = "              "
        '
        'lbdatalen
        '
        Me.lbdatalen.AutoSize = True
        Me.lbdatalen.Location = New System.Drawing.Point(48, 235)
        Me.lbdatalen.Name = "lbdatalen"
        Me.lbdatalen.Size = New System.Drawing.Size(65, 12)
        Me.lbdatalen.TabIndex = 8
        Me.lbdatalen.Text = "数据总长："
        '
        'lbcurpos
        '
        Me.lbcurpos.AutoSize = True
        Me.lbcurpos.Location = New System.Drawing.Point(48, 214)
        Me.lbcurpos.Name = "lbcurpos"
        Me.lbcurpos.Size = New System.Drawing.Size(65, 12)
        Me.lbcurpos.TabIndex = 12
        Me.lbcurpos.Text = "当前位置："
        '
        'DataViewBox
        '
        Me.DataViewBox.Location = New System.Drawing.Point(26, 62)
        Me.DataViewBox.Name = "DataViewBox"
        Me.DataViewBox.Size = New System.Drawing.Size(765, 199)
        Me.DataViewBox.TabIndex = 0
        Me.DataViewBox.TabStop = False
        '
        'lbScale
        '
        Me.lbScale.AutoSize = True
        Me.lbScale.Location = New System.Drawing.Point(662, 190)
        Me.lbScale.Name = "lbScale"
        Me.lbScale.Size = New System.Drawing.Size(35, 12)
        Me.lbScale.TabIndex = 75
        Me.lbScale.Text = "缩放:"
        '
        'lbamp
        '
        Me.lbamp.AutoSize = True
        Me.lbamp.Location = New System.Drawing.Point(662, 214)
        Me.lbamp.Name = "lbamp"
        Me.lbamp.Size = New System.Drawing.Size(35, 12)
        Me.lbamp.TabIndex = 76
        Me.lbamp.Text = "幅度:"
        '
        'lbDisplayPointCount
        '
        Me.lbDisplayPointCount.AutoSize = True
        Me.lbDisplayPointCount.Location = New System.Drawing.Point(662, 235)
        Me.lbDisplayPointCount.Name = "lbDisplayPointCount"
        Me.lbDisplayPointCount.Size = New System.Drawing.Size(65, 12)
        Me.lbDisplayPointCount.TabIndex = 77
        Me.lbDisplayPointCount.Text = "显示点数："
        '
        'TbSetDisPlayPoints
        '
        Me.TbSetDisPlayPoints.Location = New System.Drawing.Point(95, 34)
        Me.TbSetDisPlayPoints.Name = "TbSetDisPlayPoints"
        Me.TbSetDisPlayPoints.Size = New System.Drawing.Size(106, 21)
        Me.TbSetDisPlayPoints.TabIndex = 80
        Me.TbSetDisPlayPoints.Text = "6400"
        '
        'BtnSetDisplayPoint
        '
        Me.BtnSetDisplayPoint.Location = New System.Drawing.Point(207, 34)
        Me.BtnSetDisplayPoint.Name = "BtnSetDisplayPoint"
        Me.BtnSetDisplayPoint.Size = New System.Drawing.Size(83, 21)
        Me.BtnSetDisplayPoint.TabIndex = 81
        Me.BtnSetDisplayPoint.Text = "确定"
        Me.BtnSetDisplayPoint.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "显示点数："
        '
        'LbSelectRegion
        '
        Me.LbSelectRegion.AutoSize = True
        Me.LbSelectRegion.Location = New System.Drawing.Point(287, 214)
        Me.LbSelectRegion.Name = "LbSelectRegion"
        Me.LbSelectRegion.Size = New System.Drawing.Size(65, 12)
        Me.LbSelectRegion.TabIndex = 83
        Me.LbSelectRegion.Text = "选择范围："
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.播放ToolStripMenuItem, Me.新建ToolStripMenuItem, Me.显示全部ToolStripMenuItem, Me.打开ToolStripMenuItem, Me.录音ToolStripMenuItem, Me.保存ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(874, 25)
        Me.MenuStrip1.TabIndex = 91
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '播放ToolStripMenuItem
        '
        Me.播放ToolStripMenuItem.Name = "播放ToolStripMenuItem"
        Me.播放ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.播放ToolStripMenuItem.Text = "播放"
        '
        '录音ToolStripMenuItem
        '
        Me.录音ToolStripMenuItem.Checked = True
        Me.录音ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.录音ToolStripMenuItem.Name = "录音ToolStripMenuItem"
        Me.录音ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.录音ToolStripMenuItem.Text = "录音"
        '
        '新建ToolStripMenuItem
        '
        Me.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem"
        Me.新建ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.新建ToolStripMenuItem.Text = "新建"
        '
        '显示全部ToolStripMenuItem
        '
        Me.显示全部ToolStripMenuItem.Name = "显示全部ToolStripMenuItem"
        Me.显示全部ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.显示全部ToolStripMenuItem.Text = "显示全部"
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.打开ToolStripMenuItem.Text = "打开"
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.选择区域保存ToolStripMenuItem, Me.显示区域保存ToolStripMenuItem, Me.全部保存ToolStripMenuItem, Me.FFT保存ToolStripMenuItem})
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.保存ToolStripMenuItem.Text = "保存"
        '
        '选择区域保存ToolStripMenuItem
        '
        Me.选择区域保存ToolStripMenuItem.Name = "选择区域保存ToolStripMenuItem"
        Me.选择区域保存ToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.选择区域保存ToolStripMenuItem.Text = "选择区域保存 SHIFT+S"
        '
        '显示区域保存ToolStripMenuItem
        '
        Me.显示区域保存ToolStripMenuItem.Name = "显示区域保存ToolStripMenuItem"
        Me.显示区域保存ToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.显示区域保存ToolStripMenuItem.Text = "显示区域保存 CTRL+S"
        '
        '全部保存ToolStripMenuItem
        '
        Me.全部保存ToolStripMenuItem.Name = "全部保存ToolStripMenuItem"
        Me.全部保存ToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.全部保存ToolStripMenuItem.Text = "全部保存 CTRL+SHIFT+S"
        '
        'FFT保存ToolStripMenuItem
        '
        Me.FFT保存ToolStripMenuItem.Name = "FFT保存ToolStripMenuItem"
        Me.FFT保存ToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.FFT保存ToolStripMenuItem.Text = "FFT保存"
        '
        'LBSelectCount
        '
        Me.LBSelectCount.AutoSize = True
        Me.LBSelectCount.Location = New System.Drawing.Point(287, 235)
        Me.LBSelectCount.Name = "LBSelectCount"
        Me.LBSelectCount.Size = New System.Drawing.Size(65, 12)
        Me.LBSelectCount.TabIndex = 93
        Me.LBSelectCount.Text = "选择点数："
        '
        'lbMousePoint
        '
        Me.lbMousePoint.AutoSize = True
        Me.lbMousePoint.Location = New System.Drawing.Point(662, 89)
        Me.lbMousePoint.Name = "lbMousePoint"
        Me.lbMousePoint.Size = New System.Drawing.Size(65, 12)
        Me.lbMousePoint.TabIndex = 95
        Me.lbMousePoint.Text = "鼠标位置："
        '
        '波形绘图窗口
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 337)
        Me.Controls.Add(Me.lbMousePoint)
        Me.Controls.Add(Me.LBSelectCount)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.LbSelectRegion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnSetDisplayPoint)
        Me.Controls.Add(Me.TbSetDisPlayPoints)
        Me.Controls.Add(Me.lbDisplayPointCount)
        Me.Controls.Add(Me.lbamp)
        Me.Controls.Add(Me.lbScale)
        Me.Controls.Add(Me.lbcurpos)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lbdatalen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FScaleScol)
        Me.Controls.Add(Me.XPosScrol)
        Me.Controls.Add(Me.DataViewBox)
        Me.Name = "波形绘图窗口"
        Me.Text = "波形绘图窗口"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataViewBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XPosScrol As HScrollBar
    Friend WithEvents FScaleScol As VScrollBar
    Friend WithEvents Label5 As Label
    Friend WithEvents ShowAll As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lbdatalen As Label
    Friend WithEvents lbcurpos As Label
    Friend WithEvents DataViewBox As PictureBox
    Friend WithEvents lbScale As Label
    Friend WithEvents lbamp As Label
    Friend WithEvents lbDisplayPointCount As Label
    Friend WithEvents TbSetDisPlayPoints As TextBox
    Friend WithEvents BtnSetDisplayPoint As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents LbSelectRegion As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 播放ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 录音ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 新建ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 显示全部ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 选择区域保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 全部保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FFT保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 显示区域保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LBSelectCount As Label
    Friend WithEvents lbMousePoint As Label
End Class
