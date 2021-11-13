using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservationAndManagementSystem.Models
{
    [MetadataType(typeof(CheckExist))]
    public partial class Train
    {

    }
    public partial class TrainSchedule
    {

    }

    class CheckExist
    {
        [Remote("IsTrainNoExists", "Trains", ErrorMessage = "The Train No already in use in database")]
        public int TrainNo { get; set; }

        [Remote("isCheckExistTrainID", "TrainSchedules", ErrorMessage = "The Train ID already in use in database")]
        public int TrainID { get; set; }
    }

 

}