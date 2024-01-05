using AutoMapper;
using Reservation.Core.Models;
using Reservation.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Table,TableDto>().ReverseMap();
            CreateMap<Table,TableCreateDto>().ReverseMap();
            CreateMap<Table,TableUpdateDto>().ReverseMap();
            CreateMap<Core.Models.Reservation,ReservationDto>().ReverseMap();
            CreateMap<Core.Models.Reservation,ReservationCreateDto>().ReverseMap();
            CreateMap<Core.Models.Reservation,ReservationUpdateDto>().ReverseMap();
        }
    }
}
