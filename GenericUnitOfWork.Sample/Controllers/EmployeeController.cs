using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GenericUnitOfWork.Sample.Controllers
{
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
}
