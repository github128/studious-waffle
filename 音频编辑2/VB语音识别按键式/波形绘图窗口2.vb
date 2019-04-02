Imports System.IO
Imports System.Media
Imports NAudio.Wave




Public Class 波形绘图窗口


    Dim WavDraw As WaveDrawWavApi

    '16位声音数据 1，2，4
    Const WaveBytes As Int16 = 2


    'const
    Dim wav_Xpos As Integer  '当前位置
    Dim wav_YScale As Integer '放大值
    Dim wav_FSacle As Integer  '幅值
    Dim wav_DisplayPoints As Integer  '显示点数
    Dim wav_dataLength As Integer



    Private Sub 波形绘图窗口_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '快捷径
        Me.KeyPreview = True




        '拖拉条
        XPosScrol.Value = 0

        FScaleScol.Value = 1

        wav_DisplayPoints = 6400



        WavDraw = New WaveDrawWavApi(DataViewBox)

        wav.BufferMilliseconds = 200  '缓冲区大小=  ; 200 = 6400；100 = 3200
        wav.NumberOfBuffers = 12   '缓冲区数量
        wav.WaveFormat = New WaveFormat(16000, 16, 1) '格式 16000

        AddHandler wav.DataAvailable, AddressOf waveIn_DataAvailable


        FScaleScol.Value = 1





    End Sub


    Private Sub 波形绘图窗口_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        wav.Dispose()

    End Sub








#Region "ok"







    '横向拖拉条 -位置
    Private Sub XScaleScrol_Scroll(sender As Object, e As ScrollEventArgs) Handles XPosScrol.Scroll

        wav_Xpos = e.NewValue
        lbcurpos.Text = "当前位置： " & wav_Xpos
        WavDraw.Pos(wav_Xpos)
    End Sub

    '纵向拖拉条 -缩放比
    Private Sub YScaleScrol_Scroll(sender As Object, e As ScrollEventArgs)

        wav_YScale = e.NewValue

        'debug.print(XPosScrol.Value & "   " & wav_YScale)
        lbScale.Text = "缩放:" & wav_YScale
        wav_DisplayPoints = wav_dataLength / wav_YScale
        WavDraw.SetDisplayPointCount(wav_DisplayPoints)

        lbDisplayPointCount.Text = "显示点：" & wav_DisplayPoints


        WavDraw.Scale(wav_YScale)

        '横向拖拉条 最大值调整
        XPosScrol.Maximum = wav_dataLength - wav_DisplayPoints
        'Label4.Text = "横向拖拉条 最大值调整" & XPosScrol.Maximum
    End Sub



    '幅度-拖拉条
    Private Sub FScaleScol_Scroll(sender As Object, e As ScrollEventArgs) Handles FScaleScol.Scroll
        Dim tmp As Integer

        wav_FSacle = e.NewValue

        If WavDataCopy Is Nothing Then
            Return
        End If

        For i As Integer = 0 To WavData16.Length - 1
            tmp = WavDataCopy(i) * e.NewValue
            If tmp > 256 * 128 Then
                tmp = 256 * 128 - 1
            End If
            If tmp < -32768 Then
                tmp = -32768 + 1
            End If
            WavData16(i) = tmp
        Next

        WavDraw.Fudu(wav_FSacle)
        'DrawWave()
        Label5.Text = "幅值：" & wav_FSacle
    End Sub




    '---------------------------------------------录音----------------------------------------------------

    Dim WaveSave As New SaveWaveData

    Dim WaveDataBuffer(6400 * 10) As Byte
    Dim WaveDataLength As Integer = 0

    Dim WavDataCopy() As Int16

    '-----------------------------打开按钮--------------------------
    Private Sub OpenBtn_Click(sender As Object, e As EventArgs)
        ' WavDraw = New WaveDrawWavApi(DataViewBox)
        Dim fo As New OpenFileDialog
        fo.InitialDirectory = "f:\"
        fo.Filter() = "(wav)|*.wav"
        If (fo.ShowDialog() = DialogResult.OK) Then
            '绘制波形图
            WavData16 = WavDraw.DrawWaveFile(fo.FileName)
            FScaleScol.Value = 20
            'WavDraw.Fudu(20) '20倍音量
            ReDim WavDataCopy(WavData16.Length)
            WavData16.CopyTo(WavDataCopy, 0)


            ''音量 调大20倍
            'Dim tmp As Integer
            'For i As Integer = 0 To WavData16.Length - 1
            '    tmp = WavDataCopy(i) * 20
            '    If tmp > 256 * 128 Then
            '        tmp = 256 * 128 - 1
            '    End If
            '    If tmp < -258 * 128 Then
            '        tmp = -256 * 128 + 1
            '    End If
            '    WavData16(i) = tmp
            'Next


        End If

        XPosScrol.Maximum = WavData16.Length
        XPosScrol.LargeChange = 500
        XPosScrol.SmallChange = 100


    End Sub





