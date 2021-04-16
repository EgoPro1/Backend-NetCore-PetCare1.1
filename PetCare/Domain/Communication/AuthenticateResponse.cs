﻿using System;
using PetCare.Domain.Models;

namespace PetCare.Domain.Communication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Account user, string token)
        {
            Id = user.Id;
            Username = user.User;
            Token = token;
        }
    }
}
