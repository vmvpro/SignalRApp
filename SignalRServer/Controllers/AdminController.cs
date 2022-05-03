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
using Microsoft.AspNetCore.Authorization;

namespace SignalRServer.Controllers
{

    //[Authorize]
    public class AdminController : Controller
    {
        private ToDoDbRepository _repository;
        private IMapper _mapper;
        private ManagerHub _managerHub;

        private readonly IHubContext<NotificationHub> _hubContext;

        private RepositoryGeneric<Employee> _employeeRepository;
        //private Repository_<RoleEmployee> _roleRepositor;
        //private Repository_<TaskEmployee> _taskRepository;

        public AdminController(
                ToDoDbRepository repository,
                RepositoryGeneric<Employee> employeeRepository,
                IMapper mapper,
                IHubContext<NotificationHub> hubContext,
                ManagerHub managerHub
            )
        {
            _repository = repository;

            // Використання generic-класів для бд
            _employeeRepository = employeeRepository;
            //_roleRepositor = roleRepository;
            //_taskRepository = taskRepository;

            _mapper = mapper;

            _hubContext = hubContext;

            _managerHub = managerHub;

        }

        public async Task<ActionResult> Index()
        {
            var listEmployees = _repository.Employees;
            return View(listEmployees);
        }

        public ActionResult Tasks(int id)
        {
            var emp = _repository.Employees.SingleOrDefault(emp => emp.EmployeeId == id);

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                await _employeeRepository.CreateAsync(employee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> CreateTaskView(int id)
        {
            var emp = _repository.Employees.SingleOrDefault(emp => emp.EmployeeId == id);
            var task = new TaskEmployee() { Employee = emp };
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTask([FromForm] TaskEmployee task)
        {
            try
            {
                await _repository.AddTaskForEmployee(task);
                await _repository.SaveAsync();

                var emp = _repository.Employees.SingleOrDefault(emp => emp.EmployeeId == task.IdEmployee);

                var connections = _managerHub.Users.Single(user => user.UserName == emp.Name).ConnectionsHub;

                foreach (var conn in connections)
                    await _hubContext.Clients.Client(conn.ConnectionId).SendAsync("NotificationTask", task.Name);
                
                return RedirectToAction(nameof(Tasks), "Admin", new { id = task.IdEmployee });
            }
            catch
            {
                return View(new TaskEmployee());
            }
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
    }
}
