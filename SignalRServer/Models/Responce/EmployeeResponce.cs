using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SignalRServer.Models.DB;

namespace SignalRServer.Models.Responce
{
    public class EmployeeResponce
    {
        public EmployeeDTO Employee { get; set; }
        public RoleDTO Role { get; set; }

        public List<TaskDTO> Tasks;
    }
}
