using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Trace_Api.Model;
using System.ComponentModel;

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

        private DateTime? expectedstarttime;

        public DateTime? ExpectedStartTime
        {
            get { return expectedstarttime; }
            set { expectedstarttime = value; OnPropertyChanged(); }
        }

        // 预计结束时间
        private DateTime? expectedendtime;

        public DateTime? ExpectedEndTime
        {
            get { return expectedendtime; }
            set { expectedendtime = value; OnPropertyChanged(); }
        }

        //Trip的标题
        private string? title;

        public string? Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        // Trip的内容描述
        private string? content;

        public string? Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }

    }
}
