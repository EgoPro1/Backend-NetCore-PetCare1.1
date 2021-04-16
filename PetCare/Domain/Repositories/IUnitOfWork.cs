using System;

using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