#End Region






    Dim SourceData() As Int16


    '------------------------------------naudio 录音--------------------------------------------------------

    Dim wav As New WaveInEvent



    Delegate Function DelgSetLableTxt(pos As Integer)
    Public Function SetLabelTxtFun(pos As Integer)
        lbdatalen.Text = "数据总长:" & pos / 2
    End Function
    Dim setlabel As New DelgSetLableTxt(AddressOf SetLabelTxtFun)

    Delegate Function DelgSetScrol(pos As Integer)
    Public Function SetScrolFun(pos As Integer)
        XPosScrol.Maximum = pos / 2 '- wav_DisplayPoints
        XPosScrol.Value = pos / 2 '- wav_DisplayPoints
    End Function
    Dim setscrol As New DelgSetLableTxt(AddressOf SetScrolFun)



    '--------------------------------录音回调函数--------------------------------------------------

    '   10分钟录音数据
    Dim WavMaxLen As Integer = 16000 * 60 * 10
    Dim WavData16(WavMaxLen) As Int16
    Dim WavLen As Integer = 0  '录音数据长度 byte
    Dim Pos As Integer = 0
    Private Sub waveIn_DataAvailable(sender As Object, e As WaveInEventArgs)
        ' e.Buffer.CopyTo(WavBuffer, Pos)
        Dim b = Pos
        Buffer.BlockCopy(e.Buffer, 0, WavData16, b, e.BytesRecorded)  '偏移量为字节
        Pos = Pos + e.BytesRecorded
        If Pos > 6400 Then
            '绘画
            Dim tmp = (Pos / 2) - 6400
            WavDraw.DrawWavData(Pens.Red, WavData16, tmp, 6400, 4)
            For i = 0 To 10
            Next
            Me.Invoke(setscrol, Pos)
            ' XPosScrol.Maximum = Pos / 2 '- wav_DisplayPoints
            'XPosScrol.Value = Pos / 2 '- wav_DisplayPoints
        End If

        Me.Invoke(setlabel, Pos)



    End Sub





    Dim IMouseDown As Boolean = False
    Dim StartPos, EndPos As Integer
    Private Sub DataViewBox_MouseDown(sender As Object, e As MouseEventArgs) Handles DataViewBox.MouseDown


        If e.Button = MouseButtons.Right Then
            ' WavDraw.DrawWavData(Pens.Blue, WavData16, wav_Xpos, 0)
            Return
        End If




        If IMouseDown = False Then
            StartPos = e.X
        End If

        IMouseDown = True



    End Sub



    Private Sub DataViewBox_MouseUp(sender As Object, e As MouseEventArgs) Handles DataViewBox.MouseUp
        Dim bmp As New Bitmap(DataViewBox.Width, DataViewBox.Height)

        If e.Button = MouseButtons.Right Then
            WavDraw.DrawWavData(Pens.Blue, WavData16, wav_Xpos, 0)
            Return
        End If

        If IMouseDown = True Then
            EndPos = e.X

            Dim xscale As Single = wav_DisplayPoints / DataViewBox.Width

            Dim WStart As Integer = StartPos * xscale + wav_Xpos
            Dim WiEND As Integer = EndPos * xscale + wav_Xpos


            Dim len = (EndPos - StartPos) * xscale
            LBSelectCount.Text = "长度：" & len

            LbSelectRegion.Text = "从 " & WStart & " -  " & WiEND

            WavDraw.DrawSelectRegion(Pens.Orange, WavData16, StartPos, EndPos)
           
        End If
        IMouseDown = False
    End Sub


    '拖拉条
    Private Sub XPosScrol_ValueChanged(sender As Object, e As EventArgs) Handles XPosScrol.ValueChanged
        lbcurpos.Text = "当前位置:" & XPosScrol.Value
    End Sub




    Dim play As New PlayWavFile
    Private Sub 播放ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 播放ToolStripMenuItem.Click

        Dim Dlen As Integer = wav_DisplayPoints
        Dim NData(Dlen) As Int16

        Array.Copy(WavData16, XPosScrol.Value, NData, 0, Dlen)


        play.play3(NData)
    End Sub

    Dim OldWavdata16() As Int16

    Private Sub 打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开ToolStripMenuItem.Click
        OldWavdata16 = WavData16
        Dim fo As New OpenFileDialog
        'fo.InitialDirectory = "f:\"
        fo.Filter() = "(wav)|*.wav"
        If (fo.ShowDialog() = DialogResult.OK) Then
            '绘制波形图

            WavData16 = WavDraw.DrawWaveFile(fo.FileName)

            wav_dataLength = WavData16.Length

            lbdatalen.Text = "数据总长: " & wav_dataLength
            'wav_FSacle = 20
            ' FScaleScol.Value = wav_FSacle
            'WavDraw.Fudu(20) '20倍音量
            ReDim WavDataCopy(WavData16.Length)
            WavData16.CopyTo(WavDataCopy, 0)


        End If




        wav_DisplayPoints = WavData16.Length


        XPosScrol.Maximum = 0
        XPosScrol.Value = 0
    End Sub



    Private Sub 新建ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新建ToolStripMenuItem.Click

        WavDraw.Clear()

        Pos = 0
        wav_DisplayPoints = 6400
        WavDraw.SetDisplayPointCount(wav_DisplayPoints)

        wav_dataLength = 0
        wav_Xpos = 0

        XPosScrol.Value = 0
        XPosScrol.Maximum = 0
        WavData16.Initialize()
    End Sub

    Private Sub 显示全部ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 显示全部ToolStripMenuItem.Click
        wav_YScale = 1
        wav_Xpos = 0

        XPosScrol.Value = wav_Xpos

        WavDraw.Pos(wav_Xpos)

        wav_DisplayPoints = wav_dataLength
        WavDraw.SetDisplayPointCount(wav_DisplayPoints)
        WavDraw.DrawWavData(Pens.Black, WavData16, 0, wav_DisplayPoints)
    End Sub


    Private Sub 显示区域保存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 显示区域保存ToolStripMenuItem.Click
        Dim Dlen As Integer = wav_DisplayPoints

        Dim WStart As Integer = wav_Xpos
        If WStart Mod 2 <> 0 Then
            WStart = WStart + 1
        End If

        Dim ByteLen = wav_DisplayPoints * 2


        Dim savDlg As New SaveFileDialog()
        If (savDlg.ShowDialog() = DialogResult.OK) Then
            Dim filename As String = savDlg.FileName

            WaveSave.WaveSaveFile(filename & ".wav")
            MsgBox(filename)


            Dim tmp(ByteLen) As Byte
            '注意***********2
            Buffer.BlockCopy(WavData16, WStart * 2, tmp, 0, ByteLen)

            WaveSave.WaveWriteFile(tmp, ByteLen, True)
            WaveSave.CloseWaveFile()



        End If


    End Sub


    '选择范围内6400 点 -范围外点归零
    Private Sub 选择区域保存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 选择区域保存ToolStripMenuItem.Click

        Dim xscale As Single = wav_DisplayPoints / DataViewBox.Width

        Dim WStart As Integer = StartPos * xscale + wav_Xpos
        If WStart Mod 2 <> 0 Then
            WStart = WStart + 1
        End If

        Dim datalen As Integer = (EndPos - StartPos) * xscale

        Dim ByteLen = 6400 * 2
        If ByteLen Mod 2 <> 0 Then
            ByteLen = ByteLen - (ByteLen Mod 2)
        End If

        WavDraw.DrawSelectRegion(Pens.Black, WavData16, StartPos, EndPos)


        Dim savDlg As New SaveFileDialog()
        If (savDlg.ShowDialog() = DialogResult.OK) Then
            Dim filename As String = savDlg.FileName

            WaveSave.WaveSaveFile(filename & ".wav")
            MsgBox(filename)

            Dim Data16Tmp(6400 - 1) As Int16
            Dim tmp(ByteLen) As Byte

            Array.Copy(WavData16, WStart, Data16Tmp, 0, datalen)

            '注意**********2，否则错误
            ' Buffer.BlockCopy(WavData16, WStart * 2, tmp, 0, ByteLen)
            Buffer.BlockCopy(Data16Tmp, 0, tmp, 0, ByteLen)



            WaveSave.WaveWriteFile(tmp, ByteLen, True)
            WaveSave.CloseWaveFile()



        End If
    End Sub



    Private Sub 全部保存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全部保存ToolStripMenuItem.Click

        Dim savDlg As New SaveFileDialog()
        If (savDlg.ShowDialog() = DialogResult.OK) Then
            Dim FileNameStr As String = savDlg.FileName

            WaveSave.WaveSaveFile(FileNameStr & ".wav")
            MsgBox(FileNameStr)
            Dim tmp(WavLen) As Byte
            Buffer.BlockCopy(WavData16, 0, tmp, 0, WavLen)

            WaveSave.WaveWriteFile(tmp, WavLen)
            WaveSave.CloseWaveFile()


        End If

    End Sub

 
    Dim RcordStatus As Boolean = False
    Private Sub 录音ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 录音ToolStripMenuItem.Click
        If RcordStatus = False Then

            新建ToolStripMenuItem.PerformClick()

            OldWavdata16 = WavData16

            Pos = 0

            wav.StartRecording()  '录音启动


            录音ToolStripMenuItem.Text = "停止"
            RcordStatus = True
        Else


            '录音数据备份
            ReDim WavDataCopy(WavMaxLen)
            WavData16.CopyTo(WavDataCopy, 0)



            WavLen = Pos
            '停止录音
            wav.StopRecording()

            '绘图
            wav_dataLength = Pos / 2

            'wav_YScale = 1

            wav_Xpos = 0

            XPosScrol.Value = wav_Xpos


            wav_DisplayPoints = wav_dataLength
            WavDraw.SetDisplayPointCount(wav_DisplayPoints)
            WavDraw.DrawWavData(Pens.Black, WavData16, 0, wav_DisplayPoints)


            '显示数据的位置

            XPosScrol.Maximum = 0
            XPosScrol.Value = 0

            录音ToolStripMenuItem.Text = "录音"
            RcordStatus = False
        End If
    End Sub


    '按键--设置-显示点数
    Private Sub BtnSetDisplayPoint_Click(sender As Object, e As EventArgs) Handles BtnSetDisplayPoint.Click
        wav_DisplayPoints = TbSetDisPlayPoints.Text
        WavDraw.SetDisplayPointCount(wav_DisplayPoints)
        WavDraw.DrawWavData(Pens.Red, WavData16, 0, wav_Xpos)

        XPosScrol.Maximum = wav_dataLength - wav_DisplayPoints

    End Sub



    ''' <summary>
    ''' 快捷键设置
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub 波形绘图窗口_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '全部保存 
        If e.Control And e.Shift And e.KeyCode = Keys.S Then
            全部保存ToolStripMenuItem.PerformClick()

            '显示区域保存
        ElseIf e.Control And e.KeyCode = Keys.S Then

            显示区域保存ToolStripMenuItem.PerformClick()

            '播放
        ElseIf e.Control And e.KeyCode = Keys.P Then
            播放ToolStripMenuItem.PerformClick()

            'OPEN
        ElseIf e.Control And e.KeyCode = Keys.O Then
            打开ToolStripMenuItem.PerformClick()


        End If

    End Sub



    Private Sub DataViewBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DataViewBox.MouseMove
        Dim mpoint As Point = WavDraw.GetPoint(e.X, e.Y)
        lbMousePoint.Text = "鼠标位置 x: " & mpoint.X & "  y: " & mpoint.Y
    End Sub


End Class

