<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        VideoView1 = New LibVLCSharp.WinForms.VideoView()
        Panel1 = New Panel()
        Panel2 = New Panel()
        UiButton去出点 = New Sunny.UI.UIButton()
        Label9 = New Label()
        UiButton定为出点 = New Sunny.UI.UIButton()
        Label7 = New Label()
        UiTextBox出点 = New Sunny.UI.UITextBox()
        Label6 = New Label()
        UiTextBox入点 = New Sunny.UI.UITextBox()
        Label1 = New Label()
        UiButton定为入点 = New Sunny.UI.UIButton()
        Label8 = New Label()
        UiButton去入点 = New Sunny.UI.UIButton()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Panel3 = New Panel()
        UiButton给3FUI = New Sunny.UI.UIButton()
        Label11 = New Label()
        UiButton进1帧 = New Sunny.UI.UIButton()
        Label10 = New Label()
        UiButton倒半秒 = New Sunny.UI.UIButton()
        UiButton停止 = New Sunny.UI.UIButton()
        UiButton暂停 = New Sunny.UI.UIButton()
        UiButton播放 = New Sunny.UI.UIButton()
        UiButton打开 = New Sunny.UI.UIButton()
        Panel4 = New Panel()
        CType(VideoView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' VideoView1
        ' 
        VideoView1.AllowDrop = True
        VideoView1.BackColor = Color.Black
        VideoView1.Dock = DockStyle.Fill
        VideoView1.Location = New Point(0, 0)
        VideoView1.MediaPlayer = Nothing
        VideoView1.Name = "VideoView1"
        VideoView1.Size = New Size(900, 480)
        VideoView1.TabIndex = 0
        VideoView1.Text = "VideoView1"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 615)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(900, 30)
        Panel1.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(UiButton去出点)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(UiButton定为出点)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(UiTextBox出点)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(UiTextBox入点)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(UiButton定为入点)
        Panel2.Controls.Add(Label8)
        Panel2.Controls.Add(UiButton去入点)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 565)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(10)
        Panel2.Size = New Size(900, 50)
        Panel2.TabIndex = 2
        ' 
        ' UiButton去出点
        ' 
        UiButton去出点.Dock = DockStyle.Left
        UiButton去出点.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去出点.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去出点.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton去出点.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去出点.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton去出点.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton去出点.Font = New Font("微软雅黑", 10F)
        UiButton去出点.ForeColor = Color.Silver
        UiButton去出点.ForeDisableColor = Color.Silver
        UiButton去出点.ForeHoverColor = Color.Silver
        UiButton去出点.ForePressColor = Color.Silver
        UiButton去出点.ForeSelectedColor = Color.Silver
        UiButton去出点.Location = New Point(640, 10)
        UiButton去出点.MinimumSize = New Size(1, 1)
        UiButton去出点.Name = "UiButton去出点"
        UiButton去出点.Radius = 30
        UiButton去出点.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去出点.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去出点.RectHoverColor = Color.DarkGray
        UiButton去出点.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton去出点.RectSelectedColor = Color.DarkGray
        UiButton去出点.Size = New Size(80, 30)
        UiButton去出点.TabIndex = 101
        UiButton去出点.Text = "去出点"
        UiButton去出点.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' Label9
        ' 
        Label9.Dock = DockStyle.Left
        Label9.Location = New Point(630, 10)
        Label9.Name = "Label9"
        Label9.Size = New Size(10, 30)
        Label9.TabIndex = 103
        ' 
        ' UiButton定为出点
        ' 
        UiButton定为出点.Dock = DockStyle.Left
        UiButton定为出点.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为出点.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为出点.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton定为出点.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为出点.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton定为出点.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton定为出点.Font = New Font("微软雅黑", 10F)
        UiButton定为出点.ForeColor = Color.Silver
        UiButton定为出点.ForeDisableColor = Color.Silver
        UiButton定为出点.ForeHoverColor = Color.Silver
        UiButton定为出点.ForePressColor = Color.Silver
        UiButton定为出点.ForeSelectedColor = Color.Silver
        UiButton定为出点.Location = New Point(520, 10)
        UiButton定为出点.MinimumSize = New Size(1, 1)
        UiButton定为出点.Name = "UiButton定为出点"
        UiButton定为出点.Radius = 30
        UiButton定为出点.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为出点.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为出点.RectHoverColor = Color.DarkGray
        UiButton定为出点.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton定为出点.RectSelectedColor = Color.DarkGray
        UiButton定为出点.Size = New Size(110, 30)
        UiButton定为出点.TabIndex = 99
        UiButton定为出点.Text = "定为出点"
        UiButton定为出点.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' Label7
        ' 
        Label7.Dock = DockStyle.Left
        Label7.Location = New Point(510, 10)
        Label7.Name = "Label7"
        Label7.Size = New Size(10, 30)
        Label7.TabIndex = 98
        ' 
        ' UiTextBox出点
        ' 
        UiTextBox出点.Dock = DockStyle.Left
        UiTextBox出点.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox出点.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox出点.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox出点.FillReadOnlyColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox出点.Font = New Font("微软雅黑", 10F)
        UiTextBox出点.ForeColor = Color.Silver
        UiTextBox出点.ForeDisableColor = Color.Silver
        UiTextBox出点.ForeReadOnlyColor = Color.Silver
        UiTextBox出点.Location = New Point(380, 10)
        UiTextBox出点.Margin = New Padding(4, 5, 4, 5)
        UiTextBox出点.MinimumSize = New Size(1, 16)
        UiTextBox出点.Name = "UiTextBox出点"
        UiTextBox出点.Padding = New Padding(5)
        UiTextBox出点.Radius = 30
        UiTextBox出点.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox出点.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox出点.RectReadOnlyColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox出点.ShowText = False
        UiTextBox出点.Size = New Size(130, 30)
        UiTextBox出点.TabIndex = 97
        UiTextBox出点.TextAlignment = ContentAlignment.MiddleLeft
        UiTextBox出点.Watermark = "出点"
        UiTextBox出点.WatermarkActiveColor = Color.DimGray
        UiTextBox出点.WatermarkColor = Color.DimGray
        ' 
        ' Label6
        ' 
        Label6.Dock = DockStyle.Left
        Label6.Location = New Point(370, 10)
        Label6.Name = "Label6"
        Label6.Size = New Size(10, 30)
        Label6.TabIndex = 96
        ' 
        ' UiTextBox入点
        ' 
        UiTextBox入点.Dock = DockStyle.Left
        UiTextBox入点.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox入点.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox入点.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox入点.FillReadOnlyColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox入点.Font = New Font("微软雅黑", 10F)
        UiTextBox入点.ForeColor = Color.Silver
        UiTextBox入点.ForeDisableColor = Color.Silver
        UiTextBox入点.ForeReadOnlyColor = Color.Silver
        UiTextBox入点.Location = New Point(240, 10)
        UiTextBox入点.Margin = New Padding(4, 5, 4, 5)
        UiTextBox入点.MinimumSize = New Size(1, 16)
        UiTextBox入点.Name = "UiTextBox入点"
        UiTextBox入点.Padding = New Padding(5)
        UiTextBox入点.Radius = 30
        UiTextBox入点.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox入点.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox入点.RectReadOnlyColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiTextBox入点.ShowText = False
        UiTextBox入点.Size = New Size(130, 30)
        UiTextBox入点.TabIndex = 93
        UiTextBox入点.TextAlignment = ContentAlignment.MiddleLeft
        UiTextBox入点.Watermark = "入点"
        UiTextBox入点.WatermarkActiveColor = Color.DimGray
        UiTextBox入点.WatermarkColor = Color.DimGray
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Left
        Label1.Location = New Point(230, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(10, 30)
        Label1.TabIndex = 95
        ' 
        ' UiButton定为入点
        ' 
        UiButton定为入点.Dock = DockStyle.Left
        UiButton定为入点.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为入点.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为入点.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton定为入点.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为入点.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton定为入点.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton定为入点.Font = New Font("微软雅黑", 10F)
        UiButton定为入点.ForeColor = Color.Silver
        UiButton定为入点.ForeDisableColor = Color.Silver
        UiButton定为入点.ForeHoverColor = Color.Silver
        UiButton定为入点.ForePressColor = Color.Silver
        UiButton定为入点.ForeSelectedColor = Color.Silver
        UiButton定为入点.Location = New Point(120, 10)
        UiButton定为入点.MinimumSize = New Size(1, 1)
        UiButton定为入点.Name = "UiButton定为入点"
        UiButton定为入点.Radius = 30
        UiButton定为入点.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为入点.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton定为入点.RectHoverColor = Color.DarkGray
        UiButton定为入点.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton定为入点.RectSelectedColor = Color.DarkGray
        UiButton定为入点.Size = New Size(110, 30)
        UiButton定为入点.TabIndex = 94
        UiButton定为入点.Text = "定为入点"
        UiButton定为入点.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' Label8
        ' 
        Label8.Dock = DockStyle.Left
        Label8.Location = New Point(110, 10)
        Label8.Name = "Label8"
        Label8.Size = New Size(10, 30)
        Label8.TabIndex = 102
        ' 
        ' UiButton去入点
        ' 
        UiButton去入点.Dock = DockStyle.Left
        UiButton去入点.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去入点.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去入点.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton去入点.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去入点.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton去入点.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton去入点.Font = New Font("微软雅黑", 10F)
        UiButton去入点.ForeColor = Color.Silver
        UiButton去入点.ForeDisableColor = Color.Silver
        UiButton去入点.ForeHoverColor = Color.Silver
        UiButton去入点.ForePressColor = Color.Silver
        UiButton去入点.ForeSelectedColor = Color.Silver
        UiButton去入点.Location = New Point(10, 10)
        UiButton去入点.MinimumSize = New Size(1, 1)
        UiButton去入点.Name = "UiButton去入点"
        UiButton去入点.Radius = 30
        UiButton去入点.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去入点.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton去入点.RectHoverColor = Color.DarkGray
        UiButton去入点.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton去入点.RectSelectedColor = Color.DarkGray
        UiButton去入点.Size = New Size(80, 30)
        UiButton去入点.TabIndex = 100
        UiButton去入点.Text = "去入点"
        UiButton去入点.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' Label2
        ' 
        Label2.Dock = DockStyle.Left
        Label2.Location = New Point(90, 10)
        Label2.Name = "Label2"
        Label2.Size = New Size(10, 30)
        Label2.TabIndex = 1
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Left
        Label3.Location = New Point(250, 10)
        Label3.Name = "Label3"
        Label3.Size = New Size(10, 30)
        Label3.TabIndex = 2
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Left
        Label4.Location = New Point(170, 10)
        Label4.Name = "Label4"
        Label4.Size = New Size(10, 30)
        Label4.TabIndex = 5
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Left
        Label5.Location = New Point(350, 10)
        Label5.Name = "Label5"
        Label5.Size = New Size(10, 30)
        Label5.TabIndex = 7
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(UiButton给3FUI)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(UiButton进1帧)
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(UiButton倒半秒)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(UiButton停止)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(UiButton暂停)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(UiButton播放)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(UiButton打开)
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 525)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(10, 10, 10, 0)
        Panel3.Size = New Size(900, 40)
        Panel3.TabIndex = 3
        ' 
        ' UiButton给3FUI
        ' 
        UiButton给3FUI.Dock = DockStyle.Left
        UiButton给3FUI.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton给3FUI.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton给3FUI.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton给3FUI.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton给3FUI.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton给3FUI.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton给3FUI.Font = New Font("微软雅黑", 10F)
        UiButton给3FUI.ForeColor = Color.Silver
        UiButton给3FUI.ForeDisableColor = Color.Silver
        UiButton给3FUI.ForeHoverColor = Color.Silver
        UiButton给3FUI.ForePressColor = Color.Silver
        UiButton给3FUI.ForeSelectedColor = Color.Silver
        UiButton给3FUI.Location = New Point(550, 10)
        UiButton给3FUI.MinimumSize = New Size(1, 1)
        UiButton给3FUI.Name = "UiButton给3FUI"
        UiButton给3FUI.Radius = 30
        UiButton给3FUI.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton给3FUI.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton给3FUI.RectHoverColor = Color.DarkGray
        UiButton给3FUI.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton给3FUI.RectSelectedColor = Color.DarkGray
        UiButton给3FUI.Size = New Size(90, 30)
        UiButton给3FUI.TabIndex = 93
        UiButton给3FUI.Text = "给 3FUI"
        UiButton给3FUI.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' Label11
        ' 
        Label11.Dock = DockStyle.Left
        Label11.Location = New Point(540, 10)
        Label11.Name = "Label11"
        Label11.Size = New Size(10, 30)
        Label11.TabIndex = 92
        ' 
        ' UiButton进1帧
        ' 
        UiButton进1帧.Dock = DockStyle.Left
        UiButton进1帧.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton进1帧.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton进1帧.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton进1帧.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton进1帧.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton进1帧.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton进1帧.Font = New Font("微软雅黑", 10F)
        UiButton进1帧.ForeColor = Color.Silver
        UiButton进1帧.ForeDisableColor = Color.Silver
        UiButton进1帧.ForeHoverColor = Color.Silver
        UiButton进1帧.ForePressColor = Color.Silver
        UiButton进1帧.ForeSelectedColor = Color.Silver
        UiButton进1帧.Location = New Point(455, 10)
        UiButton进1帧.MinimumSize = New Size(1, 1)
        UiButton进1帧.Name = "UiButton进1帧"
        UiButton进1帧.Radius = 30
        UiButton进1帧.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton进1帧.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton进1帧.RectHoverColor = Color.DarkGray
        UiButton进1帧.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton进1帧.RectSelectedColor = Color.DarkGray
        UiButton进1帧.Size = New Size(85, 30)
        UiButton进1帧.TabIndex = 91
        UiButton进1帧.Text = "进一帧"
        UiButton进1帧.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' Label10
        ' 
        Label10.Dock = DockStyle.Left
        Label10.Location = New Point(445, 10)
        Label10.Name = "Label10"
        Label10.Size = New Size(10, 30)
        Label10.TabIndex = 90
        ' 
        ' UiButton倒半秒
        ' 
        UiButton倒半秒.Dock = DockStyle.Left
        UiButton倒半秒.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton倒半秒.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton倒半秒.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton倒半秒.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton倒半秒.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton倒半秒.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton倒半秒.Font = New Font("微软雅黑", 10F)
        UiButton倒半秒.ForeColor = Color.Silver
        UiButton倒半秒.ForeDisableColor = Color.Silver
        UiButton倒半秒.ForeHoverColor = Color.Silver
        UiButton倒半秒.ForePressColor = Color.Silver
        UiButton倒半秒.ForeSelectedColor = Color.Silver
        UiButton倒半秒.Location = New Point(360, 10)
        UiButton倒半秒.MinimumSize = New Size(1, 1)
        UiButton倒半秒.Name = "UiButton倒半秒"
        UiButton倒半秒.Radius = 30
        UiButton倒半秒.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton倒半秒.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton倒半秒.RectHoverColor = Color.DarkGray
        UiButton倒半秒.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton倒半秒.RectSelectedColor = Color.DarkGray
        UiButton倒半秒.Size = New Size(85, 30)
        UiButton倒半秒.TabIndex = 89
        UiButton倒半秒.Text = "倒半秒"
        UiButton倒半秒.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' UiButton停止
        ' 
        UiButton停止.Dock = DockStyle.Left
        UiButton停止.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton停止.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton停止.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton停止.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton停止.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton停止.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton停止.Font = New Font("微软雅黑", 10F)
        UiButton停止.ForeColor = Color.Silver
        UiButton停止.ForeDisableColor = Color.Silver
        UiButton停止.ForeHoverColor = Color.Silver
        UiButton停止.ForePressColor = Color.Silver
        UiButton停止.ForeSelectedColor = Color.Silver
        UiButton停止.Location = New Point(280, 10)
        UiButton停止.MinimumSize = New Size(1, 1)
        UiButton停止.Name = "UiButton停止"
        UiButton停止.Radius = 30
        UiButton停止.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton停止.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton停止.RectHoverColor = Color.DarkGray
        UiButton停止.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton停止.RectSelectedColor = Color.DarkGray
        UiButton停止.Size = New Size(70, 30)
        UiButton停止.TabIndex = 88
        UiButton停止.Text = "停止"
        UiButton停止.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' UiButton暂停
        ' 
        UiButton暂停.Dock = DockStyle.Left
        UiButton暂停.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton暂停.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton暂停.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton暂停.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton暂停.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton暂停.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton暂停.Font = New Font("微软雅黑", 10F)
        UiButton暂停.ForeColor = Color.Silver
        UiButton暂停.ForeDisableColor = Color.Silver
        UiButton暂停.ForeHoverColor = Color.Silver
        UiButton暂停.ForePressColor = Color.Silver
        UiButton暂停.ForeSelectedColor = Color.Silver
        UiButton暂停.Location = New Point(200, 10)
        UiButton暂停.MinimumSize = New Size(1, 1)
        UiButton暂停.Name = "UiButton暂停"
        UiButton暂停.Radius = 30
        UiButton暂停.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton暂停.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton暂停.RectHoverColor = Color.DarkGray
        UiButton暂停.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton暂停.RectSelectedColor = Color.DarkGray
        UiButton暂停.Size = New Size(70, 30)
        UiButton暂停.TabIndex = 87
        UiButton暂停.Text = "暂停"
        UiButton暂停.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' UiButton播放
        ' 
        UiButton播放.Dock = DockStyle.Left
        UiButton播放.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton播放.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton播放.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton播放.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton播放.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton播放.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton播放.Font = New Font("微软雅黑", 10F)
        UiButton播放.ForeColor = Color.Silver
        UiButton播放.ForeDisableColor = Color.Silver
        UiButton播放.ForeHoverColor = Color.Silver
        UiButton播放.ForePressColor = Color.Silver
        UiButton播放.ForeSelectedColor = Color.Silver
        UiButton播放.Location = New Point(120, 10)
        UiButton播放.MinimumSize = New Size(1, 1)
        UiButton播放.Name = "UiButton播放"
        UiButton播放.Radius = 30
        UiButton播放.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton播放.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton播放.RectHoverColor = Color.DarkGray
        UiButton播放.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton播放.RectSelectedColor = Color.DarkGray
        UiButton播放.Size = New Size(70, 30)
        UiButton播放.TabIndex = 86
        UiButton播放.Text = "播放"
        UiButton播放.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' UiButton打开
        ' 
        UiButton打开.Dock = DockStyle.Left
        UiButton打开.FillColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton打开.FillColor2 = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton打开.FillDisableColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiButton打开.FillHoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton打开.FillPressColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton打开.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton打开.Font = New Font("微软雅黑", 10F)
        UiButton打开.ForeColor = Color.Silver
        UiButton打开.ForeDisableColor = Color.Silver
        UiButton打开.ForeHoverColor = Color.Silver
        UiButton打开.ForePressColor = Color.Silver
        UiButton打开.ForeSelectedColor = Color.Silver
        UiButton打开.Location = New Point(10, 10)
        UiButton打开.MinimumSize = New Size(1, 1)
        UiButton打开.Name = "UiButton打开"
        UiButton打开.Radius = 30
        UiButton打开.RectColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton打开.RectDisableColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiButton打开.RectHoverColor = Color.DarkGray
        UiButton打开.RectPressColor = Color.FromArgb(CByte(64), CByte(148), CByte(64))
        UiButton打开.RectSelectedColor = Color.DarkGray
        UiButton打开.Size = New Size(70, 30)
        UiButton打开.TabIndex = 85
        UiButton打开.Text = "打开"
        UiButton打开.TipsFont = New Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        ClientSize = New Size(900, 615)
        Controls.Add(VideoView1)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Font = New Font("微软雅黑", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.Silver
        Name = "Form1"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "3FUI Video Helper"
        CType(VideoView1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents VideoView1 As LibVLCSharp.WinForms.VideoView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents UiButton倒半秒 As Sunny.UI.UIButton
    Friend WithEvents UiButton停止 As Sunny.UI.UIButton
    Friend WithEvents UiButton暂停 As Sunny.UI.UIButton
    Friend WithEvents UiButton播放 As Sunny.UI.UIButton
    Friend WithEvents UiButton打开 As Sunny.UI.UIButton
    Friend WithEvents UiTextBox入点 As Sunny.UI.UITextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents UiButton定为入点 As Sunny.UI.UIButton
    Friend WithEvents UiButton去出点 As Sunny.UI.UIButton
    Friend WithEvents Label9 As Label
    Friend WithEvents UiButton定为出点 As Sunny.UI.UIButton
    Friend WithEvents Label7 As Label
    Friend WithEvents UiTextBox出点 As Sunny.UI.UITextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents UiButton去入点 As Sunny.UI.UIButton
    Friend WithEvents UiButton进1帧 As Sunny.UI.UIButton
    Friend WithEvents Label10 As Label
    Friend WithEvents UiButton给3FUI As Sunny.UI.UIButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel4 As Panel

End Class