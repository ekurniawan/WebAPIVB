Module Module1

    Sub Main()
        Dim myObj As New MyHelper
        Dim nama = "Erick"
        Dim result = myObj.Hello(nama)
        Console.WriteLine(result)
        Console.WriteLine(nama)
    End Sub

End Module

Public Class MyHelper
    Public Function Hello(ByRef nama As String) As String
        Dim result = $"Hallo {nama}"
        nama = "Joko"
        Return result
    End Function
End Class