using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    /*[Authorize]*/    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        protected readonly EmployeeDbContext _db;
        public readonly IMapper _mapper;
        public EmployeeController(EmployeeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get(int? page)
        {

            var kq = _db.Employee;
/*            var _mappeEmployee = _mapper.Map<List<Employee>, List<ViewEmployee>> (kq);
*/            var _mappeEmployee = kq.ProjectTo<ViewEmployee>(_mapper.ConfigurationProvider).ToList();

            /*   Select(e => new ViewEmployee()
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
*/
            var pager = new Pager(kq.Count(), page);
            var vmd = new ViewModelPaging
            {
                ViewEmployee = _mappeEmployee.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };
            return Ok(vmd);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
              var kq = _db.Employee;
/*            var _mappeEmployee = _mapper.Map<Employee>(kq);
*/            var _mappeEmployee = kq.ProjectTo<ViewEmployee>(_mapper.ConfigurationProvider).Where(i=> i.EmployeeId == id).FirstOrDefault();


            /*     .Select(e => new ViewEmployee()
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
             }).Where(i => i.EmployeeId == id).FirstOrDefault();*/

            return Ok(_mappeEmployee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post(ViewEmployee employee)
        {
/*            var record = new Employee();
*/            if (employee != null)
            {
                var _mappeEmployee = _mapper.Map<Employee>(employee);

                /*record.EmployeeCode = employee.EmployeeCode;
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
                record.JoinDate = employee.JoinDate;*/
                _db.Employee.Add(_mappeEmployee);
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
                _mapper.Map(employee, record);

                /* record.EmployeeCode = employee.EmployeeCode;
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
                 record.JoinDate = employee.JoinDate;*/
                _db.Employee.Update(record);
            }
            _db.SaveChanges();

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
