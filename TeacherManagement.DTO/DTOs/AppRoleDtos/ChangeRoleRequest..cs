using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherManagement.DTO.DTOs.AppRoleDtos
{
    public class ChangeRoleRequest
    {
        public int UserId { get; set; }
        public string CurrentRole { get; set; }
        public string NewRole { get; set; }
    }
}
