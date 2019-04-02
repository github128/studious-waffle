Imports System.IO
Imports System.Runtime.InteropServices

'保存录音文件

' 三个函数 
' WaveSaveFile  保存的文件名 
' WAVEWRITEFILE 写入的数据
' WAVECLOSE  关闭文件名，并校正文件头

Public Class SaveWaveData

    Private IsClose As Boolean = False

    Private Enum WIMMessages As UInteger
        WIM_DATA = &H3C0
        WIM_OPEN = &H3BE
        WIM_CLOSE = &H3BF
    End Enum

    Private Structure WAVEHDR
        Dim lpData As IntPtr
        Dim dwBufferLength As Integer
        Dim dwBytesRecorded As Integer
        Dim dwUser As IntPtr
        Dim dwFlags As WaveHdrFlags
        Dim dwLoops As Integer
        Dim lpNext As IntPtr
        Dim reserved As IntPtr
    End Structure


    <Flags()>
    Enum WaveHdrFlags As UInteger
        WHDR_DONE = 1
        WHDR_PREPARED = 2
        WHDR_BEGINLOOP = 4
        WHDR_ENDLOOP = 8
        WHDR_INQUEUE = 16
    End Enum

    Structure WAVEFORMATEX
        Dim wFormatTag As Short  'SHORT 非INTEGER
        Dim nChannels As Short
        Dim nSamplesPerSec As Integer
        Dim nAvgBytesPerSec As Integer
        Dim nBlockAlign As Short
        Dim wBitsPerSample As Short
        Dim cbSize As Short
    End Structure


    Enum WaveInOpenFlags As UInteger
        CALLBACK_NULL = 0
        CALLBACK_FUNCTION = &H30000
        CALLBACK_EVENT = &H50000
        CALLBACK_WINDOW = &H10000
        CALLBACK_THREAD = &H20000
        WAVE_FORMAT_QUERY = 1
        WAVE_MAPPED = 4
        WAVE_FORMAT_DIRECT = 8
    End Enum


    Structure WAVEFORMAT
        Dim wFormatTag As Integer
        Dim nChannels As Integer
        Dim nSamplesPerSec As Integer
        Dim nAvgBytesPerSec As Integer
        Dim nBlockAlign As Integer
    End Structure


    Enum MMRESULT
        MMSYSERR_NOERROR = 0
        MMSYSERR_ERROR = 1
        MMSYSERR_BADDEVICEID = 2
        MMSYSERR_NOTENABLED = 3
        MMSYSERR_ALLOCATED = 4
        MMSYSERR_INVALHANDLE = 5
        MMSYSERR_NODRIVER = 6
        MMSYSERR_NOMEM = 7
        MMSYSERR_NOTSUPPORTED = 8
        MMSYSERR_BADERRNUM = 9
        MMSYSERR_INVALFLAG = 10
        MMSYSERR_INVALPARAM = 11
        MMSYSERR_HANDLEBUSY = 12
        MMSYSERR_INVALIDALIAS = 13
        MMSYSERR_BADDB = 14
        MMSYSERR_KEYNOTFOUND = 15
        MMSYSERR_READERROR = 16
        MMSYSERR_WRITEERROR = 17
        MMSYSERR_DELETEERROR = 18
        MMSYSERR_VALNOTFOUND = 19
        MMSYSERR_NODRIVERCB = 20
        WAVERR_BADFORMAT = 32
        WAVERR_STILLPLAYING = 33
        WAVERR_UNPREPARED = 34
    End Enum


    '保存录音文件
    ''' <summary>
    ''' 三个函数 WAVESAVEFILE ,
    ''' WAVEWRITEFILE
    ''' WAVECLOSE
    ''' </summary>
    ''' <remarks></remarks>

    Public Const WAVE_FORMAT_PCM As Integer = 1

    '保存的文件名并初始化文件头
    Public m_file As IO.FileStream
    Public Sub WaveSaveFile(fname As String)
        IsClose = False
        m_file = New IO.FileStream(fname, FileMode.Create)


        Dim BUFSIZE As Integer = 0

        Dim waveform As WAVEFORMATEX
        Dim pSaveBuffer(BUFSIZE) As Byte
        Dim dwDataLength As Integer = BUFSIZE

        With waveform
            .wFormatTag = WAVE_FORMAT_PCM
            .nChannels = 1
            .nSamplesPerSec = 16000
            .nAvgBytesPerSec = 32000
            .nBlockAlign = 2
            .wBitsPerSample = 16
            .cbSize = 0
        End With

        For I = 0 To BUFSIZE
            pSaveBuffer(I) = I Mod 256
        Next


        '写入文件头 
        Dim m_WaveHeaderSize As Int32 = 38
        Dim m_WaveFormatSize As Int32 = 18
        m_file.Seek(0, SeekOrigin.Begin)
        m_file.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"), 0, 4)   '0
        Dim Sec As Integer = dwDataLength + m_WaveHeaderSize
        m_file.Write(BitConverter.GetBytes(Sec), 0, Marshal.SizeOf(Sec))   '4
        m_file.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"), 0, 4)    '8
        m_file.Write(System.Text.Encoding.ASCII.GetBytes("fmt "), 0, 4)    '12
        m_file.Write(BitConverter.GetBytes(m_WaveFormatSize), 0, Marshal.SizeOf(m_WaveFormatSize))              '16
        m_file.Write(BitConverter.GetBytes(waveform.wFormatTag), 0, Marshal.SizeOf(waveform.wFormatTag))        '18
        m_file.Write(BitConverter.GetBytes(waveform.nChannels), 0, Marshal.SizeOf(waveform.nChannels))           '20
        m_file.Write(BitConverter.GetBytes(waveform.nSamplesPerSec), 0, Marshal.SizeOf(waveform.nSamplesPerSec)) '22
        m_file.Write(BitConverter.GetBytes(waveform.nAvgBytesPerSec), 0, Marshal.SizeOf(waveform.nAvgBytesPerSec)) '26
        m_file.Write(BitConverter.GetBytes(waveform.nBlockAlign), 0, Marshal.SizeOf(waveform.nBlockAlign))    '30
        m_file.Write(BitConverter.GetBytes(waveform.wBitsPerSample), 0, Marshal.SizeOf(waveform.wBitsPerSample))  '32
        m_file.Write(BitConverter.GetBytes(waveform.cbSize), 0, Marshal.SizeOf(waveform.cbSize))   '34
        m_file.Write(System.Text.Encoding.ASCII.GetBytes("data"), 0, 4)   '36
        m_file.Write(BitConverter.GetBytes(dwDataLength), 0, 4) '40
        '   m_file.Write(pSaveBuffer, 0, dwDataLength)
        ' m_file.Seek(0, SeekOrigin.Begin)


    End Sub


    '写入数据
    Dim buffer(6400) As Byte
    Dim count As Integer = 0
    Public Sub WaveWriteFile(lpdata As Byte(), len As Integer, Optional once As Boolean = False)
        If once = True Then
            count = 0
        End If

        If IsClose Then
            Return
        End If

        If (len = 0) Then
            Return
        End If

        m_file.Write(lpdata, 0, len)
        count = count + len
    End Sub




    '关闭文件 校正文件头
    Public Sub CloseWaveFile()


        IsClose = True
        '修改文件长度
        If (m_file.CanWrite = False) Then
            Return
        End If
        m_file.Seek(4, SeekOrigin.Begin)
        m_file.Write(BitConverter.GetBytes(count + 38), 0, 4)
        m_file.Seek(42, SeekOrigin.Begin)
        m_file.Write(BitConverter.GetBytes(count), 0, 4)
        m_file.Seek(0, SeekOrigin.End)
        m_file.Close()
    End Sub


    '读取WAV文件
    Public Sub WaveReadFile(fname As String)

        Dim FS As New FileStream(fname, FileMode.Open)
        Dim buffer(50) As Byte
        FS.Seek(20, SeekOrigin.Begin)
        FS.Read(buffer, 0, 50)

        Dim ip As IntPtr = Marshal.AllocHGlobal(50)
        Marshal.Copy(buffer, 0, ip, 50)
        Dim wavf As WAVEFORMATEX = Marshal.PtrToStructure(ip, GetType(WAVEFORMATEX))

        FS.Close()

        Dim FS2 As New FileStream("d:\hello1.wav", FileMode.Open)
        FS2.Seek(20, SeekOrigin.Begin)
        FS2.Read(buffer, 0, 50)

        ip = Marshal.AllocHGlobal(50)
        Marshal.Copy(buffer, 0, ip, 50)
        Dim wavf2 As WAVEFORMATEX = Marshal.PtrToStructure(ip, GetType(WAVEFORMATEX))


        '36 data
        FS2.Seek(42, SeekOrigin.Begin)

        Dim tbt() As Byte = System.Text.Encoding.ASCII.GetBytes("data")
        Dim bt(4) As Byte
        FS2.Read(bt, 0, 4)
        Dim it As Integer = BitConverter.ToInt32(bt, 0)



        FS2.Close()


    End Sub

End Class


