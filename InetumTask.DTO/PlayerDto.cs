using System;
using System.Collections.Generic;
using System.Text;

namespace InetumTask.DTO
{
    public class PlayerDto : BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public byte[] Image { get; set; }
        public int TeamId { get; set; }
    }
}
