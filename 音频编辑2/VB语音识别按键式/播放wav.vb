Imports System.IO
Imports System.Media
Imports NAudio.Wave
Public Class PlayWavFile

    '‘播放文件
    Public Function Play(filename As String)
        Dim player As SoundPlayer = New SoundPlayer(filename)
        player.Play()
    End Function



    'Naudio 播放数据
    Public Function play3(data() As Int16)
        Dim sampleRate = 16000
        Dim ms As MemoryStream
        Dim rs As RawSourceWaveStream
        Dim wo As New WaveOutEvent

        Dim Wbyte(data.Length * 2) As Byte
        Buffer.BlockCopy(data, 0, Wbyte, 0, data.Length * 2)
        ms = New MemoryStream(Wbyte)

        rs = New RawSourceWaveStream(ms, New WaveFormat(16000, 16, 1))
        wo.Init(rs)
        wo.Volume = 1
        wo.Play()
        While wo.PlaybackState = PlaybackState.Playing
            Threading.Thread.Sleep(500)
        End While
        wo.Dispose()

    End Function


    Dim wav As New WaveOut()

    Dim audioread As AudioFileReader

    Dim BUFF(1024 * 100) As Byte
    Public Function Play2()

        audioread = New AudioFileReader("d:\abc-2.wav")

        wav.Init(audioread)
        wav.Play()

    End Function

End Class
