using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BL
{
    public class UnitOfWork : IDisposable
    {

        private DbContextBEFL context = new DbContextBEFL();
        private GenericRepository<Emp> empRepository;
        private GenericRepository<Pos> posRepository;
        private GenericRepository<Dep> depRepository;
       

        // Возвращает репозитроий требуемого типа
        public GenericRepository<T> Repository<T>() where T : class
        {
            Type tt = typeof(T);
            if (tt == typeof(BL.Emp))
                return EmpRepository as GenericRepository<T>;
            else if (tt == typeof(BL.Pos)) return PosRepository as GenericRepository<T>;
            else if (tt == typeof(BL.Dep)) return DivisionRepository as GenericRepository<T>;
            else return null;
        }



        public GenericRepository<Pos> PosRepository
        {
            get
            {

                if (this.posRepository == null)
                {
                    this.posRepository = new GenericRepository<Pos>(context);
                }
                return posRepository;
            }
        }

        public GenericRepository<Emp> EmpRepository
        {
            get
            {

                if (this.empRepository == null)
                {
                    this.empRepository = new GenericRepository<Emp>(context);
                }
                return empRepository;
            }
        }

        public GenericRepository<Dep> DivisionRepository
        {
            get
            {

                if (this.depRepository == null)
                {
                    this.depRepository = new GenericRepository<Dep>(context);
                }
                return depRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
