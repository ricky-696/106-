Public Class Form1
    Dim rno As Integer, ans As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        For a = 1 To 2
            Input(a, rno)
            For b = 1 To rno
                Dim s As String = LineInput(a)
                Do Until InStr(s, "  ") = 0
                    s = s.Replace("  ", " ")
                Loop
                Dim d() = Split(s, " ")
                Dim n As New Stack(Of String)
                For i = 0 To d.Length - 1
                    If IsNumeric(d(i)) Then
                        n.Push(d(i))
                    Else
                        If d(i) = "+" Then
                            Dim y As Integer = n.Pop, x As Integer = n.Pop
                            n.Push(x + y)
                        ElseIf d(i) = "-" Then
                            Dim y As Integer = n.Pop, x As Integer = n.Pop
                            n.Push(x - y)
                        ElseIf d(i) = "*" Then
                            Dim y As Integer = n.Pop, x As Integer = n.Pop
                            n.Push(x * y)
                        ElseIf d(i) = "/" Then
                            Dim y As Integer = n.Pop, x As Integer = n.Pop
                            n.Push(x / y)
                        End If
                    End If
                Next
                ans = ans & n.Pop & vbNewLine
            Next
            ans = ans & vbNewLine
        Next
        FileOpen(3, "out.txt", OpenMode.Output)
        Print(3, ans) : FileClose(1) : FileClose(2) : FileClose(3) : Me.Close()
    End Sub
End Class
