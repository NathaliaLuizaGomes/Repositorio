using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUsers.Models;

namespace WebApplicationUsers.Util
{
    public class IsValid
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }

        }

        public static bool IsInteger(string input)
        {
            try
            {
                int value = 0;
                if (int.TryParse(input, out value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }

        }        

    }
}