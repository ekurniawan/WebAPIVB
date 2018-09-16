Imports System.Web.Mvc
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO


Namespace Controllers
    Public Class SaveExcelSampleController
        Inherits Controller

        Private _mhsDAL As MahasiswaDAL

        Public Sub New()
            _mhsDAL = New MahasiswaDAL()
        End Sub


        ' GET: SaveExcelSample
        Function Index() As ActionResult
            Dim lstMhs = _mhsDAL.GetAll()

            Dim dataExcel As New ExcelPackage()
            'membuat worksheet
            Dim myWorksheet = dataExcel.Workbook.Worksheets.Add("MySheet")
            myWorksheet.DefaultRowHeight = 12

            'menambahkan header judul
            myWorksheet.Row(1).Height = 20
            myWorksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
            myWorksheet.Row(1).Style.Font.Bold = True
            myWorksheet.Cells(1, 1).Value = "Daftar Mahasiswa"

            'header table
            myWorksheet.Row(2).Height = 20
            myWorksheet.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
            myWorksheet.Row(2).Style.Font.Bold = True
            myWorksheet.Cells(2, 1).Value = "Nim"
            myWorksheet.Cells(2, 2).Value = "Nama"
            myWorksheet.Cells(2, 3).Value = "IPK"

            Dim recIndex = 3
            For Each _student In lstMhs
                myWorksheet.Cells(recIndex, 1).Value = _student.Nim
                myWorksheet.Cells(recIndex, 2).Value = _student.Nama
                myWorksheet.Cells(recIndex, 3).Value = _student.IPK
                recIndex += 1
            Next

            'ratain kolom
            myWorksheet.Column(1).AutoFit()
            myWorksheet.Column(2).AutoFit()
            myWorksheet.Column(3).AutoFit()

            Dim excelName = "myExcelFileSample.xlsx"
            Dim memStream As New MemoryStream(dataExcel.GetAsByteArray())
            Return File(memStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName)


            'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            'Response.AddHeader("content-disposition", $"attachment; filename={excelName}.xlsx")

            'Using memStream As New MemoryStream
            '    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            '    Response.AddHeader("content-disposition", $"attachment; filename={excelName}.xlsx")
            '    dataExcel.SaveAs(memStream)
            '    memStream.WriteTo(Response.OutputStream)
            '    Response.Flush()
            '    Response.End()

            'End Using

            'Dim memStream As New MemoryStream(dataExcel.GetAsByteArray())

        End Function



    End Class
End Namespace