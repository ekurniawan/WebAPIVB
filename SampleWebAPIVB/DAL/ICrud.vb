Public Interface ICrud(Of T)
    Function GetAll() As IEnumerable(Of T)
    Function GetById(id As String) As T
    Sub Create(obj As T)
    Sub Update(obj As T)
    Sub Delete(id As String)
End Interface
