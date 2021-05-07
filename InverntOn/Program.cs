using System;
using System.Data;
using System.Data.Common;
using InverntOn.Data;
using System.Data.SqlClient;
using AutoMapper;
using InverntOn.Controllers;
using InverntOn.Profiles;
using InverntOn.Repositories;

namespace InverntOn
{
    class Program
    {
        static void Main(string[] args)
        { 
            DbContext context = new DbContext(new SqlConnection(""));
            IClientRepo clientRepo = new ClientRepo(context);
            IReservationRepo reservationRepo = new ReservationRepo(context);
            Mapper mapper = new Mapper(new MapperConfiguration(e => e.AddProfile(new InventOnProfile())));
            ReservationsManagementController controller = new ReservationsManagementController(clientRepo, reservationRepo, mapper);
        }
    }
}
