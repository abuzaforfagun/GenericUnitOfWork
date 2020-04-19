# Generic Unit Of Work

A .NETStandard package to plug and play with unit of work pattern in EntityFrameworkCore.

## Uses
* Add the reference of the library or install nuget package.
* Register the library in ConfigureServices ```services.AddUnitOfWork<AppDbContext>();```. **AddUnitOfWork** is a generic method. You need to pass your database context.
* Use **IUnitOfWork** using constractor dependency injection. 
```
public EmployeesController(IUnitOfWork unitOfWork)
{
    _unitOfWork = unitOfWork;
}
```
* Access your entity repository using ```_unitOfWork.Repository<Employee>()```.
* Do your operation using the available methods.

## Sample code
Check out the complete sample project [inside sample folder](https://github.com/abuzaforfagun/GenericUnitOfWork/tree/master/GenericUnitOfWork.Sample).

