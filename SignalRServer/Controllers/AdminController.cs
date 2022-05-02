using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SignalRServer.Models;
using SignalRServer.Models.DB;
using SignalRServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Controllers
{
    public class AdminController : Controller
    {
        private readonly string addressUrl = "http://localhost:55001/notification";

        
        //private IRepository _repository;
        private ToDoDbRepository _repository;
        private IMapper _mapper;
        //private NotificationHub _hub;
        private ManagerHub _managerHub;

        //private readonly IHubContext<ICommunicationHub> _hub;

        private readonly IHubContext<NotificationHub> _hubContext;

        //private Repository_<Employee> _employeeRepository;
        //private Repository_<RoleEmployee> _roleRepositor;
        //private Repository_<TaskEmployee> _taskRepository;

        public AdminController(
            ToDoDbRepository repository,
                IMapper mapper,
                //NotificationHub hub
                IHubContext<NotificationHub> hubContext,
                //IHubContext<ICommunicationHub> hub,
                ManagerHub managerHub
            )
        //Repository_<Employee> employeeRepository,
        //Repository_<RoleEmployee> roleRepository,
        //Repository_<TaskEmployee> taskRepository)
        {
            _repository = repository;
            _mapper = mapper;

            _hubContext = hubContext;

            //_hub = hub;
            _managerHub = managerHub;

            //_employeeRepository = employeeRepository;
            //_roleRepositor = roleRepository;
            //_taskRepository = taskRepository;

        }

        // GET: AdminController
        public async Task<ActionResult> Index()
        {
            var listEmployees = _repository.Employees;
            //var listEmployees = _employeeRepository.GetAll().ToList();

            //--------------
            //await _hubContext.Clients.All.SendAsync("HelloServer", "Hello of server");
            //--------------
            //var connections = _managerHub.Users.Single(user => user.UserName == "emp2");

            //foreach (var conn in connections)
            //{
            //    //_hub.Clients.Clients<>

            //}
            //--------------


            return View(listEmployees);
        }

        // GET: AdminController/Details/5
        public ActionResult Tasks(int id)
        {
            var emp = _repository.Employees.SingleOrDefault(emp => emp.EmployeeId == id);

            return View(emp);
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee(Employee employee)
        {
            try
            {
                //_employeeRepository.CreateAsync(employee).GetAwaiter().GetResult();
                //_repository.Employees.Add(employee);
                //_repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateTaskView(int id)
        {
            var emp = _repository.Employees.SingleOrDefault(emp => emp.EmployeeId == id);
            var task = new TaskEmployee() { Employee = emp };
            return View(task);
        }
        

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTask([FromForm]TaskEmployee task)
        {
            try
            {
                await _repository.AddTaskForEmployee(task);
                await _repository.SaveAsync();

                var emp = _repository.Employees.SingleOrDefault(emp => emp.EmployeeId == task.IdEmployee);

                //await _hubContext.Clients.Client(conn.).SendAsync("", "");

                var connections = _managerHub.Users.Single(user => user.UserName == emp.Name).ConnectionsHub;

                foreach (var conn in connections)
                {
                    await _hubContext.Clients.Client(conn.ConnectionId).SendAsync("HelloServer", task.Name);

                }

                
                //await _hubContext.Clients.All.SendAsync("HelloServer", task.Name);






                return RedirectToAction(nameof(Tasks), "Admin", new { id = task.IdEmployee });
            }
            catch
            {
                return View(new TaskEmployee());
            }
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void Testing()
        {
            //var mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Employee, EmployeeDTO>()
            //        .ForMember(dto => dto.Role, x => x.MapFrom(x => x.Role))
            //        .ForMember(dto => dto.Tasks, x => x.MapFrom(x => x.Tasks));
            //    //cfg.CreateMap<RoleEmployee, RoleDTO>();
            //    //cfg.CreateMap<TaskEmployee, TaskDTO>();
            //}).CreateMapper();

            //var emps = _mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(_repository.Employees);
            //var roles = _mapper.Map<IEnumerable<RoleEmployee>, List<RoleDTO>>(_repository.Roles);
            //var tasks = _mapper.Map<IEnumerable<TaskEmployee>, List<TaskDTO>>(_repository.Tasks);

            //var listEmployees = new List<Employee>()
            //{
            //	new Employee() { Id = 1, Name = "Sa", Role = Role.Admin }
            //};

            //var listRoles = _repository.Roles;

            //var listTasks = _repository.Tasks;

            //var rols = _roleRepositor.GetAll().ToList();
            //var tsks = _taskRepository.GetAll().ToList();



            try
            {
                var emp4 = new Employee()
                {
                    EmployeeId = 5,
                    Name = "emp4",
                    Role = _repository.Roles.ElementAt(1),
                    Tasks = new List<TaskEmployee>()
                    {
                        new TaskEmployee() { Name = "task1 for emp4"}
                    }
                };

                _repository.AddEmployee(emp4);
                _repository.Save();
                //await repository.Context.SaveChangesAsync();



                //await _employeeRepository.CreateAsync(emp3);
                //repository.AddEmployee(emp3);
                //repository. Employees.Add(emp3);

                //repository.Save();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
