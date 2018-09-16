Imports System.Threading.Tasks
Imports System.Web.Mvc

Namespace Controllers
    Public Class MahasiswaController
        Inherits Controller

        Private _mhsService As MahasiswaServices

        Public Sub New()
            _mhsService = New MahasiswaServices()
        End Sub

        ' GET: Mahasiswa
        Async Function Index() As Task(Of ActionResult)
            Dim results = Await _mhsService.GetAllAsync()
            Return View(results)
        End Function

        <HttpPost>
        Async Function SearchByName(nama As String) As Task(Of ActionResult)
            Dim results = Await _mhsService.SearchByNameAsync(nama)
            Return View("Index", results)
        End Function


        ' GET: Mahasiswa/Details/5
        Async Function Details(id As String) As Task(Of ActionResult)
            Dim result = Await _mhsService.GetByIdAsync(id)
            Return View(result)
        End Function

        ' GET: Mahasiswa/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Mahasiswa/Create
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Async Function Create(mhs As Mahasiswa) As Task(Of ActionResult)
            Try
                Await _mhsService.InsertAsync(mhs)
                Return RedirectToAction("Index")
            Catch
                Return View(mhs)
            End Try
        End Function

        ' GET: Mahasiswa/Edit/5
        Async Function Edit(id As String) As Task(Of ActionResult)
            Dim result = Await _mhsService.GetByIdAsync(id)
            Return View(result)
        End Function

        ' POST: Mahasiswa/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken>
        <ActionName("Edit")>
        Async Function EditPost(mhs As Mahasiswa) As Task(Of ActionResult)
            Try
                Await _mhsService.UpdateAsync(mhs)
                Return RedirectToAction("Index")
            Catch
                Return View(mhs)
            End Try
        End Function

        ' GET: Mahasiswa/Delete/5
        Async Function Delete(id As String) As Task(Of ActionResult)
            Dim result = Await _mhsService.GetByIdAsync(id)
            Return View(result)
        End Function

        ' POST: Mahasiswa/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        Async Function DeletePost(mhs As Mahasiswa) As Task(Of ActionResult)
            Try
                Await _mhsService.DeleteAsync(mhs)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace