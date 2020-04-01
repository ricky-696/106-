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
                Dim d() = Split(s, " "), road As New List(Of String), check As Boolean = False
                For i = 0 To d.Length - 1
                    road.Add(d(i)) : Dim d1() = Split(d(i), ","), visited As New List(Of Integer)
                    If cycle(road, d1(0), d1(0), visited, True) Then
                        check = True : visited.Sort()
                        For j = 0 To visited.Count - 1
                            ans = ans & visited(j) & ", "
                        Next
                        ans = ans.Remove(ans.Length - 2, 2) & vbNewLine : Exit For
                    End If
                Next
                If check = False Then
                    Dim d1() = Split(d(0), ",")
                    walk(d, d1(0))
                    For i = 0 To d.Length - 1
                        If d(i) <> "" Then check = True : Exit For
                    Next
                    If check = True Then ans = ans & "F" & vbNewLine Else ans = ans & "T" & vbNewLine
                End If
            Next
            ans = ans & vbNewLine
        Next
        FileOpen(3, "out.txt", OpenMode.Output)
        Print(3, ans) : FileClose(1) : FileClose(2) : FileClose(3) : Me.Close()
    End Sub
    Function cycle(ByVal tree As List(Of String), ByVal root As Integer, ByVal kid As Integer, ByRef visited As List(Of Integer), ByVal first As Boolean)
        If root = kid And first = False Then Return True
        visited.Add(kid)
        For i = 0 To tree.Count - 1
            Dim d() = Split(tree(i), ",")
            If d(0) = kid Then
                Dim way As New List(Of String)
                For j = 0 To tree.Count - 1
                    If i <> j Then way.Add(tree(j))
                Next
                If cycle(way, root, d(1), visited, False) Then Return True
            End If
            If d(1) = kid Then
                Dim way As New List(Of String)
                For j = 0 To tree.Count - 1
                    If i <> j Then way.Add(tree(j))
                Next
                If cycle(way, root, d(0), visited, False) Then Return True
            End If
        Next
        visited.Remove(kid) : Return False
    End Function
    Sub walk(ByVal d() As String, ByVal root As Integer)
        For i = 0 To d.Length - 1
            If d(i) <> "" Then
                Dim d1() = Split(d(i), ",")
                If d1(0) = root Then
                    d(i) = "" : walk(d, d1(1))
                End If
                If d1(1) = root Then
                    d(i) = "" : walk(d, d1(0))
                End If
            End If
        Next
    End Sub
End Class
