using System;
using System.Collections.Generic;
using System.Linq;
using Csla.Security;

namespace Library
{
    [Serializable]
    public class BusinessPrincipal : CslaPrincipal
    {
        private BusinessPrincipal(BusinessIdentity identity)
            : base(identity)
        { }

        public static void Login(string username, string password)
        {
            var identity = BusinessIdentity.GetCustomIdentity(username, password);
            Csla.ApplicationContext.User = new BusinessPrincipal(identity);
        }

        public static void Logout()
        {
            Csla.ApplicationContext.User = new UnauthenticatedPrincipal();
        }
    }
}
