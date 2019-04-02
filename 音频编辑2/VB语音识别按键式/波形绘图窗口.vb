Imports System.IO
Imports System.Media
Imports System.Speech
Imports System.Speech.Recognition
Imports NAudio.Wave



Imports VB语音识别按键式.PwdManagement.Voice



Public Class 波形绘图窗口


    Dim WavDraw As WaveDrawApi



    Private Sub 波形绘图窗口_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        T2num.Text = 0
        T3Num.Text = 0

        WavDraw = New WaveDrawApi(DataViewBox)
        FScaleScol.Value = 1
        windowLen.Text = 6400


        '读入最近打开的文件
        Dim fs As New FileStream("f:\listbox.txt", FileMode.OpenOrCreate)
        Dim sr As New StreamReader(fs)
        Dim str1 As String
        str1 = sr.ReadLine
        While str1 <> Nothing
            ListBox1.Items.Add(str1)
            str1 = sr.ReadLine
        End While
        sr.Close()
        fs.Close()

    End Sub


    Private Sub 波形绘图窗口_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '   FS.Close()

        '保存打开的文件名
        Dim fs As New FileStream("f:\listbox.txt", FileMode.Create)
        Dim sr As New StreamWriter(fs)
        For Each i As String In ListBox1.Items
            sr.WriteLine(i)
        Next
        sr.Close()
        fs.Close()

        waverecord.Close()

    End Sub


    Private Function DrawWave()
        'WavDraw.DrawWavData16(Pens.Black, WavData16)

        Dim SColor As Color = Color.LightGray
        '是否显示间隔线

    End Function







