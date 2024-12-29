using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.DataAccess.Abstract;
using TeacherManagement.DataAccess.Context;
using TeacherManagement.DataAccess.Respository;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.DataAccess.Concreate
{
    public class EfLessonDal : GenericRepository<Lesson>, ILessonDal
    {
        private readonly TeacherManagementContext _context;
        public EfLessonDal(TeacherManagementContext context) : base(context)
        {
            _context = context;
        }

        public List<Lesson> GetLessonWithTeacher()
        {
            return _context.Lessons.Include(x => x.Teacher).ToList();
        }
    }
}
