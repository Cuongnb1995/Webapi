using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        protected readonly EmployeeDbContext _db;
        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get(int? page)
        {
            var kq = _db.Employee.Select(e => new ViewEmployee()
            {
                EmployeeId = e.EmployeeId,
                EmployeeCode = e.EmployeeCode,
                Email = e.Email,
                Gender = e.Gender,
                FullName = e.FullName,
                DateOfBirth = e.DateOfBirth,
                CitizenIdentityCode = e.CitizenIdentityCode,
                CitizebIdentityPlace = e.CitizebIdentityPlace,
                CitizebIdentityDate = e.CitizebIdentityDate,
                PhoneNumber = e.PhoneNumber,
                WorkState = e.WorkState,
                PositionId = e.PositionId,
                DepartmentId = e.DepartmentId,
                SelfTaxCode = e.SelfTaxCode,
                Salary = e.Salary,
                JoinDate = e.JoinDate,
                Department = e.Department.DepartmentName,
                Position = e.Position.PositionName,
            }).ToList();

            var pager = new Pager(kq.Count(), page);
            var vmd = new ViewModelPaging
            {
                ViewEmployee = kq.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };
            return Ok(vmd);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var kq = _db.Employee.Select(e => new ViewEmployee()
            {
                EmployeeId = e.EmployeeId,
                EmployeeCode = e.EmployeeCode,
                Email = e.Email,
                Gender = e.Gender,
                FullName = e.FullName,
                DateOfBirth = e.DateOfBirth,
                CitizenIdentityCode = e.CitizenIdentityCode,
                CitizebIdentityPlace = e.CitizebIdentityPlace,
                CitizebIdentityDate = e.CitizebIdentityDate,
                PhoneNumber = e.PhoneNumber,
                WorkState = e.WorkState,
                PositionId = e.PositionId,
                DepartmentId = e.DepartmentId,
                SelfTaxCode = e.SelfTaxCode,
                Salary = e.Salary,
                JoinDate = e.JoinDate,
                Department = e.Department.DepartmentName,
                Position = e.Position.PositionName,
            }).Where(i => i.EmployeeId == id).FirstOrDefault();
            return Ok(kq);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post(ViewEmployee employee)
        {
            var record = new Employee();
            if (employee != null)
            {
                record.EmployeeCode = employee.EmployeeCode;
                record.Email = employee.Email;
                record.Gender = employee.Gender;
                record.FullName = employee.FullName;
                record.DateOfBirth = employee.DateOfBirth;
                record.CitizenIdentityCode = employee.CitizenIdentityCode;
                record.CitizebIdentityPlace = employee.CitizebIdentityPlace;
                record.CitizebIdentityDate = employee.CitizebIdentityDate;
                record.PhoneNumber = employee.PhoneNumber;
                record.WorkState = employee.WorkState;
                record.PositionId = employee.PositionId;
                record.DepartmentId = employee.DepartmentId;
                record.SelfTaxCode = employee.SelfTaxCode;
                record.Salary = employee.Salary;
                record.JoinDate = employee.JoinDate;
                _db.Employee.Add(record);
            }
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ViewEmployee employee)
        {
            var record = _db.Employee.Find(id);
            if (record != null)
            {
                record.EmployeeCode = employee.EmployeeCode;
                record.Email = employee.Email;
                record.Gender = employee.Gender;
                record.FullName = employee.FullName;
                record.DateOfBirth = employee.DateOfBirth;
                record.CitizenIdentityCode = employee.CitizenIdentityCode;
                record.CitizebIdentityPlace = employee.CitizebIdentityPlace;
                record.CitizebIdentityDate = employee.CitizebIdentityDate;
                record.PhoneNumber = employee.PhoneNumber;
                record.WorkState = employee.WorkState;
                record.PositionId = employee.PositionId;
                record.DepartmentId = employee.DepartmentId;
                record.SelfTaxCode = employee.SelfTaxCode;
                record.Salary = employee.Salary;
                record.JoinDate = employee.JoinDate;
                _db.SaveChanges();
            }
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var kq = _db.Employee.Find(id);
            if (kq != null)
            {
                _db.Employee.Remove(kq);
                _db.SaveChanges();

            }
            return;
        }
    }
}
