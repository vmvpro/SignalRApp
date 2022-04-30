using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SignalRServer.Models;
using SignalRServer.Models.DB;
using SignalRServer.Models.Responce;


namespace SignalRServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoController : ControllerBase
	{

        private IMapper _mapper;

        //private IRepository _repository;
        private ToDoDbRepository _repository;

        private IToDoDbContext _dbContext { get; }
        private IDapperReadDbConnection _readDbConnection { get; }
        private IDapperWriteDbConnection _writeDbConnection { get; }

        public ToDoController(
            IMapper mapper,
            //IRepository repository, 
            ToDoDbRepository repository, 
            IToDoDbContext dbContext, 
            IDapperReadDbConnection readDbConnection, 
            IDapperWriteDbConnection writeDbConnection)
        {
            _mapper = mapper;

            _dbContext = dbContext;
            _readDbConnection = readDbConnection;
            _writeDbConnection = writeDbConnection;
            _repository = repository;
		}
        

		[HttpGet("GetString")]
		public async Task<string> GetString()
		{
			return await Task.FromResult("OK");
		}

        [HttpGet("tasksAsync/{userName}") ]
        public async Task<dynamic> GetAllTasksForEmployeeAsync(string userName)
        {
			
            var query = @"
                Select 
                    emp.employee_id as id
                    , emp.name as name
                    , r.name as role
                    , t.name as task
                 From
                    Employees emp
                    Inner Join Roles r
                        On emp.id_role = r.role_id
                    Inner Join Tasks t
                        On emp.employee_id = t.id_employee";

            var tasks = await  _dbContext.Connection.Query(query,
                () => new
                {
                    Id = default(long), 
                    Name = default(string),
                    Role = default(string),
                    Task = default(string),
				});

            var filterTasks = tasks.Where(emp => emp.Name == userName);


			return Ok(filterTasks);
        }

        //[HttpGet("tasks/{userName}")]
        //public dynamic GetAllTasksForEmployee(string userName)
        //{
        //    dynamic filterTasks = _repository.Tasks
        //        .Where(t => t.Employee.Name == userName)
        //        .Select(t => new
        //        {
        //            Id = t.Employee.EmployeeId,
        //            Name = t.Employee.Name,
        //            Role = t.Employee.Role.Name,
        //            Task = t.Name,
        //        });
                
        //    return Ok(filterTasks);
        //}

        //public async Task<IEnumerable<T>> GetAllTasksForUser_<T>(T typeObject,string userName)
        //{

        //    var query = $"SELECT employee_id as Id, Name FROM Employees";
        //    var tasks = await _dbContext.Connection.Query(query,
        //        () => typeObject);

        //    return tasks;
        //}

        //[HttpGet("GetEmployeesAsync")]
        //public async Task<List<Employee>> GetEmployeesAsync()
        //{
        //	return await repository.EmployeesAsync;
        //}

        //[HttpGet("GetTasks")]
        //public List<TaskEmployee> GetTasks()
        //{
        //	return repository.Tasks;
        //}

        //[HttpGet("GetRoles")]
        //public List<RoleEmployee> GetRoles()
        //{
        //	return repository.Roles;
        //}

        [HttpGet("GetEmployees")]
		public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var employees = await _repository.GetAllEmployees();

            return _mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(employees);
           
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllOwners()
        //{
        //    try
        //    {
        //        var owners = await _repository.Owner.GetAllOwnersAsync();
        //        _logger.LogInfo($"Returned all owners from database.");
        //        var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
        //        return Ok(ownersResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        // GET: api/<WebApiController>
        [HttpGet ("Get")]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<WebApiController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<WebApiController>
		[HttpPost]
		public void Post([FromBody] string value)
		{

		}

		// PUT api/<WebApiController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<WebApiController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
