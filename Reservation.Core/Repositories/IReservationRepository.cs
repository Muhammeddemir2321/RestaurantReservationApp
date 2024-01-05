﻿using Reservation.Core.DTO_s;
using Reservation.Shared.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Repositories
{
    public interface IReservationRepository:IGenericRepository<Models.Reservation>
    {
        Task<Models.Reservation> MakeReservation(Models.Reservation reservation);
    }
}
