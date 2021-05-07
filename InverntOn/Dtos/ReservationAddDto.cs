using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverntOn.Dtos
{
    class ReservationAddDto
    {
        public DateTime Date { get; set; }
        public IEnumerable<ClientAddDto> Clients { get; set; }
    }
}
