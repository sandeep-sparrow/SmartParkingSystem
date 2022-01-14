using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    public class ResidentsParking
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FlatNumber { get; set; }
        public string CarRegisteredNumber { get; set; }
        public string CarModelName { get; set; }
        public string CarColor { get; set; }

        public string FullResidentInfo
        {
            get
            {
                return $"{FirstName} {LastName} | {FlatNumber}";
            }
        }
    }
}
