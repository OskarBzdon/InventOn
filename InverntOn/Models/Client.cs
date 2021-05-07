using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverntOn.Models
{
    public class Client
    {
        [Key] public int IdClient { get; set; }
        [Required] [MaxLength(255)] public string FirstName { get; set; }
        [Required] [MaxLength(255)] public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Client item))
            {
                return false;
            }

            return this.FirstName.Equals(item.FirstName) && this.LastName.Equals(item.LastName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
