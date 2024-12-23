using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.DataAccess.Abstract;
using TeacherManagement.DataAccess.Context;
using TeacherManagement.DataAccess.Respository;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.DataAccess.Concreate
{
    public class EfTeacherDal : GenericRepository<Teacher>, ITeacherDal
    {
        public EfTeacherDal(TeacherManagementContext context) : base(context)
        {
        }
    }
}
