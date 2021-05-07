using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverntOn.Models
{
    public class Reservation
    {
        [Key] public int IdReservation { get; set; }
        [Required] public DateTime Date { get; set; }
        [Required] public Client Owner { get; set; }
        [Required] [MinLength(1)] public IEnumerable<Client> Clients { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Reservation item))
            {
                return false;
            }

            return this.Date.Equals(item.Date) && this.Owner.Equals(item.Owner);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Date, Owner);
        }

        public bool CanBeCancelledBy(Client client)
        {
            if (client == null)
                return false;
            return Owner.Equals(client);
        }
    }
}
