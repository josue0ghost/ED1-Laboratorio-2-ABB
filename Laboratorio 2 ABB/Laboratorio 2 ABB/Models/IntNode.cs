using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laboratorio_2_ABB.Models
{
    public class IntNode: IComparable
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Value")]
        public int value { get; set; }

        public int CompareTo(object obj)
        {
            var ob = (IntNode)obj;
            return id > ob.id ? 1 : id < ob.id ? -1 : 0;
        }
    }

}