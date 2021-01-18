using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Siniflar
{
    public class iletisim
    {
        [Key]
        public int ID { get; set; }
        public string AdSoyad{ get; set; }
        public string Mail { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }



    }
}