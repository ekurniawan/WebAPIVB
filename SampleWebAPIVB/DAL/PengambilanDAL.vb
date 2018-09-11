Imports SampleWebAPIVB
Imports System.Data.SqlClient
Imports Dapper

Public Class PengambilanDAL
    Implements ICrud(Of Pengambilan)

    Public Sub Create(obj As Pengambilan) Implements ICrud(Of Pengambilan).Create
        Throw New NotImplementedException()
    End Sub

    Public Sub Update(obj As Pengambilan) Implements ICrud(Of Pengambilan).Update
        Throw New NotImplementedException()
    End Sub

    Public Sub Delete(id As String) Implements ICrud(Of Pengambilan).Delete
        Throw New NotImplementedException()
    End Sub

    Public Function GetAll() As IEnumerable(Of Pengambilan) Implements ICrud(Of Pengambilan).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As String) As Pengambilan Implements ICrud(Of Pengambilan).GetById
        Throw New NotImplementedException()
    End Function

    Public Function GetAllRelated() As IEnumerable(Of ViewPengambilanLengkap)
        Using conn As New SqlConnection(MyHelper.GetConnStr())
            Dim strSql = "select * from ViewPengambilanLengkap 
                          order by Nama asc"

        End Using
    End Function
End Class
