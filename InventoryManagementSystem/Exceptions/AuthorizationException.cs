﻿namespace InventoryManagementSystem.Exceptions
{
    public class AuthorizationException : ApplicationException
    {
        public AuthorizationException(string message)
            : base(message)
        {

        }
    }
}
