using System;
using Unity;
using Unity.Resolution;
using WebFront.DAL;
using WebFront.Repositories.Implementations;

namespace WebFront.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IRegionRepository _regionRepository;
        private ICompanyRepository _companyRepository;
        private IContactRepository _contactRepository;
        private INoteRepository _noteRepository;

        public IRegionRepository RegionRepository => 
            _regionRepository ?? (_regionRepository = new RegionRepository(_context));

        public ICompanyRepository CompanyRepository => 
            _companyRepository ?? (_companyRepository  = new CompanyRepository(_context));

        public IContactRepository ContactRepository => 
            _contactRepository ?? (_contactRepository = new ContactRepository(_context));

        public INoteRepository NoteRepository => 
            _noteRepository ?? (_noteRepository = new NoteRepository(_context));

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                    _regionRepository = null;
                    _companyRepository = null;
                    _contactRepository = null;
                    _noteRepository = null;
                }
            }
        }
    }
}