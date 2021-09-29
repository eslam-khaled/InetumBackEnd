using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InetumTask.DAL.Models
{
    public class Team: BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime FoundationDate { get; set; }
        public string CoachName { get; set; }
        public byte[] LogoImage { get; set; }
        public List<Player> players { get; set; }

    }
}
