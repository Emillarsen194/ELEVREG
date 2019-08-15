using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace ElevReg
{
    public class Dal
    {

        public bool ValidateUser(string userName, string password)
        {
            bool Valid = false;
            try
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Domain, "elevreg-skpit.local");
                Valid = pc.ValidateCredentials(userName, password);
                if (Valid)
                {
                    DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://elev-skpit.local", userName, password))
                    {
                        //makes a filter the searches for users with the same UNI(sAMAccountName)
                        Filter = string.Format("(&(objectClass=user)(objectCategory=person)(sAMAccountName={0}))", userName)
                    };
                    //asks for name and what group it is member of

                    search.PropertiesToLoad.Add("sAMAccountName");



                    //gets the information
                    SearchResult resultCol = search.FindOne();
                    //get unilogon
                    string studing = resultCol.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();







                }
            }
            catch
            {
            }


            return Valid;//true = user authenticated!
        }

    }
}