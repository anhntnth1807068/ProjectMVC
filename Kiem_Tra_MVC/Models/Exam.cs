using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kiem_Tra_MVC.Models
{
    public class Exam
    {
        public int id { get; set; }
        [Required]

        public int ExamSubjectid { get; set; }
        public virtual ExamSubject ExamSubject { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExamDate { get; set; }
        [Required]
        public int Duration { get; set; }
        public int ClassRoomid { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

        public int Facultyid { get; set; }
        public virtual Faculty Faculty { get; set; }

        public EnumSatus Status { get; set; }

        public enum EnumSatus
        {
            done = 1, upcomming = 2, ongoing = 3
        }

    }
}
   

