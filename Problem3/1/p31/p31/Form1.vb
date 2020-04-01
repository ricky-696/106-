Public Class Form1
    Dim rno As Integer, ans As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        For a = 1 To 2
            Input(a, rno)
            For b = 1 To rno
                Dim s As String = LineInput(a)
                Dim d() = Split(s, "/")
                Dim d1() = Split(d(0), "."), d2() = Split(d(1), ".")
                Dim id1 As New List(Of Integer), id2 As New List(Of Integer)
                For i = 0 To d1.Length - 1
                    id1.Add(d1(i)) : id2.Add(d2(i))
                Next
                For i = 0 To id2.Count - 1
                    id1(i) = Convert.ToString(id1(i), 2) : id2(i) = Convert.ToString(id2(i), 2)
                Next
                For i = 0 To id1.Count - 1
                    Dim x As String = id1(i), y As String = id2(i)
                    Do Until x.Length = 8
                        x = "0" & x
                    Loop
                    Do Until y.Length = 8
                        y = "0" & y
                    Loop
                    For j = 1 To y.Length
                        If Mid(y, j, 1) = "1" Then Mid(y, j, 1) = "0" Else Mid(y, j, 1) = "1"
                    Next
                    Dim xy As String = ""
                    For j = 1 To x.Length
                        If Mid(x, j, 1) = "0" And Mid(y, j, 1) = "0" Then xy = xy & "0" Else xy = xy & "1"
                    Next
                    ans = ans & Convert.ToUInt16(xy, 2) & "."
                Next
                ans = ans.Remove(ans.Length - 1, 1) & vbNewLine
            Next
            ans = ans & vbNewLine
        Next
        FileOpen(3, "out.txt", OpenMode.Output)
        Print(3, ans) : FileClose(1) : FileClose(2) : FileClose(3) : Me.Close()
    End Sub
End Class
