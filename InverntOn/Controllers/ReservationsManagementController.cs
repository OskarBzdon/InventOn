using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InverntOn.Dtos;
using InverntOn.Models;
using InverntOn.Repositories;

namespace InverntOn.Controllers
{
    class ReservationsManagementController
    {
        private readonly IClientRepo _clientRepo;
        private readonly IReservationRepo _reservationRepo;
        private readonly Mapper _mapper;

        public ReservationsManagementController(IClientRepo clientRepo, IReservationRepo reservationRepo, Mapper mapper)
        {
            _clientRepo = clientRepo;
            _reservationRepo = reservationRepo;
            _mapper = mapper;
        }

        public StringBuilder getAllMyReservations(ClientAddDto client)
        {
            StringBuilder result = new StringBuilder();
            foreach (var reservation in _reservationRepo.GetAllMyReservations(_mapper.Map<Client>(client)))
            {
                result.Append(_mapper.Map<ClientGetDto>(reservation));
            }

            return result;
        }
    }
}
