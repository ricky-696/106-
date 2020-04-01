Public Class Form1
    Dim rno As Integer, ans As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        Dim rome() = {"I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"}
        Dim rv() = {1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000}
        For a = 1 To 2
            Input(a, rno)
            For b = 1 To rno
                Dim s As String = LineInput(a), count As Integer = 0
                Do Until s.Length = 0
                    For i = rome.Length - 1 To 0 Step -1
                        Do While Mid(s, 1, rome(i).Length) = rome(i)
                            count = count + rv(i) : s = s.Remove(0, rome(i).Length)
                        Loop
                    Next
                Loop
                ans = ans & count & vbNewLine
            Next
            ans = ans & vbNewLine
        Next
        FileOpen(3, "out.txt", OpenMode.Output)
        Print(3, ans) : FileClose(1) : FileClose(2) : FileClose(3) : Me.Close()
    End Sub
End Class
