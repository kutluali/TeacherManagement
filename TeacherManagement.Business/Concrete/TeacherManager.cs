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
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public void TAdd(Teacher entity)
        {
            _teacherDal.Add(entity);
        }

        public void TDelete(Teacher entity)
        {
            _teacherDal.Delete(entity);
        }

        public Teacher TGetById(int id)
        {
           return _teacherDal.GetById(id);
        }

        public List<Teacher> TGetListAll()
        {
            return _teacherDal.GetListAll();
        }

        public void TUpdate(Teacher entity)
        {
            _teacherDal.Update(entity);
        }
    }
}
