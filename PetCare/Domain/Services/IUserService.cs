using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetCare.Domain.Communication;
using PetCare.Domain.Models;



namespace PetCare.Domain.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest body/*, Task<List<Account>> list*/);

        // Task<List<Account>> ListAsync();
    }
}