#Region "ok"




    '-----------------------------------播放声音----------------------------------------------
    Dim play As New PlayWavFile
    Private Sub PlayBtn_Click(sender As Object, e As EventArgs) Handles PlayBtn.Click
        ' play.Play("d:\abc.wav")
        ' Dim player As SoundPlayer = New SoundPlayer("d:\abc.wav")

        Dim Dlen As Integer = windowLen.Text
        Dim NData(Dlen) As Int16

        Array.Copy(WavData16, XPosScrol.Value, NData, 0, Dlen)


        play.play3(NData)
    End Sub


    '横向拖拉条 -位置
    Private Sub XScaleScrol_Scroll(sender As Object, e As ScrollEventArgs) Handles XPosScrol.Scroll
        Label2.Text = "位置： " & e.NewValue
        Debug.Print(e.NewValue & "    " & YScaleScrol.Value)

        WavDraw.Pos(e.NewValue)
        DrawWave()
    End Sub

    '纵向拖拉条 -缩放比
    Private Sub YScaleScrol_Scroll(sender As Object, e As ScrollEventArgs) Handles YScaleScrol.Scroll
        Debug.Print(XPosScrol.Value & "   " & e.NewValue)
        Label1.Text = "缩放:" & e.NewValue
        Label8.Text = "数量：" & WavData16.Length / e.NewValue

        WavDraw.Scale(e.NewValue)
        DrawWave()



        '横向拖拉条 最大值调整
        XPosScrol.Maximum = WavData16.Length - WavData16.Length / e.NewValue
        Label4.Text = "横向拖拉条 最大值调整" & XPosScrol.Maximum
    End Sub



    '幅度拖拉条
    Private Sub FScaleScol_Scroll(sender As Object, e As ScrollEventArgs) Handles FScaleScol.Scroll
        For i As Integer = 0 To WavData16.Length - 1
            WavData16(i) = WavDataCopy(i) * e.NewValue
        Next

        WavDraw.Fudu(e.NewValue)
        DrawWave()
    End Sub





    '--------------------------------------保存图片------------------------------
    Private Sub SavePictureBtn_Click(sender As Object, e As EventArgs)

        Dim bmp1 As New Bitmap(1600 * 10, 500, Imaging.PixelFormat.Format16bppRgb555)

        ' Dim grap As Graphics = DataViewBox.Image()


        '  DataViewBox.Image.Save("f:\" & TextBox1.Text & ".jpg")

    End Sub




    '----------------------------------------复选框---------------------------------------------------------
    '间隔选框状态改变，重绘图
    Private Sub ShowDWCB_CheckedChanged(sender As Object, e As EventArgs)
        DrawWave()
    End Sub

    '复选框 显示分隔
    Private Sub ShowSpareCB_CheckedChanged(sender As Object, e As EventArgs)
        DrawWave()
    End Sub



    '---------------------------------------------录音----------------------------------------------------

    Dim WaveSave As New SaveWaveData
    Dim waverecord As New WaveRecordApi

    Dim WaveDataBuffer(6400 * 10) As Byte
    Dim WaveDataLength As Integer = 0
    ''' <summary>
    ''' 录音数据到达
    ''' </summary>
    ''' <param name="lpdata"></param>
    ''' <param name="datalen"></param>
    ''' <returns></returns>
    Public Function DataArrive(lpdata As Byte(), datalen As Integer)
        If WaveDataLength >= 6400 * 10 Then
            Exit Function
        End If
        lpdata.CopyTo（WaveDataBuffer, WaveDataLength)
        WaveDataLength = WaveDataLength + datalen
    End Function

    ' Dim WaveDataBufferTmp（6400 * 10） As Byte '第一段语音保存,，以用于对比MFCC

    Private Sub RecordWavBtn_MouseDown(sender As Object, e As MouseEventArgs)
        ' WaveSave.WaveSaveFile("d:\abc.wav")
        ' WaveDataBuffer.CopyTo(WaveDataBufferTmp, 0)  '第一段语音保存，以用于对比MFCC
        WaveDataLength = 0
        Debug.Print(1)
        System.Console.WriteLine(3)
        waverecord.Start(AddressOf DataArrive)

    End Sub


    Dim WavDataCopy() As Int16
    Private Sub RecordWavBtn_MouseUp(sender As Object, e As MouseEventArgs)
        '  WaveSave.CloseWaveFile()
        If WaveDataLength = 0 Then
            Return
        End If
        WavDataLengthLable.Text = "WaveData数据总长：" & WaveDataLength
        ReDim WavData16(WaveDataLength)
        Buffer.BlockCopy(WaveDataBuffer, 0, WavData16, 0, (WaveDataLength - 1))

        ReDim WavDataCopy(WaveDataLength)
        WavData16.CopyTo(WavDataCopy, 0)
        '绘画
        WavDraw.DrawWaveData16(WavData16, windowLen.Text)
        XPosScrol.Maximum = WaveDataLength
        Debug.Print(2)
        waverecord.Close()
        WaveDataLength = 0





        DrawWave()

    End Sub

    '-----------------------------打开按钮--------------------------
    Private Sub OpenBtn_Click(sender As Object, e As EventArgs) Handles OpenBtn.Click
        ' WavDraw = New WaveDrawApi(DataViewBox)
        Dim fo As New OpenFileDialog
        fo.InitialDirectory = "f:\"
        fo.Filter() = "(wav)|*.wav"
        If (fo.ShowDialog() = DialogResult.OK) Then
            '绘制波形图
            WavData16 = WavDraw.DrawWaveFile(fo.FileName)

        End If

        XPosScrol.Maximum = WavData16.Length

        ListBox1.Items.Add(fo.FileName)
    End Sub





