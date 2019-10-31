using System;

namespace CookieAuthentication.DataAccess.Entities
{
    public class Base
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
 
        public bool IsDeleted { get; set; }

    }
}
