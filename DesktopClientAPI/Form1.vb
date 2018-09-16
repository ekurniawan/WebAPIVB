Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class Form1

    Private _baseUrl As String = "http://localhost:52965"
    Private _httpClient As HttpClient

    Public Sub New()
        InitializeComponent()
        _httpClient = New HttpClient()
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Dim listMahasiswa As List(Of Mahasiswa)
        Dim _uri = $"{_baseUrl}/api/Mahasiswa"
        Dim _response = _httpClient.GetAsync(_uri).Result
        If _response.IsSuccessStatusCode Then
            'MessageBox.Show($"Data {_response.Headers.ToString()}", "Keterangan")
            'Dim _content = Await _response.Content.ReadAsStringAsync()

            'MessageBox.Show($"Data {_content}", "Keterangan")
            'Debug.WriteLine($"Data {_content}")

            Dim _content = _response.Content.ReadAsStringAsync().Result
            listMahasiswa =
            JsonConvert.DeserializeObject(Of List(Of Mahasiswa))(_content)
            gvMahasiswa.DataSource = listMahasiswa
            'MessageBox.Show($"Data: {_content}", "Keterangan")
        Else
            MessageBox.Show("Gagal request data", "Keterangan")
        End If
    End Sub

    Private Async Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim resultMhs As Mahasiswa
        Dim _nim = txtSearch.Text
        Dim _uri = $"{_baseUrl}/api/Mahasiswa/{_nim}"
        Dim _response = Await _httpClient.GetAsync(_uri)
        If _response.IsSuccessStatusCode Then
            Dim _content = Await _response.Content.ReadAsStringAsync()
            resultMhs = JsonConvert.DeserializeObject(Of Mahasiswa)(_content)
            'MessageBox.Show($"Nim: {resultMhs.Nim} - Nama:{resultMhs.Nama} - IPK:{resultMhs.IPK}", "OK")
            txtNim.Text = resultMhs.Nim
            txtNama.Text = resultMhs.Nama
            txtIPK.Text = resultMhs.IPK.ToString()
        Else
            MessageBox.Show("Gagal request data", "Keterangan")
        End If
    End Sub

    Private Async Sub btnSearchByName_Click(sender As Object, e As EventArgs) Handles btnSearchByName.Click
        Dim listMahasiswa As List(Of Mahasiswa)
        Dim _search = txtSearch.Text
        Dim _uri = $"{_baseUrl}/api/Mahasiswa/GetByName?nama={_search}"
        Dim _response = Await _httpClient.GetAsync(_uri)
        If _response.IsSuccessStatusCode Then
            Dim _content = Await _response.Content.ReadAsStringAsync()
            listMahasiswa = JsonConvert.DeserializeObject(Of List(Of Mahasiswa))(_content)
            gvMahasiswa.DataSource = listMahasiswa
        End If
    End Sub

    Private Async Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim _uri = $"{_baseUrl}/api/Mahasiswa"
        Dim newMhs As New Mahasiswa With {
            .Nim = txtNim.Text, .Nama = txtNama.Text, .IPK = CDbl(txtIPK.Text)}
        Try
            Dim jsonData = JsonConvert.SerializeObject(newMhs)
            Dim _content As New StringContent(jsonData, Encoding.UTF8, "application/json")
            Dim _response = Await _httpClient.PostAsync(_uri, _content)
            If _response.IsSuccessStatusCode Then
                MessageBox.Show("Data berhasil ditambahkan", "Keterangan")
            Else
                MessageBox.Show("Data gagal dikirimkan", "Keterangan")
            End If
        Catch ex As Exception
            MessageBox.Show($"{ex.Message}")
        End Try
    End Sub

    Private Async Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim _nim = txtNim.Text
        Dim _uri = $"{_baseUrl}/api/Mahasiswa/{_nim}"
        Dim editMhs As New Mahasiswa With {
            .Nim = txtNim.Text, .Nama = txtNama.Text, .IPK = CDbl(txtIPK.Text)}
        Try
            Dim jsonData = JsonConvert.SerializeObject(editMhs)
            Dim _content As New StringContent(jsonData, Encoding.UTF8, "application/json")
            Dim _response = Await _httpClient.PutAsync(_uri, _content)
            If _response.IsSuccessStatusCode Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub btnGetAsync_Click(sender As Object, e As EventArgs) Handles btnGetAsync.Click
        Dim listMahasiswa As List(Of Mahasiswa)
        Dim _uri = $"{_baseUrl}/api/Mahasiswa"
        Dim _response = Await _httpClient.GetAsync(_uri)
        If _response.IsSuccessStatusCode Then
            Dim _content = Await _response.Content.ReadAsStringAsync()
            listMahasiswa =
            JsonConvert.DeserializeObject(Of List(Of Mahasiswa))(_content)
            gvMahasiswa.DataSource = listMahasiswa
            'MessageBox.Show($"Data: {_content}", "Keterangan")
        Else
            MessageBox.Show("Gagal request data", "Keterangan")
        End If
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim _nim = txtNim.Text
        Dim _uri = $"{_baseUrl}/api/Mahasiswa/{_nim}"
        Try
            Dim _response = Await _httpClient.DeleteAsync(_uri)
            If _response.IsSuccessStatusCode Then
                MessageBox.Show("Data berhasil di delete", "Keterangan")
            Else
                MessageBox.Show("Data gagal didelete", "Keterangan")
            End If
        Catch ex As Exception
            MessageBox.Show($"{ex.Message}")
        End Try
    End Sub
End Class
