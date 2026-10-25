using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAP.Repositories;

namespace PAP.Business
{
    public abstract class ManagerBase<T> where T : class
    {
        protected readonly IRepositoryBase<T> _repository; //Instanciamos el repositorio base para usar sus comandos

        protected ManagerBase(IRepositoryBase<T> repository) //Solicita que repositorio queremos meter el dato
        {
            _repository = repository; //Igualamos el repositorio actual a el que nos pasaron
        }

        //CRUD

        //METODOS DE LECTURA
        public virtual IEnumerable<T> GetAll() 
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<T> GetTop100()
        {
            return _repository.GetTop(100);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }


        //METODOS DE ESCRITURA
        public virtual void Save(T entity)
        {
            _repository.Add(entity);
        }
        public virtual void GuardarEnLote(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

        //METODOS UTILITARIOS
        public virtual bool HasData()
        {
            return _repository.Any();
        }
        public virtual int Count()
        {
            return _repository.Count();
        }
    }
}
