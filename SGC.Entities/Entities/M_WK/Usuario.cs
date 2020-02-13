using SGC.Entities.Entities.M_WK;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.Entities.Entities.M_WK
{
    public class Usuario
    {
        [Key]
        public int User_ID { get; set; }
        public string User_Cod { get; set; }
        public string User_Name { get; set; }
        public string User_LastName { get; set; }
        public string User_User { get; set; }
        public string User_Pass { get; set; }
        public string User_Email { get; set; }
        public string Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Modified_User { get; set; }
        public DateTime Modified_Date { get; set; }
        public string User_Status { get; set; }
        //public int? Position_ID { get; set; }

        public virtual List<Posicion> Positions { get;  set;}

        public Usuario()
        {
            Positions = new List<Posicion>();
        }
    }
    
}
