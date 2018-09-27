Imports System.Web.Mvc

Namespace Controllers
    Public Class MahasiswaRestsharpController
        Inherits Controller

        Private _services As MahasiswaServicesRestsharp

        Public Sub New()
            _services = New MahasiswaServicesRestsharp()
        End Sub

        ' GET: MahasiswaRestsharp
        Function Index() As ActionResult
            Dim results = _services.GetAll()
            Return View(results)
        End Function

        ' GET: MahasiswaRestsharp/Details/5
        Function Details(id As String) As ActionResult
            Dim result = _services.GetById(id)
            'ViewBag.Nama = result.Nama
            'ViewData("IPK") = result.IPK
            Return View(result)
        End Function

        ' GET: MahasiswaRestsharp/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: MahasiswaRestsharp/Create
        <HttpPost()>
        Function Create(mhs As Mahasiswa) As ActionResult
            Try
                _services.InsertData(mhs)
                Return RedirectToAction("Index")
            Catch ex As Exception
                ViewBag.Error = $"Error: {ex.Message}"
                Return View(mhs)
            End Try
        End Function

        ' GET: MahasiswaRestsharp/Edit/5
        Function Edit(id As String) As ActionResult
            Dim result = _services.GetById(id)
            Return View(result)
        End Function

        ' POST: MahasiswaRestsharp/Edit/5
        <HttpPost()>
        Function Edit(mhs As Mahasiswa) As ActionResult
            Try
                _services.UpdateData(mhs)
                Return RedirectToAction("Index")
            Catch ex As Exception
                ViewBag.Error = $"Error: {ex.Message}"
                Return View()
            End Try
        End Function

        ' GET: MahasiswaRestsharp/Delete/5
        Function Delete(id As String) As ActionResult
            Dim result = _services.GetById(id)
            Return View(result)
        End Function

        ' POST: MahasiswaRestsharp/Delete/5
        <HttpPost()>
        Function Delete(mhs As Mahasiswa) As ActionResult
            Try
                _services.DeleteData(mhs)
                Return RedirectToAction("Index")
            Catch ex As Exception
                ViewBag.Error = $"Error {ex.Message}"
                Return View()
            End Try
        End Function
    End Class
End Namespace