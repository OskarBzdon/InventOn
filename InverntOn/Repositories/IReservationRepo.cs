using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InverntOn.Models;

namespace InverntOn.Repositories
{
    public interface IReservationRepo
    {
        IEnumerable<Reservation> GetAllMyReservations(Client client);
        Reservation GetReservation(Reservation reservation, Client client);
        void MakeReservation(IEnumerable<Client> clients, Client client);
        void CancelReservation(Reservation reservation);
        void EditReservation(Reservation reservation);
        bool ReservationCanBeCancelled(Reservation reservation, Client client);
    }
}
