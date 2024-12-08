using System.ComponentModel.DataAnnotations.Schema;
using Trace_Api.Model;

namespace Trace_Api.Dto
{
    public class CoordinateDto:BaseDto
    {
       

        private int coordinateID;
        private int? tripID;
        private decimal? longitude;
        private decimal? latitude;
        private DateTime? timestamp;

        public int CoordinateID
        {
            get { return coordinateID; }
            set { coordinateID = value; OnPropertyChanged(); }
        }

        public int? TripID
        {
            get { return tripID; }
            set { tripID = value; OnPropertyChanged(); }
        }

        public decimal? Longitude
        {
            get { return longitude; }
            set { longitude = value; OnPropertyChanged(); }
        }

        public decimal? Latitude
        {
            get { return latitude; }
            set { latitude = value; OnPropertyChanged(); }
        }

        public DateTime? Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; OnPropertyChanged(); }
        }
    }
}
