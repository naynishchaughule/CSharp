Imports EmployeeInformation

Module Module1

    Sub Main()
        Dim vp As VicePresident
        vp = New VicePresident()
        vp.Id = 65985
        vp.Fname = "tripti panjabi"
        vp.Salary = 65000
        Console.WriteLine(vp)

        Dim p As Programmer = New Programmer
        p.Id = 89032
        p.Fname = "jay bhatt"
        p.Salary = 72000
        p.Display()
        Console.ReadLine()
    End Sub

End Module
