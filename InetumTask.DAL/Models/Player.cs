using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InetumTask.DAL.Models
{
    public class Player : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public byte[] Image { get; set; }

        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }

    }
}
