using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kiem_Tra_MVC.Models
{
    public class ClassRoom
    {
        public int id { get; set; }
        public string ClassNAme { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}