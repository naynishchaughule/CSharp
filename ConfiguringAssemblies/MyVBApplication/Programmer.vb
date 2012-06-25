Imports EmployeeInformation

Public Class Programmer
    Inherits Employee

    Public Overrides Sub Display()
        Console.WriteLine("Display in Programmer")
        MyBase.Display()
    End Sub

End Class
