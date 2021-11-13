using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayReservationAndManagementSystem.Models
{
    public class trainOfSchedule
    {
        public int TrainID { get; set; }
        public int TrainScheduleID { get; set; }

        public int TrainNo { get; set; }
        public int StationID { get; set; }
        public string Code { get; set; }
        public string StartStationID { get; set; }
        public string EndStationID { get; set; }
        public int Distances { get; set; }

        [DataType(DataType.Time)]
        public System.TimeSpan ArrivalTime { get; set; }

        [DataType(DataType.Time)]
        public System.TimeSpan DepartureTime { get; set; }

    }
}