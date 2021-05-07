using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InverntOn.Dtos;
using InverntOn.Models;

namespace InverntOn.Profiles
{
    class InventOnProfile : Profile
    {
        public InventOnProfile()
        {
            CreateMap<Client, ClientAddDto>();
            CreateMap<ClientAddDto, Client>();

            CreateMap<Client, ClientGetDto>();
            CreateMap<ClientGetDto, Client>();

            CreateMap<Reservation, ReservationAddDto>();
            CreateMap<ReservationAddDto, Reservation>();

            CreateMap<Reservation, ReservationGetDto>();
            CreateMap<ReservationGetDto, Reservation>();
        }
    }
}
