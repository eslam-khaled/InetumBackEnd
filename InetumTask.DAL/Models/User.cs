using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InetumTask.DAL.Models
{
    [NotMapped]
    public class User: IdentityUser
    {
    }
}
