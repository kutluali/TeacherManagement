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
    public class LessonManager : GenericManager<Lesson>, ILessonService
    {
        private readonly ILessonDal _lessonDal;
        public LessonManager(IGenericDal<Lesson> _genericDal, ILessonDal lessonDal) : base(_genericDal)
        {
            _lessonDal = lessonDal;
        }

        public List<Lesson> TGetLessonWithTeacher()
        {
            return _lessonDal.GetLessonWithTeacher();
        }
    }
}
