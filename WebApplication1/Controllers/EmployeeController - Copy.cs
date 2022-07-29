using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee1Controller : ControllerBase
    {
        protected readonly EmployeeDbContext _db;
        public readonly IMapper _mapper;
        public Employee1Controller(EmployeeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int? page)
        {
            var kq = _db.Employee;
            var _mappeEmployee = kq.ProjectTo<ViewEmployee>(_mapper.ConfigurationProvider).ToList();
            var pager = new Pager(kq.Count(), page);
            var vmd = new ViewModelPaging
            {
                ViewEmployee = _mappeEmployee.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };
            return Ok(vmd);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var kq = _db.Employee;
            var _mappeEmployee = kq.ProjectTo<ViewEmployee>(_mapper.ConfigurationProvider).Where(i => i.EmployeeId == id).FirstOrDefault();
            return Ok(_mappeEmployee);
        }

        [HttpPost]
        public IActionResult Post(ViewEmployee employee)
        {
            if (employee != null)
            {
                var _mappeEmployee = _mapper.Map<Employee>(employee);
                _db.Employee.Add(_mappeEmployee);
            }
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ViewEmployee employee)
        {
            var record = _db.Employee.Find(id);
            if (record != null)
            {
                _mapper.Map(employee, record);
                _db.SaveChanges();
            }
            return Ok();
        }

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
