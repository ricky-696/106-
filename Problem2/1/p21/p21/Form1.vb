Public Class Form1
    Dim rno As Integer, ans As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        For a = 1 To 2
            Input(a, rno)
            For b = 1 To rno
                Dim s As String = LineInput(a)
                Dim n As New List(Of Integer), count As Integer = 1
                For i = s.Length To 1 Step -1
                    If count Mod 2 = 0 Then
                        n.Add(Val(Mid(s, i, 1)) * 2)
                    Else
                        n.Add(Val(Mid(s, i, 1)))
                    End If
                    If n(n.Count - 1) >= 10 Then n(n.Count - 1) = n(n.Count - 1) - 9
                    count = count + 1
                Next
                Dim total As Integer = 0
                For i = 0 To n.Count - 1
                    total = total + n(i)
                Next
                If total Mod 10 = 0 Then ans = ans & "T" & vbNewLine Else ans = ans & "F" & vbNewLine
            Next
            ans = ans & vbNewLine
        Next
        FileOpen(3, "out.txt", OpenMode.Output)
        Print(3, ans) : FileClose(1) : FileClose(2) : FileClose(3) : Me.Close()
    End Sub
End Class
