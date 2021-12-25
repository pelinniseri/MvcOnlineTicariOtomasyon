using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class PasswordCodeForAdmin
    {
        public int Id { get; set; }
        public Admin admininsystem { get; set; }
        public int Userid { get; set; }
        [StringLength(6)]
        public string Code { get; set; }
    }
}