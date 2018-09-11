Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class MahasiswaController
        Inherits ApiController

        Private lstMhs As New List(Of Mahasiswa) From {
            New Mahasiswa With {
            .Nim = "88888", .Nama = "Erick", .IPK = 3.5},
            New Mahasiswa With {
            .Nim = "99999", .Nama = "Budi", .IPK = 3.2}}

        ' GET: api/Mahasiswa
        <HttpGet()>
        Public Function GetValues() As IEnumerable(Of Mahasiswa)
            Return lstMhs
        End Function

        ' GET: api/Mahasiswa/5
        <HttpGet()>
        Public Function GetValue(id As String) As Mahasiswa
            Dim result = (From mhs In lstMhs
                          Where mhs.Nim = id
                          Select mhs).SingleOrDefault()

            Return result

        End Function

        <Route("api/Mahasiswa/GetByName")>
        <HttpGet()>
        Public Function GetByName(nama As String) As List(Of Mahasiswa)
            Dim results = From mhs In lstMhs
                          Where mhs.Nama = "Erick"
                          Select mhs

            Return results
        End Function

        ' POST: api/Mahasiswa
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Mahasiswa/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Mahasiswa/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace