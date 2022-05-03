using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SignalRServer.Models.DB
{

    public interface IRepository
    {
        IEnumerable<Employee> Employees { get; }

        IEnumerable<RoleEmployee> Roles { get; }

        IEnumerable<TaskEmployee> Tasks { get; }

        void AddEmployee(Employee emp);

        void Save();

    }
    public class ToDoDbRepository //: IRepository
    {
        private ToDoDbContext _context;

        public ToDoDbRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees
                .Include(r => r.Role)
                .Include(t => t.Tasks)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployee(string name)
        {
            return await _context.Employees
                .Include(r => r.Role)
                .Include(t => t.Tasks)
                .SingleAsync(emp => emp.Name == name);
        }

        public IEnumerable<Employee> Employees  => _context.Employees
            .Include(r=>r.Role)
            .Include(t=>t.Tasks);

        public IEnumerable<RoleEmployee> Roles => _context.Roles
            .Include(e => e.Employees);

        public IEnumerable<TaskEmployee> Tasks => _context.Tasks
            .Include(e => e.Employee);

        public async Task AddEmployee(Employee emp) =>
            await _context.Employees.AddAsync(emp);
        
        public async Task AddTaskForEmployee(TaskEmployee task) =>
            await _context.Tasks.AddAsync(task);
        
        public void Save() => _context.SaveChanges();   
        
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        
    }

}
