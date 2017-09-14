using System;

namespace HolyAngels.AdminPanel.Models 
{
    [Flags]
    public enum UserStatus : int
    {
        Unknown = -1,
        Active = 0,
        Inactive = 1,
        Online = 2,
        Offline = 3,
        PasswordReset = 4,
    };
}