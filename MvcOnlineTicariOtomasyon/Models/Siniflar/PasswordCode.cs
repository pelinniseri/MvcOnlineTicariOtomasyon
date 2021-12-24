using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class PasswordCode
    {
        public int Id { get; set; }
        public Cariler userinsystem { get; set; }
        public int Userid { get; set; }
        [StringLength(6)]
        public string Code { get; set; }
    }
}