using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Login
{
    [Table("Users")]
    public class User : IdentityUser
    {

        [NotMapped]
        public required string Password { get; set; }

        public int? UserId {  get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public bool Active { get; set; } = true;

        [NotMapped]
        public required string? Rol {  get; set; }    


    }
}
