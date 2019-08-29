﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.Models;

namespace Authentication.API.Repositories
{
    public interface IAuthRepository
    {
        bool RegisterUser(User user);
        User LoginUser(string userId, string password);
        User FindUserById(string userId);
    }
}
