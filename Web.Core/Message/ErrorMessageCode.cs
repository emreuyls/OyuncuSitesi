using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Core.Message
{
    public enum ErrorMessageCode
    {
        //User 1..
        UserAlreadyExist=101,
        EmailAlreadyExist=102,
        UserNotFound=103,
        //Profile Password
        PasswordUpdatedSuccess=110,
        PasswordUpdateError=111,
        PlatformUpdateSuccess=112,
        PlatformUpdateError=113,

        //Profile 2..
        ProfileUpdate=201,

    }
}
