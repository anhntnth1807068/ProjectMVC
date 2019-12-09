using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kiem_Tra_MVC.Models
{
    public class Kiem_Tra_MVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Kiem_Tra_MVCContext() : base("name=Kiem_Tra_MVCContext")
        {
        }

        public System.Data.Entity.DbSet<Kiem_Tra_MVC.Models.Exam> Exams { get; set; }

        public System.Data.Entity.DbSet<Kiem_Tra_MVC.Models.ClassRoom> ClassRooms { get; set; }

        public System.Data.Entity.DbSet<Kiem_Tra_MVC.Models.ExamSubject> ExamSubjects { get; set; }

        public System.Data.Entity.DbSet<Kiem_Tra_MVC.Models.Faculty> Faculties { get; set; }
    }
}
