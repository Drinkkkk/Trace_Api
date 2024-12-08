using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Trace_Api.Model;

namespace Trace_Api.Dto
{
    public class TripDto:BaseDto
    {
       
        private int tripID;
        private int? truckID;
        private DateTime? tripStartTime;
        private DateTime? tripEndTime;
        private string? tripStatus;

        public int TripID
        {
            get { return tripID; }
            set { tripID = value; OnPropertyChanged(); }
        }

        public int? TruckID
        {
            get { return truckID; }
            set { truckID = value; OnPropertyChanged(); }
        }

        public DateTime? TripStartTime
        {
            get { return tripStartTime; }
            set { tripStartTime = value; OnPropertyChanged(); }
        }

        public DateTime? TripEndTime
        {
            get { return tripEndTime; }
            set { tripEndTime = value; OnPropertyChanged(); }
        }

        public string? TripStatus
        {
            get { return tripStatus; }
            set { tripStatus = value; OnPropertyChanged(); }
        }
    }
}
