﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.DbContext;
using UnitiReservation.Core.Models.Stats;

namespace UnitiReservation.Core.Services.Statistics
{

    public class StatistiqueService : IStatistiqueService
    {
        private readonly IReservationDbContext _DbContext;
        public StatistiqueService(IReservationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public AveragePriceByAvailable AveragePricePerUnitStatus()
        {
            return _DbContext.Units.Aggregate().Group(x => x.Show, r =>
            new AveragePriceByAvailable
            {
                Available = r.Key,
                AveragePrice = r.Average(x => x.DisplayPricing)
            }).FirstOrDefault();
        }

        public TotalAvailablePerStatus TotalAvailablePerUnitStatus()
        {
            return _DbContext.Units.Aggregate().Group(x => x.Tags, r =>
             new TotalAvailablePerStatus
             {
                 Types = r.Key,
                 Total = r.Sum(x => x.Quantity)
             }).FirstOrDefault();
        }
    }
}

//validation regex 2