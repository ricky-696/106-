Public Class Form1
    Dim rno As Integer, ans As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        For a = 1 To 2
            Input(a, rno)
            For b = 1 To rno
                Dim s As String = LineInput(a)
                Dim d() = Split(s, ","), x As New List(Of String)
                puzzle(d(0), "", x)
                ans = ans & find(x(d(1) - 1), x(d(2) - 1)) & vbNewLine
            Next
            ans = ans & vbNewLine
        Next
        FileOpen(3, "out.txt", OpenMode.Output)
        Print(3, ans) : FileClose(1) : FileClose(2) : FileClose(3) : Me.Close()
    End Sub
    Sub puzzle(ByVal s As String, ByVal s1 As String, ByRef x As List(Of String))
        If s = "" Then
            x.Add(s1)
        Else
            For i = 1 To s.Length
                puzzle(s.Remove(i - 1, 1), s1 & Mid(s, i, 1), x)
            Next
        End If
    End Sub
    Function find(ByVal s As String, ByVal s1 As String)
        Dim a As Integer = 0, b As Integer = 0
        Dim x As New List(Of String), y As New List(Of String)
        For i = 1 To s.Length
            x.Add(Mid(s, i, 1)) : y.Add(Mid(s1, i, 1))
        Next
        For i = 0 To x.Count - 1
            If x(i) = y(i) Then a = a + 1 : x(i) = "" : y(i) = ""
        Next
        For i = 0 To x.Count - 1
            If x(i) <> "" Then
                For j = 0 To y.Count - 1
                    If y(j) <> "" And x(i) = y(j) Then b = b + 1
                Next
            End If
        Next
        Return a & "A" & b & "B"
    End Function
End Class
