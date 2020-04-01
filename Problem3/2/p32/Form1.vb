Imports System.Numerics
Public Class Form1
    Dim rno As Integer, ans As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", OpenMode.Input)
        FileOpen(2, "in2.txt", OpenMode.Input)
        For a = 1 To 2
            Input(a, rno)
            For b = 1 To rno
                Dim bign As New List(Of BigInteger)
                Dim s As String = LineInput(a)
                Dim d() = Split(s, ", ")
                For i = 0 To d.Length - 1
                    bign.Add(d(i))
                Next
                bign.Sort()
                For i = 0 To d.Length - 1
                    Dim bigx As New List(Of BigInteger)
                    bigx.Add(d(i))
                    For j = 0 To bign.Count - 1
                        If bigx(0) = bign(j) Then ans = ans & j + 1 & ","
                    Next
                Next
                ans = ans.Remove(ans.Length - 1, 1) & vbNewLine
            Next
            ans = ans & vbNewLine
        Next
        FileOpen(3, "out.txt", OpenMode.Output)
        Print(3, ans) : FileClose(1) : FileClose(2) : FileClose(3) : Me.Close()
    End Sub
End Class
