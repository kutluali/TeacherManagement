using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherManagement.DTO.DTOs.AppRoleDtos
{
    public class AssignRoleRequest
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}
