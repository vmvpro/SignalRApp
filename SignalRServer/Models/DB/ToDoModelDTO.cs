using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace SignalRServer.Models.DB
{

    public class EmployeeDTO
    {
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

        public string Description { get; set; }

    }

    
    public class TaskDTO
    {

        public long TaskId { get; set; }

        public string Name { get; set; }

        public long IdEmployee { get; set; }

    }

}
