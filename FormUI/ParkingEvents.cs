using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    public class ParkingEvents
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FlatNumber { get; set; }
        public string CarRegisteredNumber { get; set; }
        public string EventType { get; set; }
        public DateTime TimeStamp { get; set; }
        public string EventDetails
        {
            get
            {
                return $"{FlatNumber} | {CarRegisteredNumber} | {TimeStamp} | {EventType}";
            }
        }
    }
}
