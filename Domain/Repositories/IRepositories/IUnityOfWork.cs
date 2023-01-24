using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Domain.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}