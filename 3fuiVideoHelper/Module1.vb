Imports System.Runtime.InteropServices

Module Module1
    <DllImport("user32.dll")>
    Public Function ReleaseCapture() As Boolean
    End Function
    <DllImport("user32.dll")>
    Public Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2
    Sub 绑定拖动控件移动窗体(s As Control)
        AddHandler s.MouseDown, Sub(s1, e1)
                                    Select Case e1.Button
                                        Case MouseButtons.Left
                                            ReleaseCapture()
                                            Dim unused = SendMessage(s1.FindForm().Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
                                    End Select
                                End Sub
    End Sub
End Module
