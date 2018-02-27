using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laboratorio_2_ABB.Models
{
    public class Pais : IComparable
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Grupo")]
        public string Grupo { get; set; }

        public int CompareTo(object obj)
        {
            var Pais2 = (Pais)obj;
            return id > Pais2.id ? 1 : id < Pais2.id ? -1 : 0;
        }
    }
}