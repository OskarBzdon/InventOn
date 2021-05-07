using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverntOn.Dtos
{
    class ReservationGetDto
    {
        public DateTime Date { get; set; }
        public IEnumerable<ClientGetDto> Clients { get; set; }
    }
}
