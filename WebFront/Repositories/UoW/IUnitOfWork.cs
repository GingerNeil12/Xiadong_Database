using System;

namespace WebFront.Repositories.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRegionRepository RegionRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IContactRepository ContactRepository { get; }
        INoteRepository NoteRepository { get; }
    }
}
