using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace SignalRServer.Models.DB
{

    public class EmployeeDTO
    {
        //public EmployeeDTO() { }

        //public EmployeeDTO(Employee employee)
        //{
        //    this.EmployeeId = employee.EmployeeId;
        //    this.Name = employee.Name;

        //    this.Role = new RoleDTO()
        //    {
        //        RoleId = employee.IdRole,
        //        Name = employee.Name
        //    };

        //    if (employee.Tasks != null)
        //    {
        //        foreach (var task in employee.Tasks)
        //        {
        //            this.Tasks = new List<TaskEmployee>();
        //        }
        //    }
        //}


        public long EmployeeId { get; set; }

        
        public string Name { get; set; }
        
        public long IdRole { get; set; }

        public RoleDTO Role { get; set; } //= new RoleDTO();

        public List<TaskDTO> Tasks { get; set; }  //= new List<TaskDTO>();

    }

    public class RoleDTO
    {
        public long RoleId { get; set; }

        public string Name { get; set; }

        //public virtual IList<Employee> Employees { get; set; }

    }

    
    public class TaskDTO
    {

        public long TaskId { get; set; }


        public string Name { get; set; }

        public long IdEmployee { get; set; }

        //public virtual Employee Employee { get; set; }

    }

}
