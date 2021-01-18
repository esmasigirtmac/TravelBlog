using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }
        public string Yorum { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public int Blogid { get; set; }     //yorum ekledikçe yeni blog eklemesin diye

        public virtual Blog Blog { get; set; } //Blog tablosundan Blog isminde değer oluşturdum. Blog Blog tablomdan gelecek olan değeri tutuyor.
        //Bir yorum sadece bir bloga ait olabilir.
        
    }
}