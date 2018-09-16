Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class MahasiswaServices
    Private _baseUrl As String = "http://localhost:52965"
    Private _httpClient As HttpClient

    Public Sub New()
        _httpClient = New HttpClient()
    End Sub

    Public Async Function GetAllAsync() As Task(Of IEnumerable(Of Mahasiswa))
        Dim listMahasiswa As List(Of Mahasiswa)
        Dim _uri = $"{_baseUrl}/api/Mahasiswa"
        Dim _response = Await _httpClient.GetAsync(_uri)
        If _response.IsSuccessStatusCode Then
            Dim _content = Await _response.Content.ReadAsStringAsync()
            listMahasiswa = JsonConvert.DeserializeObject(Of List(Of Mahasiswa))(_content)
            Return listMahasiswa
        Else
            Throw New Exception("Request data gagal")
        End If
    End Function

    Public Async Function SearchByNameAsync(nama As String) As Task(Of IEnumerable(Of Mahasiswa))
        Dim listMahasiswa As List(Of Mahasiswa)
        Dim _uri = $"{_baseUrl}/api/Mahasiswa/GetByName?nama={nama}"
        Dim _response = Await _httpClient.GetAsync(_uri)
        If _response.IsSuccessStatusCode Then
            Dim _content = Await _response.Content.ReadAsStringAsync()
            listMahasiswa = JsonConvert.DeserializeObject(Of List(Of Mahasiswa))(_content)
            Return listMahasiswa
        Else
            Throw New Exception($"Error:{_response.StatusCode}")
        End If
    End Function

    Public Async Function GetByIdAsync(_nim As String) As Task(Of Mahasiswa)
        Dim resultMhs As Mahasiswa
        Dim _uri = $"{_baseUrl}/api/Mahasiswa/{_nim}"
        Dim _response = Await _httpClient.GetAsync(_uri)
        If _response.IsSuccessStatusCode Then
            Dim _content = Await _response.Content.ReadAsStringAsync()
            resultMhs = JsonConvert.DeserializeObject(Of Mahasiswa)(_content)
            Return resultMhs
        Else
            Throw New Exception($"Data nim {_nim} tidak ditemukan")
        End If
    End Function

    Public Async Function InsertAsync(mhs As Mahasiswa) As Task
        Dim _uri = $"{_baseUrl}/api/Mahasiswa"
        Try
            Dim jsonData = JsonConvert.SerializeObject(mhs)
            Dim _content As New StringContent(jsonData, Encoding.UTF8, "application/json")
            Dim _response = Await _httpClient.PostAsync(_uri, _content)
            If Not _response.IsSuccessStatusCode Then
                Throw New Exception($"Error:{_response.StatusCode}")
            End If
        Catch ex As Exception
            Throw New Exception($"Error:{ex.Message}")
        End Try
    End Function

    Public Async Function UpdateAsync(mhs As Mahasiswa) As Task
        Dim _uri = $"{_baseUrl}/api/Mahasiswa/{mhs.Nim}"
        Try
            Dim jsonData = JsonConvert.SerializeObject(mhs)
            Dim _content As New StringContent(jsonData, Encoding.UTF8, "application/json")
            Dim _response = Await _httpClient.PutAsync(_uri, _content)
            If Not _response.IsSuccessStatusCode Then
                Throw New Exception($"Error:{_response.StatusCode}")
            End If
        Catch ex As Exception
            Throw New Exception($"Error:{ex.Message}")
        End Try
    End Function

    Public Async Function DeleteAsync(mhs As Mahasiswa) As Task

        Dim _uri = $"{_baseUrl}/api/Mahasiswa/{mhs.Nim}"
        Try
            Dim _response = Await _httpClient.DeleteAsync(_uri)
            If Not _response.IsSuccessStatusCode Then
                Throw New Exception($"Error:{_response.StatusCode}")
            End If
        Catch ex As Exception
            Throw New Exception($"Error:{ex.Message}")
        End Try
    End Function

End Class
