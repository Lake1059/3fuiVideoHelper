Imports LibVLCSharp.Shared
Imports System.Drawing.Drawing2D

Public Class Form1

    Public VLC库对象 As LibVLC
    Public 播放器本体 As MediaPlayer
    Public 是否已初始化 As Boolean = False
    Private 正在拖拽 As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DPI As Single = Me.CreateGraphics.DpiX / 96
        Dim 宽度 As Integer = 900 * DPI
        Dim 高度 As Integer = 480 * DPI + Panel1.Height + Panel2.Height + Panel3.Height ' 移除Panel4
        Me.ClientSize = New Size(宽度, 高度)
        Me.MinimumSize = Me.Size

        ' 启用Panel1的双缓冲以减少闪烁
        Panel1.GetType().GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance).SetValue(Panel1, True)

        Core.Initialize()
        VLC库对象 = New LibVLC(Array.Empty(Of String))
        播放器本体 = New MediaPlayer(VLC库对象)
        VideoView1.MediaPlayer = 播放器本体
        
        ' 启用VideoView1的拖拽功能
        VideoView1.AllowDrop = True
        
        AddHandler 播放器本体.TimeChanged, AddressOf 播放器时间改变事件
        AddHandler 播放器本体.PositionChanged, AddressOf 播放器进度改变事件
        AddHandler 播放器本体.LengthChanged, AddressOf 播放器长度改变事件
        ' 添加播放完成事件处理
        AddHandler 播放器本体.EndReached, AddressOf 播放完成事件
        绑定拖动控件移动窗体(VideoView1)
        绑定拖动控件移动窗体(Panel2)
        绑定拖动控件移动窗体(Panel3)
        ' 移除绑定Panel4的代码
    End Sub

    ' 播放器长度改变事件处理程序
    Private Sub 播放器长度改变事件(sender As Object, e As MediaPlayerLengthChangedEventArgs)
        ' 修复跨线程访问UI控件的问题
        If UiTextBox入点.InvokeRequired Then
            UiTextBox入点.Invoke(Sub()
                                      ' 只有在长度为0时才清空，避免播放完成重新播放时清空设置的入点和出点
                                      If 播放器本体.Length = 0 Then
                                          UiTextBox入点.Text = ""
                                      End If
                                  End Sub)
        Else
            If 播放器本体.Length = 0 Then
                UiTextBox入点.Text = ""
            End If
        End If
        
        If UiTextBox出点.InvokeRequired Then
            UiTextBox出点.Invoke(Sub()
                                      ' 只有在长度为0时才清空，避免播放完成重新播放时清空设置的入点和出点
                                      If 播放器本体.Length = 0 Then
                                          UiTextBox出点.Text = ""
                                      End If
                                  End Sub)
        Else
            If 播放器本体.Length = 0 Then
                UiTextBox出点.Text = ""
            End If
        End If
    End Sub

    ' 播放完成事件处理程序
    Private Sub 播放完成事件(sender As Object, e As EventArgs)
        ' 播放完成后，将播放位置重置为0，这样用户可以重新点击播放按钮
        If 播放器本体 IsNot Nothing Then
            ' 确保在UI线程中更新界面
            If Panel1.InvokeRequired Then
                Panel1.Invoke(Sub()
                                  ' 重置播放位置到开始
                                  播放器本体.Position = 0
                                  Panel1.Invalidate()
                              End Sub)
            Else
                ' 重置播放位置到开始
                播放器本体.Position = 0
                Panel1.Invalidate()
            End If
        End If
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
        ' 只在非拖拽状态下重绘，避免拖拽时的冲突
        If Not 正在拖拽 Then
            Panel1.Invalidate()
        End If
    End Sub
    Sub 播放器进度改变事件(sender As Object, e As MediaPlayerPositionChangedEventArgs)
        ' 只在非拖拽状态下重绘，避免拖拽时的冲突
        If Not 正在拖拽 Then
            Panel1.Invalidate()
        End If
    End Sub

    Private Sub VideoView1_DragEnter(sender As Object, e As DragEventArgs) Handles VideoView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            ' 更改背景色以提供视觉反馈
            VideoView1.BackColor = Color.FromArgb(80, 80, 80)
            
            ' 创建拖拽提示标签
            Dim dragLabel As New Label()
            dragLabel.Text = "释放以播放视频"
            dragLabel.Font = New Font("微软雅黑", 16, FontStyle.Bold)
            dragLabel.ForeColor = Color.White
            dragLabel.BackColor = Color.Transparent
            dragLabel.AutoSize = True
            dragLabel.Name = "dragPromptLabel"
            dragLabel.Anchor = AnchorStyles.None
            
            ' 移除可能存在的旧标签
            Dim existingLabel As Label = CType(VideoView1.Controls.Find("dragPromptLabel", True).FirstOrDefault(), Label)
            If existingLabel IsNot Nothing Then
                VideoView1.Controls.Remove(existingLabel)
                existingLabel.Dispose()
            End If
            
            ' 添加新标签并居中
            VideoView1.Controls.Add(dragLabel)
            dragLabel.Location = New Point((VideoView1.Width - dragLabel.Width) / 2, (VideoView1.Height - dragLabel.Height) / 2)
            dragLabel.BringToFront()
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub VideoView1_DragLeave(sender As Object, e As EventArgs) Handles VideoView1.DragLeave
        ' 拖拽离开时恢复原始背景色
        VideoView1.BackColor = Color.Black
        
        ' 移除拖拽提示标签
        Dim dragLabel As Label = CType(VideoView1.Controls.Find("dragPromptLabel", True).FirstOrDefault(), Label)
        If dragLabel IsNot Nothing Then
            VideoView1.Controls.Remove(dragLabel)
            dragLabel.Dispose()
        End If
    End Sub

    Private Sub VideoView1_DragOver(sender As Object, e As DragEventArgs) Handles VideoView1.DragOver
        ' 在拖拽过程中保持视觉反馈
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            VideoView1.BackColor = Color.FromArgb(80, 80, 80)
            
            ' 更新标签位置以防大小改变
            Dim dragLabel As Label = CType(VideoView1.Controls.Find("dragPromptLabel", True).FirstOrDefault(), Label)
            If dragLabel IsNot Nothing Then
                dragLabel.Location = New Point((VideoView1.Width - dragLabel.Width) / 2, (VideoView1.Height - dragLabel.Height) / 2)
                dragLabel.BringToFront()
            End If
        End If
    End Sub

    Private Sub VideoView1_DragDrop(sender As Object, e As DragEventArgs) Handles VideoView1.DragDrop
        VideoView1.BackColor = Color.Black ' 恢复原始背景色
        
        ' 移除拖拽提示标签
        Dim dragLabel As Label = CType(VideoView1.Controls.Find("dragPromptLabel", True).FirstOrDefault(), Label)
        If dragLabel IsNot Nothing Then
            VideoView1.Controls.Remove(dragLabel)
            dragLabel.Dispose()
        End If
        
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        If FileIO.FileSystem.FileExists(files(0)) Then
            播放器本体.Play(New Media(VLC库对象, files(0), FromType.FromPath, Array.Empty(Of String)))
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
        ' 检查播放器状态，如果在播放则暂停，否则播放
        If 播放器本体 IsNot Nothing AndAlso 播放器本体.Media IsNot Nothing Then
            ' 检查当前播放状态
            If 播放器本体.State = VLCState.Ended Or 播放器本体.State = VLCState.Stopped Then
                ' 如果播放器处于结束或停止状态，重新设置播放
                播放器本体.Stop()
                播放器本体.Play()
            ElseIf 播放器本体.IsPlaying Then
                ' 如果正在播放，则暂停
                播放器本体.Pause()
            Else
                ' 否则开始播放
                播放器本体.Play()
            End If
        End If
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
        Dim g As Graphics = e.Graphics
        
        ' 绘制背景
        Using backgroundBrush As New SolidBrush(Color.FromArgb(40, 40, 40))
            g.FillRectangle(backgroundBrush, 0, 0, panelWidth, panelHeight)
        End Using

        If 播放器本体 IsNot Nothing AndAlso 播放器本体.Length > 0 Then
            ' 绘制播放进度条
            Dim position As Single = 播放器本体.Position
            Dim progressWidth As Integer = panelWidth * position
            
            If progressWidth > 0 Then
                ' 创建渐变背景色
                Using progressBrush As New LinearGradientBrush(
                        New Point(0, 0), New Point(progressWidth, 0),
                        Color.FromArgb(100, 100, 100), Color.FromArgb(80, 80, 80))
                    g.FillRectangle(progressBrush, 0, 0, progressWidth, panelHeight)
                End Using
                
                ' 绘制进度条边框
                Using progressBorderPen As New Pen(Color.FromArgb(120, 120, 120), 1)
                    g.DrawRectangle(progressBorderPen, 0, 0, progressWidth - 1, panelHeight - 1)
                End Using
            End If
            
            ' 绘制入点标记
            If Not String.IsNullOrEmpty(UiTextBox入点.Text) AndAlso TimeSpan.TryParse(UiTextBox入点.Text, Nothing) Then
                Dim 入点时间 As TimeSpan = TimeSpan.Parse(UiTextBox入点.Text)
                Dim 入点毫秒 As Long = 入点时间.TotalMilliseconds
                If 入点毫秒 >= 0 AndAlso 入点毫秒 <= 播放器本体.Length Then
                    Dim 入点位置 As Single = 入点毫秒 / 播放器本体.Length
                    Dim 入点X As Integer = panelWidth * 入点位置
                    Using 入点画笔 As New Pen(Color.FromArgb(255, 100, 100), 2)
                        g.DrawLine(入点画笔, 入点X, 0, 入点X, panelHeight)
                        
                        ' 绘制入点标记三角形
                        Dim trianglePoints = {
                            New Point(入点X - 5, 0),
                            New Point(入点X + 5, 0),
                            New Point(入点X, 10)
                        }
                        g.FillPolygon(New SolidBrush(Color.FromArgb(255, 100, 100)), trianglePoints)
                    End Using
                End If
            End If
            
            ' 绘制出点标记
            If Not String.IsNullOrEmpty(UiTextBox出点.Text) AndAlso TimeSpan.TryParse(UiTextBox出点.Text, Nothing) Then
                Dim 出点时间 As TimeSpan = TimeSpan.Parse(UiTextBox出点.Text)
                Dim 出点毫秒 As Long = 出点时间.TotalMilliseconds
                If 出点毫秒 >= 0 AndAlso 出点毫秒 <= 播放器本体.Length Then
                    Dim 出点位置 As Single = 出点毫秒 / 播放器本体.Length
                    Dim 出点X As Integer = panelWidth * 出点位置
                    Using 出点画笔 As New Pen(Color.FromArgb(100, 150, 255), 2)
                        g.DrawLine(出点画笔, 出点X, 0, 出点X, panelHeight)
                        
                        ' 绘制出点标记三角形
                        Dim trianglePoints = {
                            New Point(出点X - 5, panelHeight),
                            New Point(出点X + 5, panelHeight),
                            New Point(出点X, panelHeight - 10)
                        }
                        g.FillPolygon(New SolidBrush(Color.FromArgb(100, 150, 255)), trianglePoints)
                    End Using
                End If
            End If
            
            ' 绘制当前播放位置指示器线
            Dim currentPos As Single = 播放器本体.Time / 播放器本体.Length
            Dim currentX As Integer = panelWidth * currentPos
            Using indicatorPen As New Pen(Color.FromArgb(200, 200, 200), 2)
                g.DrawLine(indicatorPen, currentX, 0, currentX, panelHeight)
            End Using

            ' 绘制时间文本
            Dim currentTimeDisplay As TimeSpan = TimeSpan.FromMilliseconds(播放器本体.Time)
            Dim totalTimeDisplay As TimeSpan = TimeSpan.FromMilliseconds(播放器本体.Length)
            Dim timeTextDisplay As String = String.Format("{0:hh\:mm\:ss\.fff} / {1:hh\:mm\:ss\.fff}", currentTimeDisplay, totalTimeDisplay) & $" | Volume {播放器本体.Volume}%"
            Dim textSizeDisplay As SizeF = g.MeasureString(timeTextDisplay, Font)
            Dim xDisplay As Single = (panelWidth - textSizeDisplay.Width) / 2
            Dim yDisplay As Single = (panelHeight - textSizeDisplay.Height) / 2
            TextRenderer.DrawText(g, timeTextDisplay, Font, New Point(xDisplay, yDisplay), Color.Silver, TextFormatFlags.NoPadding)
        Else
            ' 如果没有视频，显示提示文本
            Dim hintText As String = "拖拽视频文件到窗口播放"
            Dim textSize As SizeF = g.MeasureString(hintText, Font)
            Dim x As Single = (panelWidth - textSize.Width) / 2
            Dim y As Single = (panelHeight - textSize.Height) / 2
            TextRenderer.DrawText(g, hintText, Font, New Point(x, y), Color.Gray, TextFormatFlags.NoPadding)
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

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left AndAlso 播放器本体 IsNot Nothing AndAlso 播放器本体.Length > 0 Then
            正在拖拽 = True
            ' 捕获鼠标事件
            sender.Capture = True
            ' 处理鼠标按下事件，准备拖拽
            Dim newPosition As Single = e.X / sender.Width
            播放器本体.Position = newPosition
            Panel1.Invalidate()
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If (e.Button = MouseButtons.Left) AndAlso 播放器本体 IsNot Nothing AndAlso 播放器本体.Length > 0 Then
            ' 处理鼠标拖拽事件
            Dim panelWidth As Integer = sender.Width
            Dim x As Integer = Math.Max(0, Math.Min(e.X, panelWidth))
            Dim newPosition As Single = x / panelWidth
            播放器本体.Position = newPosition
            ' 强制重绘进度条以显示当前位置
            Panel1.Invalidate()
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If 正在拖拽 Then
            正在拖拽 = False
            ' 拖拽结束后重绘，确保进度条显示正确
            Panel1.Invalidate()
        End If
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