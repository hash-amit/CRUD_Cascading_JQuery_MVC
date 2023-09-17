using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Cascading_Dropdown_JQuery_MVC.Models
{
    public class UserListModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }

        public UserListModel()
        {
            CustomerID = 0;
            Name = string.Empty;
            Email = string.Empty;
            CountryName = string.Empty;
            StateName = string.Empty;
            CityName = string.Empty;
        }
    }
}