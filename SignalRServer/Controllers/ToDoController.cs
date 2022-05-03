using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SignalRServer.Models;
using SignalRServer.Models.DB;
using SignalRServer.Models.Responce;
using Microsoft.AspNetCore.Http;

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
        
        /// <summary>
        /// Метод для перевірки Web API
        /// </summary>
        /// <returns></returns>
		[HttpGet("GetString")]
		public async Task<string> GetString()
		{
			return await Task.FromResult("OK");
		}

        /// <summary>
        /// Отримання всіх існуючик задач співробітника по його імені
        /// </summary>
        /// <param name="userName">Ім'я співробітника</param>
        /// <returns></returns>
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

        /// <summary>
        /// Отримання всіх співробітників з прилежними властивостями
        /// </summary>
        /// <returns></returns>
        [HttpGet("getEmployees")]
		public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var employees = await _repository.GetAllEmployees();

            return _mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(employees);
           
        }

        /// <summary>
        /// Отримання співробітника по імені
        /// </summary>
        /// <param name="name">Ім'я спіробітника</param>
        /// <returns></returns>
        [HttpGet("getEmployee/{name}")]
        public async Task<EmployeeDTO> GetEmployee(string name)
        {
            var employee = await _repository.GetEmployee(name);

            return _mapper.Map<Employee, EmployeeDTO>(employee);
        }

        /// <summary>
        /// Створення нової задачі для конкретного співробітника
        /// </summary>
        /// <param name="taskDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("employee/createTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> createTaskForEmployee([FromBody] TaskDTO taskDTO)
		{
            try
            {
                var taskEmployee = _mapper.Map<TaskDTO, TaskEmployee>(taskDTO);
                await _repository.AddTaskForEmployee(taskEmployee);
                _repository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Оновлення існуючої задачі співробітника
        /// </summary>
        /// <param name="id">Ід задачі</param>
        /// <param name="task">Об'єкт TaskDTO</param>
		[HttpPut("employee/updateTask/{id}")]
		public void Put(int id, [FromBody] TaskDTO task) { }

        /// <summary>
        /// Видалення задачі співробітника
        /// </summary>
        /// <param name="id">Ід задачі</param>
		[HttpDelete("employee/deleteTask/{id}")]
		public void Delete(int id) { }
	}
}
