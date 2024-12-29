using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.Business.Abstract;
using TeacherManagement.DataAccess.Abstract;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.Business.Concrete
{
    public class TeacherManager : GenericManager<Teacher>, ITeacherService
    {
        public TeacherManager(IGenericDal<Teacher> _genericDal) : base(_genericDal)
        {
        }
    }
}
