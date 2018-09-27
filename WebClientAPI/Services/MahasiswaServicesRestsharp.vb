Imports System.Threading.Tasks
Imports RestSharp

Public Class MahasiswaServicesRestsharp
    Private _client As RestClient

    Public Sub New()
        _client = New RestClient("http://localhost:52965")
    End Sub

    Public Function GetAll() As IEnumerable(Of Mahasiswa)
        Dim request = New RestRequest("api/Mahasiswa", Method.GET) With {
            .RequestFormat = DataFormat.Json}
        Dim response = _client.Execute(Of List(Of Mahasiswa))(request)
        If response.Data Is Nothing Then
            Throw New Exception(response.ErrorMessage)
        End If

        Return response.Data
    End Function

    Public Function GetById(nim As String) As Mahasiswa
        Dim request = New RestRequest("api/Mahasiswa/{id}", Method.GET) With {
            .RequestFormat = DataFormat.Json}
        request.AddParameter("id", nim, ParameterType.UrlSegment)
        Dim response = _client.Execute(Of Mahasiswa)(request)
        If response.Data Is Nothing Then
            Throw New Exception(response.ErrorMessage)
        End If

        Return response.Data
    End Function

    Public Sub InsertData(mhs As Mahasiswa)
        Dim request = New RestRequest("api/Mahasiswa", Method.POST) With {
            .RequestFormat = DataFormat.Json}
        request.AddBody(mhs)
        Dim response = _client.Execute(request)
        If response.StatusCode <> Net.HttpStatusCode.OK Then
            Throw New Exception($"Gagal Insert Data {response.ErrorMessage} {response.StatusCode}")
        End If
    End Sub

    Public Sub UpdateData(mhs As Mahasiswa)
        Dim request = New RestRequest("api/Mahasiswa/{id}", Method.PUT) With {
            .RequestFormat = DataFormat.Json}
        request.AddParameter("id", mhs.Nim, ParameterType.UrlSegment)
        request.AddBody(mhs)

        Dim response = _client.Execute(request)
        If response.StatusCode <> Net.HttpStatusCode.OK Then
            Throw New Exception($"Gagal Update Data {response.ErrorMessage}")
        End If
    End Sub

    Public Sub DeleteData(mhs As Mahasiswa)
        Dim request = New RestRequest("api/Mahasiswa/{id}", Method.DELETE) With {
            .RequestFormat = DataFormat.Json}
        request.AddParameter("id", mhs.Nim, ParameterType.UrlSegment)

        Dim response = _client.Execute(request)
        If response.StatusCode <> Net.HttpStatusCode.OK Then
            Throw New Exception($"Gagal Delete Data {response.ErrorMessage}")
        End If
    End Sub

End Class
