﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.Business.Abstract
{
    public interface ILessonService:IGenericService<Lesson>
    {
        List<Lesson> TGetLessonWithTeacher();
    }
}
