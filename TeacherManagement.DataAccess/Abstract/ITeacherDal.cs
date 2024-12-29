using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.DataAccess.Abstract
{
    public interface ITeacherDal : IGenericDal<Teacher>
    {
        Task<Teacher> TGetByName(string name);
    }
}
