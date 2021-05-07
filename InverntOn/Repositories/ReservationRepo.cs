using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InverntOn.Data;
using InverntOn.Models;

namespace InverntOn.Repositories
{
    class ReservationRepo : IReservationRepo
    {
        private readonly DbContext _ctx;

        public ReservationRepo(DbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Reservation> GetAllMyReservations(Client client)
        {
            return _ctx.Reservations.ToList().Result
                .Where(w => w.Clients
                    .Any(a => a.Equals(client)));
        }

        public Reservation GetReservation(Reservation reservation, Client client)
        {
            return _ctx.Reservations
                .FirstOrDefault(f => f.Equals(reservation) && f.Clients
                                         .Any(a => a.Equals(client))).Result;
        }

        public void MakeReservation(IEnumerable<Client> clients, Client owner)
        {
            _ctx.Reservations.Add(new Reservation()
            {
                Clients = clients,
                Date = DateTime.Now,
                Owner = owner,
                IdReservation = _ctx.Reservations.ToList().Result.Max(m => m.IdReservation) + 1
            });
        }

        public void CancelReservation(Reservation reservation)
        {
            Reservation model = _ctx.Reservations.FirstOrDefault(f => f.Equals(reservation)).Result;
            if (model != null)
                _ctx.Reservations.Remove(model.IdReservation);
        }

        public void EditReservation(Reservation reservation)
        {
            Reservation model = _ctx.Reservations.FirstOrDefault(f => f.Equals(reservation)).Result;
            if (model != null)
                _ctx.Reservations.Update(model.IdReservation, reservation);
        }

        public bool ReservationCanBeCancelled(Reservation reservation, Client client)
        {
            if (reservation != null)
                return reservation.CanBeCancelledBy(client);
            return false;
        }
    }
}
