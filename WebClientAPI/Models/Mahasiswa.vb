Imports System.ComponentModel.DataAnnotations

Public Class Mahasiswa
    <Required(ErrorMessage:="Data Nim Harus Diisi")>
    Public Property Nim As String
    <Required(ErrorMessage:="Data Nama Harus Diisi")>
    <Display(Name:="Nama Lengkap")>
    Public Property Nama As String
    <Required(ErrorMessage:="Data IPK Harus Diisi")>
    Public Property IPK As Double
End Class
