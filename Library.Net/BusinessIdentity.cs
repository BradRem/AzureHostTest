using System;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Security;

namespace Library
{
    [Serializable]
    public class BusinessIdentity : CslaIdentityBase<BusinessIdentity>
    {
        public static BusinessIdentity GetCustomIdentity(string username, string password)
        {
            return DataPortal.Fetch<BusinessIdentity>(new UsernameCriteria(username, password));
        }

        private void DataPortal_Fetch(UsernameCriteria criteria)
        {
            AuthenticationType = "Custom";

            using (var dalManager = DataAccess.DalFactory.GetManager())
            {
                // fake the authentication
                if (criteria.Username == "test" && criteria.Password == "password")
                {
                    IsAuthenticated = true;
                    Name = "test";

                    Roles = new Csla.Core.MobileList<string>();
                }
            }
        }
    }
}
