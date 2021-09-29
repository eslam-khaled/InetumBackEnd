using System;
using System.Collections.Generic;
using System.Text;

namespace InetumTask.DTO
{
    public class TeamDto:BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime FoundationDate { get; set; }
        public string CoachName { get; set; }
        public byte[] LogoImage { get; set; }
        public List<PlayerDto> playerListDto { get; set; }
    }
}
