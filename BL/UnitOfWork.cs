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
        private GenericRepository<Comp> compRepository;
        private GenericRepository<Printer> printerRepository;
        private GenericRepository<Monitor> monitorRepository;
        private GenericRepository<DicData> dicdataRepository;
        private GenericRepository<Misc> miscRepository;
        
        // Возвращает репозитроий требуемого типа
        public GenericRepository<T> Repository<T>() where T : class
        {
            Type tt = typeof(T);
            if (tt == typeof(BL.Emp))
                return EmpRepository as GenericRepository<T>;
            else if (tt == typeof(BL.Pos)) return PosRepository as GenericRepository<T>;
            else if (tt == typeof(BL.Dep)) return DivisionRepository as GenericRepository<T>;
            else if (tt == typeof(BL.Comp)) return CompRepository as GenericRepository<T>;
            else if (tt == typeof(BL.Printer)) return PrinterRepository as GenericRepository<T>;
            else if (tt == typeof(BL.Monitor)) return MonitorRepository as GenericRepository<T>;
            else if (tt == typeof(BL.DicData)) return DicDataRepository as GenericRepository<T>;
            else if (tt == typeof(BL.Misc)) return MiscRepository as GenericRepository<T>;
            else return null;
        }

        public IEnumerable<BL.Mc> GetAllMc()
        {
            IEnumerable<BL.Mc> listMon = MonitorRepository.GetAll();
            IEnumerable<BL.Mc> listMsc = MiscRepository.GetAll();
            IEnumerable<BL.Mc> listAll = listMon.Concat(listMsc).Concat(PrinterRepository.GetAll());
            return listAll;
        }

        public GenericRepository<Printer> PrinterRepository
        {
            get
            {
                if (this.printerRepository == null)
                {
                    this.printerRepository = new GenericRepository<Printer>(context);
                }
                return printerRepository;
            }
        }

        public GenericRepository<Misc> MiscRepository
        {
            get
            {
                if (this.miscRepository == null)
                {
                    this.miscRepository = new GenericRepository<Misc>(context);
                }
                return miscRepository;
            }
        }

        public GenericRepository<DicData> DicDataRepository
        {
            get
            {
                if (this.dicdataRepository == null)
                {
                    this.dicdataRepository = new GenericRepository<DicData>(context);
                }
                return dicdataRepository;
            }
        }

        public GenericRepository<Monitor> MonitorRepository
        {
            get
            {
                if (this.monitorRepository == null)
                {
                    this.monitorRepository = new GenericRepository<Monitor>(context);
                }
                return monitorRepository;
            }
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

        public GenericRepository<Comp> CompRepository
        {
            get
            {

                if (this.compRepository == null)
                {
                    this.compRepository = new GenericRepository<Comp>(context);
                }
                return compRepository;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }

            catch(System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw new System.Data.Entity.Infrastructure.DbUpdateException(e.Message);
            }
            
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
