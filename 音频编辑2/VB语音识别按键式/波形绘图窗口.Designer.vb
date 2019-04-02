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
        Me.DataViewBox = New System.Windows.Forms.PictureBox()
        Me.YScaleScrol = New System.Windows.Forms.VScrollBar()
        Me.XPosScrol = New System.Windows.Forms.HScrollBar()
        Me.PlayBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WavDataLengthLable = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FScaleScol = New System.Windows.Forms.VScrollBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SaveRecordBtn = New System.Windows.Forms.Button()
        Me.T3Num = New System.Windows.Forms.TextBox()
        Me.OpenBtn = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SaveNoHeadWavDataBtn = New System.Windows.Forms.Button()
        Me.testBtn = New System.Windows.Forms.Button()
        Me.test2Btn = New System.Windows.Forms.Button()
        Me.label11 = New System.Windows.Forms.Label()
        Me.windowLen = New System.Windows.Forms.TextBox()
        Me.WindowLenBtn = New System.Windows.Forms.Button()
        Me.RawWavDataSavBtn = New System.Windows.Forms.Button()
        Me.RecordWavCBox = New System.Windows.Forms.CheckBox()
        Me.AllWavSavBtn = New System.Windows.Forms.Button()
        Me.T1head = New System.Windows.Forms.TextBox()
        Me.T2num = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AutoSaveBtn = New System.Windows.Forms.Button()
        CType(Me.DataViewBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataViewBox
        '
        Me.DataViewBox.Location = New System.Drawing.Point(26, 20)
        Me.DataViewBox.Name = "DataViewBox"
        Me.DataViewBox.Size = New System.Drawing.Size(765, 199)
        Me.DataViewBox.TabIndex = 0
        Me.DataViewBox.TabStop = False
        '
        'YScaleScrol
        '
        Me.YScaleScrol.Location = New System.Drawing.Point(794, 20)
        Me.YScaleScrol.Minimum = 1
        Me.YScaleScrol.Name = "YScaleScrol"
        Me.YScaleScrol.Size = New System.Drawing.Size(21, 199)
        Me.YScaleScrol.TabIndex = 1
        Me.YScaleScrol.Value = 1
        '
        'XPosScrol
        '
        Me.XPosScrol.LargeChange = 1
        Me.XPosScrol.Location = New System.Drawing.Point(24, 227)
        Me.XPosScrol.Maximum = 0
        Me.XPosScrol.Name = "XPosScrol"
        Me.XPosScrol.Size = New System.Drawing.Size(766, 31)
        Me.XPosScrol.TabIndex = 2
        '
        'PlayBtn
        '
        Me.PlayBtn.Location = New System.Drawing.Point(319, 292)
        Me.PlayBtn.Name = "PlayBtn"
        Me.PlayBtn.Size = New System.Drawing.Size(130, 28)
        Me.PlayBtn.TabIndex = 4
        Me.PlayBtn.Text = "Play"
        Me.PlayBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(793, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "缩放值"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(737, 258)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "位置"
        '
        'WavDataLengthLable
        '
        Me.WavDataLengthLable.AutoSize = True
        Me.WavDataLengthLable.Location = New System.Drawing.Point(401, 258)
        Me.WavDataLengthLable.Name = "WavDataLengthLable"
        Me.WavDataLengthLable.Size = New System.Drawing.Size(71, 12)
        Me.WavDataLengthLable.TabIndex = 7
        Me.WavDataLengthLable.Text = "WAV数据总长"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(549, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "横向拖条长"
        '
        'FScaleScol
        '
        Me.FScaleScol.LargeChange = 1
        Me.FScaleScol.Location = New System.Drawing.Point(825, 47)
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
        Me.Label5.Location = New System.Drawing.Point(823, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "幅值"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(793, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "缩放"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "位置"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(737, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "数量"
        '
        'SaveRecordBtn
        '
        Me.SaveRecordBtn.Location = New System.Drawing.Point(319, 353)
        Me.SaveRecordBtn.Name = "SaveRecordBtn"
        Me.SaveRecordBtn.Size = New System.Drawing.Size(130, 28)
        Me.SaveRecordBtn.TabIndex = 23
        Me.SaveRecordBtn.Text = "修改数据保存"
        Me.SaveRecordBtn.UseVisualStyleBackColor = True
        '
        'T3Num
        '
        Me.T3Num.Location = New System.Drawing.Point(280, 358)
        Me.T3Num.Name = "T3Num"
        Me.T3Num.Size = New System.Drawing.Size(33, 21)
        Me.T3Num.TabIndex = 24
        '
        'OpenBtn
        '
        Me.OpenBtn.Location = New System.Drawing.Point(36, 458)
        Me.OpenBtn.Name = "OpenBtn"
        Me.OpenBtn.Size = New System.Drawing.Size(130, 28)
        Me.OpenBtn.TabIndex = 32
        Me.OpenBtn.Text = "打开"
        Me.OpenBtn.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(36, 289)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(130, 160)
        Me.ListBox1.TabIndex = 33
        '
        'SaveNoHeadWavDataBtn
        '
        Me.SaveNoHeadWavDataBtn.Location = New System.Drawing.Point(319, 421)
        Me.SaveNoHeadWavDataBtn.Name = "SaveNoHeadWavDataBtn"
        Me.SaveNoHeadWavDataBtn.Size = New System.Drawing.Size(130, 28)
        Me.SaveNoHeadWavDataBtn.TabIndex = 39
        Me.SaveNoHeadWavDataBtn.Text = "保存WAV无头数据"
        Me.SaveNoHeadWavDataBtn.UseVisualStyleBackColor = True
        '
        'testBtn
        '
        Me.testBtn.Location = New System.Drawing.Point(755, 375)
        Me.testBtn.Name = "testBtn"
        Me.testBtn.Size = New System.Drawing.Size(97, 32)
        Me.testBtn.TabIndex = 47
        Me.testBtn.Text = "test"
        Me.testBtn.UseVisualStyleBackColor = True
        '
        'test2Btn
        '
        Me.test2Btn.Location = New System.Drawing.Point(755, 408)
        Me.test2Btn.Name = "test2Btn"
        Me.test2Btn.Size = New System.Drawing.Size(97, 32)
        Me.test2Btn.TabIndex = 48
        Me.test2Btn.Text = "test2"
        Me.test2Btn.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(191, 474)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(83, 12)
        Me.label11.TabIndex = 50
        Me.label11.Text = "显示数据长度:"
        '
        'windowLen
        '
        Me.windowLen.Location = New System.Drawing.Point(280, 471)
        Me.windowLen.Name = "windowLen"
        Me.windowLen.Size = New System.Drawing.Size(130, 21)
        Me.windowLen.TabIndex = 51
        '
        'WindowLenBtn
        '
        Me.WindowLenBtn.Location = New System.Drawing.Point(416, 471)
        Me.WindowLenBtn.Name = "WindowLenBtn"
        Me.WindowLenBtn.Size = New System.Drawing.Size(97, 21)
        Me.WindowLenBtn.TabIndex = 52
        Me.WindowLenBtn.Text = "确定"
        Me.WindowLenBtn.UseVisualStyleBackColor = True
        '
        'RawWavDataSavBtn
        '
        Me.RawWavDataSavBtn.Location = New System.Drawing.Point(183, 385)
        Me.RawWavDataSavBtn.Name = "RawWavDataSavBtn"
        Me.RawWavDataSavBtn.Size = New System.Drawing.Size(130, 28)
        Me.RawWavDataSavBtn.TabIndex = 53
        Me.RawWavDataSavBtn.Text = "原数据保存"
        Me.RawWavDataSavBtn.UseVisualStyleBackColor = True
        '
        'RecordWavCBox
        '
        Me.RecordWavCBox.Appearance = System.Windows.Forms.Appearance.Button
        Me.RecordWavCBox.Location = New System.Drawing.Point(221, 289)
        Me.RecordWavCBox.Name = "RecordWavCBox"
        Me.RecordWavCBox.Size = New System.Drawing.Size(53, 35)
        Me.RecordWavCBox.TabIndex = 55
        Me.RecordWavCBox.Text = "录音"
        Me.RecordWavCBox.UseVisualStyleBackColor = True
        '
        'AllWavSavBtn
        '
        Me.AllWavSavBtn.Location = New System.Drawing.Point(319, 387)
        Me.AllWavSavBtn.Name = "AllWavSavBtn"
        Me.AllWavSavBtn.Size = New System.Drawing.Size(130, 28)
        Me.AllWavSavBtn.TabIndex = 56
        Me.AllWavSavBtn.Text = "全部保存"
        Me.AllWavSavBtn.UseVisualStyleBackColor = True
        '
        'T1head
        '
        Me.T1head.Location = New System.Drawing.Point(185, 358)
        Me.T1head.Name = "T1head"
        Me.T1head.Size = New System.Drawing.Size(44, 21)
        Me.T1head.TabIndex = 57
        '
        'T2num
        '
        Me.T2num.Location = New System.Drawing.Point(231, 358)
        Me.T2num.Name = "T2num"
        Me.T2num.Size = New System.Drawing.Size(33, 21)
        Me.T2num.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(268, 364)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 12)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "-"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(183, 343)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "文件名："
        '
        'AutoSaveBtn
        '
        Me.AutoSaveBtn.Location = New System.Drawing.Point(183, 421)
        Me.AutoSaveBtn.Name = "AutoSaveBtn"
        Me.AutoSaveBtn.Size = New System.Drawing.Size(130, 28)
        Me.AutoSaveBtn.TabIndex = 61
        Me.AutoSaveBtn.Text = "【自动】保存"
        Me.AutoSaveBtn.UseVisualStyleBackColor = True
        '
        '波形绘图窗口
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 504)
        Me.Controls.Add(Me.AutoSaveBtn)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T2num)
        Me.Controls.Add(Me.T1head)
        Me.Controls.Add(Me.AllWavSavBtn)
        Me.Controls.Add(Me.RecordWavCBox)
        Me.Controls.Add(Me.RawWavDataSavBtn)
        Me.Controls.Add(Me.WindowLenBtn)
        Me.Controls.Add(Me.windowLen)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.test2Btn)
        Me.Controls.Add(Me.testBtn)
        Me.Controls.Add(Me.SaveNoHeadWavDataBtn)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.OpenBtn)
        Me.Controls.Add(Me.T3Num)
        Me.Controls.Add(Me.SaveRecordBtn)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FScaleScol)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.WavDataLengthLable)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PlayBtn)
        Me.Controls.Add(Me.XPosScrol)
        Me.Controls.Add(Me.YScaleScrol)
        Me.Controls.Add(Me.DataViewBox)
        Me.Name = "波形绘图窗口"
        Me.Text = "波形绘图窗口"
        CType(Me.DataViewBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents YScaleScrol As VScrollBar
    Friend WithEvents XPosScrol As HScrollBar
    Friend WithEvents PlayBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents WavDataLengthLable As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents FScaleScol As VScrollBar
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DataViewBox As PictureBox
    Friend WithEvents SaveRecordBtn As Button
    Friend WithEvents T3Num As TextBox
    Friend WithEvents OpenBtn As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents SaveNoHeadWavDataBtn As Button
    Friend WithEvents testBtn As Button
    Friend WithEvents test2Btn As Button
    Friend WithEvents label11 As Label
    Friend WithEvents windowLen As TextBox
    Friend WithEvents WindowLenBtn As Button
    Friend WithEvents RawWavDataSavBtn As Button
    Friend WithEvents RecordWavCBox As CheckBox
    Friend WithEvents AllWavSavBtn As Button
    Friend WithEvents T1head As TextBox
    Friend WithEvents T2num As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents AutoSaveBtn As Button
End Class
