using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task AddAsyn(Account account);
        Task<IEnumerable<Account>> ListAsync();

        Task<Account> GetByUserandPasswordIdAsync(string username, string password);
    }

}
