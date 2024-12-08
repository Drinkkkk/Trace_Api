using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Trace_Api.Model;

namespace Trace_Api.Dto
{
    public class TruckDto:BaseDto
    {
        private int truckid;

        public int TruckID
        {
            get { return truckid; }
            set { truckid = value; OnPropertyChanged(); }
        }

        private string? licenseplate;

        public string? LicensePlate
        {
            get { return licenseplate; }
            set { licenseplate = value; OnPropertyChanged(); }
        }

      
   
        private string? vehiclemodel;

        public string? VehicleModel
        {
            get { return vehiclemodel; }
            set { vehiclemodel = value; OnPropertyChanged(); }
        }

      

        private string? manufacturer;

        public string? Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; OnPropertyChanged(); }
        }

        private int? loadcapacity;

        public int? LoadCapacity
        {
            get { return loadcapacity; }
            set { loadcapacity = value; OnPropertyChanged(); }
        }

        private string? status;

        public string? Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }

       

    
    }
}
