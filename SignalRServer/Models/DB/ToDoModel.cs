using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRServer.Models.DB
{

    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public long EmployeeId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("id_role")]
        public long IdRole { get; set; }

        public virtual RoleEmployee Role { get; set; }

        public virtual ICollection<TaskEmployee> Tasks { get; set; }

    }
    [Table("Roles")]
    public class RoleEmployee
    {
        [Key]
        [Column("role_id")]
        public long RoleId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }

    [Table("Tasks")]
    public class TaskEmployee
    {

        [Key]
        [Column("task_id")]
        public long TaskId { get; set; }

        [Column("name")]
        [Display(Name = "Задача")]
        [Required]
        public string Name { get; set; }

        [Column("id_employee")]
        public long IdEmployee { get; set; }

        public virtual Employee Employee { get; set; }

    }

    public enum EnumRoleEmployee
    {
        [Display(Name = "Адміністратор")]
        Admin = 1,

        [Display(Name = "Користувач")]
        User
    }
}
