# Generic Unit Of Work

A .NETStandard package to plug and play with unit of work pattern in EntityFrameworkCore.

## Uses
* Add the reference of the library or install [nuget package](https://www.nuget.org/packages/EntityFrameworkCore.GenericUnitOfWork/) following by ```Install-Package EntityFrameworkCore.GenericUnitOfWork``` command from visual studio package manager console or ```dotnet add package EntityFrameworkCore.GenericUnitOfWork``` from command line.
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


### Basic uses of GenericUnitOfWork in controlelr

```
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        _unitOfWork.Repository<Employee>().Add(employee);
        await _unitOfWork.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _unitOfWork.Repository<Employee>().GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _unitOfWork.Repository<Employee>().GetQuery().Include(e => e.Department).SingleAsync(e => e.Id == id));


    [HttpPut]
    public async Task<IActionResult> Update(Employee employee)
    {
        _unitOfWork.Repository<Employee>().Update(employee);
        await _unitOfWork.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Employee employee)
    {
        _unitOfWork.Repository<Employee>().Remove(employee);
        await _unitOfWork.SaveChangesAsync();
        return Ok();
    }
}
```