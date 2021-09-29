﻿using InetumTask.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace InetumTask.Business.BusinessInterface
{
    public interface ILoginTokenBusiness
    {
        LoginTokenDto AddLoginTokenForUser(LoginTokenDto loginTokenDto);
        LoginTokenDto GetLoginTokenForUser(LoginTokenDto loginTokenDto);
        bool UpdateRefreshToken(string newRefreshToken,string userName);
        bool CheckIfUserExist(LoginTokenDto loginTokenDto);
    }
}
