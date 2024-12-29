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
    public class GenericManager<T>(IGenericDal<T> _genericDal): IGenericService<T> where T : class
    {

		public void TAdd(T entity)
        {
            _genericDal.Add(entity);
        }

        public void TDelete(T entity)
        {
            _genericDal.Delete(entity);
        }

        public T TGetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public List<T> TGetListAll()
        {
            return _genericDal.GetListAll();
        }

        public void TUpdate(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}