#End Region



    Private Sub SMoothBtn_Click(sender As Object, e As EventArgs)
        Smooth(WavData16)
        DrawWave()
    End Sub


    Private Sub VadBTN_Click(sender As Object, e As EventArgs)
        Dim p As List(Of Point) = DivWave2(WavDraw, WavData16, XPosScrol.Value, XPosScrol.Value + WavData16.Length / YScaleScrol.Value)
        DrawWavSeg(WavDraw, p, XPosScrol.Value, YScaleScrol.Value)
    End Sub


    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Dim fname As String = ListBox1.Items(ListBox1.IndexFromPoint(e.Location))

        WavData16 = WavDraw.DrawWaveFile(fname)
        WavDraw.Fudu(FScaleScol.Value)
        XPosScrol.Maximum = WavData16.Length
    End Sub



    Dim SourceData() As Int16
    Private Sub Button3_Click(sender As Object, e As EventArgs)

        Dim tmp(WavData16.Length) As Int16
        WavData16.CopyTo(tmp, 0)
        Dim j As Integer = 0
        Dim average As Integer = 0


        For i = 0 To tmp.Length - 1
            If j < 400 Then
                average = average + tmp(i)
            Else
                average = average / 400 / 2

                For m = 400 To 0 Step -1
                    tmp(i - m) = tmp(i - m) - average
                Next

                average = 0
                j = 0
            End If
            j = j + 1

        Next

        ' ReDim SourceData(WavData16.Length)
        SourceData = WavData16
        WavData16 = tmp
        WavDraw.DrawWaveData16(tmp, windowLen.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        WavData16 = SourceData
        WavDraw.DrawWaveData16(WavData16, windowLen.Text)
    End Sub




    Private Sub SaveNoHeadWavDataBtn_Click(sender As Object, e As EventArgs) Handles SaveNoHeadWavDataBtn.Click

        Dim tmp(WavData16.Length * 2) As Byte
        Buffer.BlockCopy(WavData16, 0, tmp, 0, WaveDataLength * 2)
        Dim fs As New FileStream("f:\" & T3Num.Text & ".wav", FileMode.Create)
        fs.Write(tmp, 0, WavData16.Length * 2)
        fs.Close()


    End Sub

    Public Shared Sub recognizer_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs)

        Console.WriteLine("Recognized text: " + e.Result.Text)
    End Sub


    Public Sub intCopytoDouble(A() As Int16, start As Integer, B() As Double, len As Integer)
        For i = 0 To len - 1
            B(i) = A(i + start)
        Next
    End Sub




    Private Sub testBtn_Click(sender As Object, e As EventArgs) Handles testBtn.Click

        For i = 0 To 13
            Debug.Print(i)
        Next


        Dim fs As New FileStream("f:\test.txt", FileMode.Create)
        Dim br As New BinaryWriter(fs)
        Dim db1 As Double = 0.1314526
        br.Write(db1)
        db1 = 0.9768
        br.Write(db1)
        br.Close()
        fs.Close()

    End Sub

    Private Sub test2Btn_Click(sender As Object, e As EventArgs) Handles test2Btn.Click
        Dim fs As New FileStream("f:\test.txt", FileMode.Open)
        Dim bw As New BinaryReader(fs)
        Debug.Write(bw.ReadDouble())
        Debug.Write(bw.ReadDouble())
        bw.Close()
        fs.Close()
    End Sub

    Private Sub WindowLenBtn_Click(sender As Object, e As EventArgs) Handles WindowLenBtn.Click
        WavDraw.SetWindowLen(windowLen.Text)
        WavDraw.DrawRecordWav(Pens.AliceBlue, WavData16, XPosScrol.Value, 0)
    End Sub




    '------------------------------------naudio 录音--------------------------------------------------------

    Dim wav As New WaveIn
    Private Sub RecordWavCBox_CheckedChanged(sender As Object, e As EventArgs) Handles RecordWavCBox.CheckedChanged
        If RecordWavCBox.Checked Then
            Pos = 0
            wav.BufferMilliseconds = 200  '缓冲区大小=  ; 200 = 6400；100 = 3200
            wav.NumberOfBuffers = 12   '缓冲区数量
            wav.WaveFormat = New WaveFormat(16000, 16, 1) '格式 16000

            AddHandler wav.DataAvailable, AddressOf waveIn_DataAvailable
            wav.StartRecording()  '录音启动

            RecordWavCBox.Text = "停止"
        Else

            '录音数据备份
            ReDim WavDataCopy(WavMaxLen)
            WavData16.CopyTo(WavDataCopy, 0)

            WavLen = Pos
            '停止录音
            wav.StopRecording()
            RecordWavCBox.Text = "录音"
        End If
    End Sub

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
        Debug.Print("*********pos:" & Pos)
        If Pos > 6400 Then
            '绘画
            Dim tmp = (Pos / 2) - 6400
            Debug.Print("*********tmp:" & tmp)
            WavDraw.DrawRecordWav(Pens.Red, WavData16, tmp, 6400)
            For i = 0 To 10
                Debug.Print(WavData16(tmp + i))
            Next
        End If
        XPosScrol.Maximum = Pos / 2
        XPosScrol.Value = Pos / 2
        Debug.WriteLine("***************")




        If Pos > WavMaxLen Then

            wav.StopRecording()
            MsgBox("10min is over")
        End If
        'e.Buffer, e.BytesRecorded


    End Sub


    '-------------------------全部数据保存-----------------------------------------------
    Private Sub AllWavSavBtn_Click(sender As Object, e As EventArgs) Handles AllWavSavBtn.Click
        Dim FileNameStr As String = T1head.Text & T2num.Text & T3Num.Text

        WaveSave.WaveSaveFile("f:\" & FileNameStr & ".wav")
        Dim tmp(WavLen) As Byte
        Buffer.BlockCopy(WavData16, 0, tmp, 0, WavLen)

        WaveSave.WaveWriteFile(tmp, WavLen)
        WaveSave.CloseWaveFile()

        ListBox1.Items.Add("f:\" & FileNameStr & ".wav")
    End Sub

    '----------------------------------------保--存-------------------------------------------------
    Private Sub WavSaveBtn_Click(sender As Object, e As EventArgs) Handles SaveRecordBtn.Click
        Dim FileNameStr As String = T1head.Text & T2num.Text & T3Num.Text
        WaveSave.WaveSaveFile("f:\" & FileNameStr & ".wav")

        Dim StartPos As Integer = 0
        Dim Length As Integer = 0
        StartPos = XPosScrol.Value
        'Length = WavData16.Length / YScaleScrol.Value
        Length = windowLen.Text
        Dim tmp(Length * 2) As Byte
        Buffer.BlockCopy(WavData16, StartPos * 2, tmp, 0, Length * 2)

        WaveSave.WaveWriteFile(tmp, Length * 2)
        WaveSave.CloseWaveFile()

        ListBox1.Items.Add("f:\" & FileNameStr & ".wav")
    End Sub

    '-----------------------------原始数据片断保存------------------------------

    Private Sub RawWavDataSavBtn_Click(sender As Object, e As EventArgs) Handles RawWavDataSavBtn.Click
        Dim FileNameStr As String = T1head.Text & T2num.Text & "-" & T3Num.Text

        WaveSave.WaveSaveFile("f:\" & FileNameStr & ".wav")

        Dim StartPos As Integer = 0
        Dim Length As Integer = 0
        StartPos = XPosScrol.Value
        Length = windowLen.Text
        Dim tmp(Length * 2) As Byte
        Buffer.BlockCopy(WavDataCopy, StartPos * 2, tmp, 0, Length * 2)
        WaveSave.WaveWriteFile(tmp, Length * 2)
        WaveSave.CloseWaveFile()

        ListBox1.Items.Add("f:\" & FileNameStr & ".wav")
        T2num.Text = T2num.Text + 1
    End Sub

    '***********************自动保存*************************
    Private Sub AutoSaveBtn_Click(sender As Object, e As EventArgs) Handles AutoSaveBtn.Click
        Dim FileNameStr As String

        Dim count_num As Integer = WavData16.Length / 3200

        Dim StartPos As Integer
        Dim Length As Integer = 6400
        Dim tmp(Length * 2) As Byte
        For i = 0 To count_num - 1
            FileNameStr = T1head.Text & T2num.Text & "-" & T3Num.Text
            WaveSave.WaveSaveFile("f:\" & FileNameStr & ".wav")

            StartPos = 3200 * i


            Buffer.BlockCopy(WavData16, StartPos * 2, tmp, 0, Length * 2)
            WaveSave.WaveWriteFile(tmp, Length * 2)
            WaveSave.CloseWaveFile()

            ListBox1.Items.Add("f:\" & FileNameStr & ".wav")
            T2num.Text = T2num.Text + 1
        Next

    End Sub
End Class

