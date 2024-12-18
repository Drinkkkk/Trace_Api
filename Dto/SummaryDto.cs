using System.Collections.ObjectModel;

namespace Trace_Api.Dto
{
    public class SummaryDto:BaseDto
    {

        private int sum;
        private int completedCount;
        private int tripCount;
        private string completedRatio;


        /// <summary>
        /// 货车总数
        /// </summary>
        public int Sum
        {
            get { return sum; }
            set { sum = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 完成任务数量
        /// </summary>
        public int CompletedCount
        {
            get { return completedCount; }
            set { completedCount = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 行程数量
        /// </summary>
        public int TripCount
        {
            get { return tripCount; }
            set { tripCount = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 完成比例
        /// </summary>
        public string CompletedRatio
        {
            get { return completedRatio; }
            set { completedRatio = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TruckDto> trucklist;
        private ObservableCollection<TripDto> triplist;

        /// <summary>
        /// 货车列表
        /// </summary>
        public ObservableCollection<TruckDto> TruckList
        {
            get { return trucklist; }
            set { trucklist = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 行程列表
        /// </summary>
        public ObservableCollection<TripDto> TripList
        {
            get { return triplist; }
            set { triplist = value; OnPropertyChanged(); }
        }

    }
}
