using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SignalRServer.Models.DB
{

    public interface _IRepository
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
            //return await _context.Employees.ToListAsync();

            return await _context.Employees
                .Include(r => r.Role)
                .Include(t => t.Tasks)
                .ToListAsync();
        }


        public IEnumerable<Employee> Employees  => _context.Employees
            .Include(r=>r.Role)
            .Include(t=>t.Tasks);

        public IEnumerable<RoleEmployee> Roles => _context.Roles
            .Include(e => e.Employees);
        public IEnumerable<TaskEmployee> Tasks => _context.Tasks
            .Include(e => e.Employee);

        public void AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
        }

        public async Task AddTaskForEmployee(TaskEmployee task)
        {
            await _context.Tasks.AddAsync(task);

            //var currentEmp = await _context.Employees
            //    .Where(emp => emp.EmployeeId == task.IdEmployee)
            //    .SingleOrDefaultAsync();

            //currentEmp.Tasks.Add(task);


        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
