Public Class Form1
    Dim rno As Integer, ans As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        For a = 1 To 2
            Input(a, rno)
            For b = 1 To rno
                Dim s As String = LineInput(a), count As Integer = 0
                Do Until InStr(s, "  ") = 0
                    s = s.Replace("  ", " ")
                Loop
                Dim d() = Split(s, " ")
                For i = 0 To d.Length - 1
                    Dim check As Boolean = False
                    For j = 1 To d(i).Length
                        If LCase(Mid(d(i), j, 1)) = "s" Then check = True : Exit For
                    Next
                    If check = True Then count = count + 1
                Next
                ans = ans & count & vbNewLine
            Next
            ans = ans & vbNewLine
        Next
        FileOpen(3, "out.txt", OpenMode.Output)
        Print(3, ans) : FileClose(1) : FileClose(2) : FileClose(3) : Me.Close()
    End Sub
End Class
