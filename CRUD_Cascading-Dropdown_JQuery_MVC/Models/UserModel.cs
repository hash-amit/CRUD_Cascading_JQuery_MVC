using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Cascading_Dropdown_JQuery_MVC.Models
{
    public class UserModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
    }
}