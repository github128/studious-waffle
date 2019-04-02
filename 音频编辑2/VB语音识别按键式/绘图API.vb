'不同比例尺绘图
'将数据绘制到窗口中
Imports System.IO
Imports MathNet.Numerics
Imports MathNet.Numerics.IntegralTransforms

Public Class WaveDrawWavApi

    Const Wav16Height As Integer = 255 * 255

    '  Public IdataSize As Size  '数据尺寸
    Public IPictureControl As PictureBox
    Public Ibmp As Bitmap

    Private nWidth As Double
    Private nHeight As Double
    Private Igrap As Graphics

    Dim Yscale As Integer = 1  '缩放大小
    Dim xpos As Integer = 0 '位置
    Dim IFudu As Integer = 1 '幅值大小
    Dim IWindowLen As Integer = 0

    Dim IPenColor As Pen
    Dim Idata16 As Int16()

    Dim IsDrawData As Boolean = False


    ''' <param name="PictureControl"></param>  绘制的图像框
    Public Sub New(PictureControl As PictureBox, Optional windowslen As Integer = 6400)
        IWindowLen = windowslen
        IPictureControl = PictureControl
        Ibmp = New Bitmap(PictureControl.Width, PictureControl.Height, Imaging.PixelFormat.Format24bppRgb)
        Igrap = Graphics.FromImage(Ibmp)
        'Igrap.Clear(Color.White)
    End Sub

    '''<summary>clear</summary>
    Public Function Clear()
        Igrap.Clear(IPictureControl.BackColor)
        IPictureControl.Image = Ibmp
    End Function


    '''设置窗口显示的点数
    Public Sub SetDisplayPointCount(Wlen As Integer)

        IWindowLen = Wlen
    End Sub


    '绘线
    Public Sub DrawLine(Pcolor As Pen, P1 As Point, P2 As Point)
        Dim NewP1 As Point
        Dim NewP2 As Point

        Dim NewWidth, NewHeigh As Double
        NewWidth = nWidth * Yscale
        NewHeigh = nHeight * Yscale * IFudu

        NewP1 = New Point(P1.X * NewWidth, P1.Y * NewHeigh + IPictureControl.Height / 2)
        NewP2 = New Point(P2.X * NewWidth, P2.Y * NewHeigh + IPictureControl.Height / 2)
        Igrap.DrawLine(Pcolor, NewP1, NewP2)

        If (Not IsDrawData) Then
            IPictureControl.Image = Ibmp

        End If

    End Sub

    '绘制文件
    Public Function DrawWaveFile(filename As String) As Int16()
        Dim fs As FileStream
        fs = New FileStream(filename, FileMode.Open)
        ReDim Idata16(fs.Length / 2)
        Dim buff(fs.Length) As Byte
        fs.Seek(44 + 2, SeekOrigin.Begin)
        fs.Read(buff, 0, fs.Length - 44)
        IWindowLen = (fs.Length - 44) / 2 - 1
        Buffer.BlockCopy(buff, 0, Idata16, 0, fs.Length)
        DrawWavData(Pens.Blue, Idata16, 0, IWindowLen)
        fs.Close()
        Return Idata16
    End Function

    '绘制数据，不清屏-平均值，语音区
    Public Function DrawData(penColor As Pen, data16() As Int16, start As Integer, endpos As Integer)
        If data16 Is Nothing Then
            Return 0
        End If

        nWidth = IPictureControl.Width / IWindowLen
        nHeight = IPictureControl.Height / (255 * 10)




        IsDrawData = True

        Dim SPoint, Epoint As Point

        For i = 0 To IWindowLen - 2

            Epoint.X = i
            Epoint.Y = data16(start + i)
            DrawLine(penColor, SPoint, Epoint)
            SPoint.X = (i)
            SPoint.Y = data16(start + i)
        Next

        IPictureControl.Image = Ibmp
        IsDrawData = False
    End Function


    ''' <summary>
    ''' 绘制录音数据-清屏
    ''' </summary>
    ''' <returns></returns>
    Public Function DrawWavData(PenColor As Pen, data16() As Int16, start As Integer, len As Integer, Optional Fstep As Integer = 1)

        If data16 Is Nothing Then
            Return 0
        End If

        nWidth = IPictureControl.Width / IWindowLen
        nHeight = IPictureControl.Height / (255 * 10)


        SyncLock Igrap

            ' Igrap.Clear(IPictureControl.BackColor)
            Igrap.Clear(Color.Gray)
            Idata16 = data16
            IPenColor = PenColor
            IsDrawData = True

        End SyncLock

        Dim SPoint, Epoint As Point
        For i = 0 To IWindowLen - 2 Step Fstep
            Epoint.X = i
            Epoint.Y = data16(start + i)
            DrawLine(PenColor, SPoint, Epoint)
            SPoint.X = (i + 1)
            SPoint.Y = 0
        Next

        IPictureControl.Image = Ibmp

        IsDrawData = False


    End Function

    ''' <summary>
    ''' 获取鼠标点所对应的数据位置
    ''' </summary>
    Public Function GetPoint(x As Integer, y As Integer) As Point
        Dim NewWidth, NewHeigh As Double

        If nWidth = 0 Then
            Return New Point(0, 0)
        End If

        NewWidth = 1 / nWidth * Yscale
        NewHeigh = 1 / nHeight * Yscale * IFudu

        Dim nx, ny As Integer
        nx = x * NewWidth
        ny = (y - IPictureControl.Height / 2) * NewHeigh

        Return New Point(nx, ny)

    End Function


    '''<summary>
    '''fft draw
    '''</summary>
    Public Function FFTDraw(pencolor As Pen, data16() As Int16, startPos As Integer, len As Integer)

        If data16 Is Nothing Then
            Return 0
        End If

        nWidth = IPictureControl.Width / IWindowLen
        nHeight = IPictureControl.Height / (255 * 10)

        Dim Length As Integer = IWindowLen


        '2049 加了一个 数组类型 0 开始
        Dim FFT_frame As Complex32() = New Complex32(Length - 1) {}


        For i As Integer = 0 To Length - 1
            FFT_frame(i) = data16(startPos + i)
        Next
        MathNet.Numerics.IntegralTransforms.Fourier.Forward(FFT_frame, FourierOptions.Matlab)


        Dim Result(Length - 1) As Int32
        For i = 0 To Length - 1
            Result(i) = FFT_frame(i).Magnitude
        Next


        ' Dim xscale As Single = IWindowLen / IPictureControl.Width

        Igrap.Clear(IPictureControl.BackColor)


        IPenColor = pencolor
        IsDrawData = True



        Dim SPoint, Epoint As Point
        SPoint = New Point(0, Result(0))

        DrawLine(Pens.Black, New Point(800, 0), New Point(800, 3000))
        DrawLine(Pens.Black, New Point(800 * 2, 0), New Point(800 * 2, 3000))

        For i = 0 To Result.Length - 1
            Epoint.X = i
            Epoint.Y = -0.01 * Result(i)
            DrawLine(pencolor, SPoint, Epoint)
            SPoint.X = (i + 1)
            SPoint.Y = 0
        Next

        IPictureControl.Image = Ibmp

        IsDrawData = False
    End Function

    ''' <summary>
    ''' 绘制选择区域-数据位置
    ''' </summary>
    ''' <param name="penColor"></param>
    ''' <param name="data16"></param>
    ''' <param name="start"></param>
    ''' <param name="endPos"></param>
    ''' <returns></returns>
    Public Function DrawRegion(penColor As Pen, data16() As Int16, start As Integer, endPos As Integer)

        ' Igrap.Clear(IPictureControl.BackColor)
        Idata16 = data16
        IPenColor = penColor
        IsDrawData = True



        Dim SPoint, Epoint As Point
        SPoint = New Point(start, data16(start))

        For i = Int(start) To Int(endPos)
            Epoint.X = i
            Epoint.Y = data16(i + xpos)
            DrawLine(penColor, SPoint, Epoint)
            SPoint.X = (i + 1)
            SPoint.Y = 0
        Next

        IPictureControl.Image = Ibmp

        IsDrawData = False
    End Function


    ''' <summary>
    ''' 绘制-选择区域-鼠标区域
    ''' </summary>
    Public Function DrawSelectRegion(penColor As Pen, data16() As Int16, start As Integer, endPos As Integer)
        nWidth = IPictureControl.Width / IWindowLen
        nHeight = IPictureControl.Height / (255 * 10)




        Dim xscale As Single = IWindowLen / IPictureControl.Width

        ' Igrap.Clear(IPictureControl.BackColor)
        Idata16 = data16
        IPenColor = penColor
        IsDrawData = True



        Dim SPoint, Epoint As Point
        SPoint = New Point(start * xscale, data16(start * xscale + xpos))

        For i = Int(start * xscale) To Int(endPos * xscale)
            Epoint.X = i
            Epoint.Y = data16(i + xpos)
            DrawLine(penColor, SPoint, Epoint)
            SPoint.X = (i + 1)
            SPoint.Y = 0
        Next

        IPictureControl.Image = Ibmp

        IsDrawData = False
    End Function



    '放大 缩小
    Public Sub Scale(num As Integer)
        Yscale = num
        DrawWavData(Pens.Blue, Idata16, xpos, IWindowLen)
    End Sub

    '位置
    Public Sub Pos(num As Integer)
        xpos = num
        DrawWavData(Pens.Blue, Idata16, xpos, IWindowLen)
    End Sub

    '幅值
    Public Sub Fudu(num As Integer)
        IFudu = num
        DrawWavData(Pens.Blue, Idata16, xpos, IWindowLen)
    End Sub

    '绘制文本
    Public Sub DrawText(x As Integer, y As Integer, fontsize As Integer, Text As String)
        Dim drawFont As New Font("Arial", fontsize)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim drawPoint As New PointF(Xtox(x), y)
        Igrap.DrawString(Text, drawFont, drawBrush, drawPoint)
    End Sub


    Private Function Xtox(x As Double) As Double
        Return x * nWidth * Yscale
    End Function

    Private Function YtoY(y As Double) As Double
        Return y * IPictureControl.Height / Wav16Height * Yscale
    End Function

    Public Sub DrawRect(pen As Pen, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        Dim x1pos, y1pos, x2pos, y2pos, wpos, hpos As Integer
        x1pos = Xtox(x1)
        y1pos = YtoY(y1) * IFudu + IPictureControl.Height / 2
        x2pos = Xtox(x2)
        y2pos = YtoY(y2) * IFudu + IPictureControl.Height / 2
        wpos = x2pos - x1pos
        hpos = y2pos - y1pos
        Igrap.DrawRectangle(pen, x1pos, y1pos, wpos, hpos)

        'IPictureControl.Image = Ibmp
    End Sub


    Public Sub DrawPixel(pen As Pen, x As Integer, y As Integer)
        Igrap.DrawEllipse(pen, Convert.ToInt32(Xtox(x)), Convert.ToInt32(YtoY(y)), 5, 5)
    End Sub

    Public Sub Show()
        IPictureControl.Image = Ibmp
    End Sub


End Class
