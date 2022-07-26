using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _consume_.Models
{
    public class tbl_model
    {
        public int Emp_Id { get; set; }
        [Required(ErrorMessage ="Emp_name is required")]
        public string Emp_name { get; set; }
        [Required(ErrorMessage = "Emp_Department is required")]
        public string Emp_Department { get; set; }
      
        public int Emp_sal { get; set; }
        public string Emp_mob { get; set; }
        [Required(ErrorMessage = "Emp_company is required")]
        public string Emp_company { get; set; }
    }
}