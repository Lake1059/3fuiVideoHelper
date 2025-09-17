Imports LibVLCSharp.[Shared]

Public Class Form1

    Public VLC库对象 As LibVLC
    Public 播放器本体 As MediaPlayer
    Public 是否已初始化 As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DPI As Single = Me.CreateGraphics.DpiX / 96
        Dim 宽度 As Integer = 854 * DPI
        Dim 高度 As Integer = 480 * DPI + Panel1.Height + Panel2.Height + Panel3.Height
        Me.ClientSize = New Size(宽度, 高度)
        Me.MinimumSize = Me.Size

        Core.Initialize()
        VLC库对象 = New LibVLC(Array.Empty(Of String))
        播放器本体 = New MediaPlayer(VLC库对象)
        VideoView1.MediaPlayer = 播放器本体
        AddHandler 播放器本体.TimeChanged, AddressOf 播放器时间改变事件
        AddHandler 播放器本体.PositionChanged, AddressOf 播放器进度改变事件
        AddHandler 播放器本体.LengthChanged, Sub()
                                            UiTextBox入点.Text = ""
                                            UiTextBox出点.Text = ""
                                        End Sub
        绑定拖动控件移动窗体(VideoView1)
        绑定拖动控件移动窗体(Panel2)
        绑定拖动控件移动窗体(Panel3)
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        是否已初始化 = True
        界面校准()
        MsgBox($"此软件是 3FUI 转码软件的配套外部工具，为剪辑区间提供可视化交互。{vbCrLf & vbCrLf}需注意：VLC 是拿来放视频的，不是拿来干剪辑的，时间码并不是逐帧刷新，这由播放器内部缓冲机制控制，视频本身也可能影响，目前已经没有更好的且低成本的实现方法。这算是剪辑软件的下位替代，如果你不想大费周章打开剪辑软件那就用这个，方便又轻量。{vbCrLf & vbCrLf}3FUI 的版本必须在 2.6 及以上才可以接收本工具发送的数据！")
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        界面校准()
    End Sub

    Sub 界面校准()
        If Not 是否已初始化 Then Exit Sub
        Dim s1 As Integer = 0
        For Each c As Control In Me.Panel2.Controls
            s1 += c.Width
        Next
        Me.Panel2.Padding = New Padding((Me.Panel2.Width - s1) * 0.5, Me.Panel2.Padding.Top, (Me.Panel2.Width - s1) * 0.5, Me.Panel2.Padding.Bottom)
        s1 = 0
        For Each c As Control In Me.Panel3.Controls
            s1 += c.Width
        Next
        Me.Panel3.Padding = New Padding((Me.Panel3.Width - s1) * 0.5, Me.Panel3.Padding.Top, (Me.Panel3.Width - s1) * 0.5, Me.Panel3.Padding.Bottom)
    End Sub

    Sub 播放器时间改变事件(sender As Object, e As MediaPlayerTimeChangedEventArgs)
        Panel1.Invalidate()
    End Sub
    Sub 播放器进度改变事件(sender As Object, e As MediaPlayerPositionChangedEventArgs)
    End Sub

    Private Sub VideoView1_DragDrop(sender As Object, e As DragEventArgs) Handles VideoView1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        If FileIO.FileSystem.FileExists(files(0)) Then
            播放器本体.Play(New Media(VLC库对象, files(0), FromType.FromPath, Array.Empty(Of String)))
        End If

    End Sub
    Private Sub VideoView1_DragEnter(sender As Object, e As DragEventArgs) Handles VideoView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub UiButton打开_Click(sender As Object, e As EventArgs) Handles UiButton打开.Click
        Using ofd As New OpenFileDialog With {.Multiselect = False}
            If ofd.ShowDialog = DialogResult.OK Then
                播放器本体.Play(New Media(VLC库对象, ofd.FileName, FromType.FromPath, Array.Empty(Of String)))
            End If
        End Using
    End Sub

    Private Sub UiButton播放_Click(sender As Object, e As EventArgs) Handles UiButton播放.Click
        播放器本体.Play()
    End Sub

    Private Sub UiButton暂停_Click(sender As Object, e As EventArgs) Handles UiButton暂停.Click
        播放器本体.Pause()
    End Sub

    Private Sub UiButton停止_Click(sender As Object, e As EventArgs) Handles UiButton停止.Click
        播放器本体.Stop()
    End Sub

    Private Sub UiButton倒半秒_Click(sender As Object, e As EventArgs) Handles UiButton倒半秒.Click
        播放器本体.Time = Math.Max(0, 播放器本体.Time - 500)
        Panel1.Invalidate()
    End Sub

    Private Sub UiButton进1帧_Click(sender As Object, e As EventArgs) Handles UiButton进1帧.Click
        播放器本体.NextFrame()
        Panel1.Invalidate()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim panelWidth As Integer = sender.Width
        Dim panelHeight As Integer = sender.Height
        Using backgroundBrush As New SolidBrush(Panel1.BackColor)
            e.Graphics.FillRectangle(backgroundBrush, 0, 0, panelWidth, panelHeight)
        End Using

        If 播放器本体 IsNot Nothing AndAlso 播放器本体.Length > 0 Then
            Dim position As Single = 播放器本体.Position
            Dim progressWidth As Integer = panelWidth * position
            If progressWidth > 0 Then
                Using progressBrush As New SolidBrush(Color.FromArgb(80, 80, 80))
                    e.Graphics.FillRectangle(progressBrush, 0, 0, progressWidth, panelHeight)
                End Using
            End If
            If Not String.IsNullOrEmpty(UiTextBox入点.Text) AndAlso TimeSpan.TryParse(UiTextBox入点.Text, Nothing) Then
                Dim 入点时间 As TimeSpan = TimeSpan.Parse(UiTextBox入点.Text)
                Dim 入点毫秒 As Long = 入点时间.TotalMilliseconds
                If 入点毫秒 >= 0 AndAlso 入点毫秒 <= 播放器本体.Length Then
                    Dim 入点位置 As Single = 入点毫秒 / 播放器本体.Length
                    Dim 入点X As Integer = panelWidth * 入点位置
                    Using 入点画笔 As New Pen(Color.IndianRed, 1)
                        e.Graphics.DrawLine(入点画笔, 入点X, 0, 入点X, panelHeight)
                    End Using
                End If
            End If
            If Not String.IsNullOrEmpty(UiTextBox出点.Text) AndAlso TimeSpan.TryParse(UiTextBox出点.Text, Nothing) Then
                Dim 出点时间 As TimeSpan = TimeSpan.Parse(UiTextBox出点.Text)
                Dim 出点毫秒 As Long = 出点时间.TotalMilliseconds
                If 出点毫秒 >= 0 AndAlso 出点毫秒 <= 播放器本体.Length Then
                    Dim 出点位置 As Single = 出点毫秒 / 播放器本体.Length
                    Dim 出点X As Integer = panelWidth * 出点位置
                    Using 出点画笔 As New Pen(Color.CornflowerBlue, 1)
                        e.Graphics.DrawLine(出点画笔, 出点X, 0, 出点X, panelHeight)
                    End Using
                End If
            End If
            Dim currentTime As TimeSpan = TimeSpan.FromMilliseconds(播放器本体.Time)
            Dim totalTime As TimeSpan = TimeSpan.FromMilliseconds(播放器本体.Length)
            Dim timeText As String = String.Format("{0:hh\:mm\:ss\.fff} / {1:hh\:mm\:ss\.fff}", currentTime, totalTime) & $" | Volume {播放器本体.Volume}%"
            Dim textSize As SizeF = e.Graphics.MeasureString(timeText, Font)
            Dim x As Single = (panelWidth - textSize.Width) / 2
            Dim y As Single = (panelHeight - textSize.Height) / 2
            TextRenderer.DrawText(e.Graphics, timeText, Font, New Point(x, y), ForeColor, TextFormatFlags.NoPadding)
        End If
    End Sub

    Private Sub Panel1_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseClick
        Select Case e.Button
            Case MouseButtons.Left
                If 播放器本体 IsNot Nothing AndAlso 播放器本体.Length > 0 Then
                    Dim clickX As Integer = e.X
                    Dim newPosition As Single = clickX / sender.Width
                    播放器本体.Position = newPosition
                    Panel1.Invalidate()
                End If
            Case MouseButtons.Middle
                播放器本体.Volume = 0
        End Select
    End Sub

    Private Sub Panel1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Panel1.MouseWheel
        Select Case e.Delta
            Case > 0 : 播放器本体.Volume += 5
            Case < 0 : 播放器本体.Volume -= 5
        End Select
    End Sub

    Private Sub UiButton去入点_Click(sender As Object, e As EventArgs) Handles UiButton去入点.Click
        If TimeSpan.TryParse(UiTextBox入点.Text, Nothing) Then
            Dim ts As TimeSpan = TimeSpan.Parse(UiTextBox入点.Text)
            播放器本体.Time = CLng(ts.TotalMilliseconds)
            Panel1.Invalidate()
        End If
    End Sub
    Private Sub UiButton定为入点_Click(sender As Object, e As EventArgs) Handles UiButton定为入点.Click
        Dim a As TimeSpan = TimeSpan.FromMilliseconds(播放器本体.Time)
        UiTextBox入点.Text = String.Format("{0:hh\:mm\:ss\.fff}", a)
    End Sub
    Private Sub UiButton定为出点_Click(sender As Object, e As EventArgs) Handles UiButton定为出点.Click
        Dim a As TimeSpan = TimeSpan.FromMilliseconds(播放器本体.Time)
        UiTextBox出点.Text = String.Format("{0:hh\:mm\:ss\.fff}", a)
    End Sub
    Private Sub UiButton去出点_Click(sender As Object, e As EventArgs) Handles UiButton去出点.Click
        If TimeSpan.TryParse(UiTextBox出点.Text, Nothing) Then
            Dim ts As TimeSpan = TimeSpan.Parse(UiTextBox出点.Text)
            播放器本体.Time = CLng(ts.TotalMilliseconds)
            Panel1.Invalidate()
        End If
    End Sub

    Private Sub UiButton给3FUI_Click(sender As Object, e As EventArgs) Handles UiButton给3FUI.Click
        Try
            Dim targetProcess As Process = Nothing
            For Each proc As Process In Process.GetProcesses()
                If proc.ProcessName.Contains("FFmpegFreeUI", StringComparison.CurrentCultureIgnoreCase) Then
                    targetProcess = proc
                    Exit For
                End If
            Next
            If targetProcess Is Nothing Then
                Sunny.UI.UIMessageTip.ShowError("你需要先启动 3FUI 再使用这个功能", 5000, False)
                Exit Sub
            End If
            Dim exePath As String = targetProcess.MainModule.FileName
            Dim args As New List(Of String)
            If Not String.IsNullOrEmpty(UiTextBox入点.Text) AndAlso TimeSpan.TryParse(UiTextBox入点.Text, Nothing) Then
                args.Add("-3fuiVideoHelperInPointTime")
                args.Add(UiTextBox入点.Text)
            End If
            If Not String.IsNullOrEmpty(UiTextBox出点.Text) AndAlso TimeSpan.TryParse(UiTextBox出点.Text, Nothing) Then
                args.Add("-3fuiVideoHelperOutPointTime")
                args.Add(UiTextBox出点.Text)
            End If
            If args.Count > 0 Then
                Dim startInfo As New ProcessStartInfo With {
                    .FileName = exePath,
                    .Arguments = String.Join(" ", args),
                    .UseShellExecute = False
                }
                Process.Start(startInfo)
                Sunny.UI.UIMessageTip.ShowOk("数据已发送", 3000, False)
            Else
                Sunny.UI.UIMessageTip.ShowError("没有数据可以发送", 3000, False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class
