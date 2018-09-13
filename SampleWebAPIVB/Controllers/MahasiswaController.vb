Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class MahasiswaController
        Inherits ApiController

        Private mhsDAL As New MahasiswaDAL

        ' GET: api/Mahasiswa
        <HttpGet()>
        Public Function GetValues() As IEnumerable(Of Mahasiswa)
            Return mhsDAL.GetAll()
        End Function

        ' GET: api/Mahasiswa/5
        <HttpGet()>
        Public Function GetValue(id As String) As Mahasiswa
            Return mhsDAL.GetById(id)
        End Function


        <HttpGet()>
        <Route("api/Mahasiswa/GetByName")>
        Public Function GetByName(nama As String) As IEnumerable(Of Mahasiswa)
            Return mhsDAL.GetByName(nama)
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