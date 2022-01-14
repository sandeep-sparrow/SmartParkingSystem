using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;


namespace FormUI
{
    public class DataAccess
    {
        public object FlatNumber { get; private set; }
        public object CarRegisteredNumber { get; private set; }

        public List<ResidentsParking> GetResident(string flatNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("smartParkingDB")))
            {
                var output = connection.Query<ResidentsParking>("ResidentVehical_GetResidentByFlatNumber @FlatNumber", new { FlatNumber = flatNumber }).ToList();
                return output;
            }
        }

        public List<ResidentsParking> GetResidentFormal(string flatNumber, string registeredCarNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("smartParkingDB")))
            {
                var output = connection.Query<ResidentsParking>("ResidentVehical_GetResidentFormal @FlatNumber, @CarRegisteredNumber", new { FlatNumber = flatNumber, CarRegisteredNumber = registeredCarNumber }).ToList();
                return output;
            }
        }

        public void InsertParkingEvent(List<ResidentsParking> resident, string eventCode)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("smartParkingDB")))
            {
                if(resident.Count == 0)
                {
                    Console.WriteLine("No resident found to insert any parking event");
                }
                else
                {
                    foreach (var res in resident)
                    {
                        ParkingEvents newEvent = new ParkingEvents()
                        {
                            FirstName = res.FirstName,
                            LastName = res.LastName,
                            FlatNumber = res.FlatNumber,
                            CarRegisteredNumber = res.CarRegisteredNumber,
                            EventType = eventCode,
                            TimeStamp = DateTime.Now
                        };
                        List<ParkingEvents> parkingEvents = new List<ParkingEvents>();
                        parkingEvents.Add(newEvent);
                        connection.Execute("ParkingEvents_Insert @FirstName, @LastName, @FlatNumber, @CarRegisteredNumber, @EventType, @TimeStamp", parkingEvents);
                        Console.WriteLine("Parking event inserted succesfully");
                    }
                }

            }
        }

        public List<ParkingEvents> GetParkingEvents(string registeredCarNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("smartParkingDB")))
            {
                var output = connection.Query<ParkingEvents>("ParkingEvents_GetEvents @CarRegisteredNumber", new { CarRegisteredNumber = registeredCarNumber }).ToList();
                if(output.Count == 0)
                {
                    ParkingEvents newEvent = new ParkingEvents();
                    newEvent.FlatNumber = "No Found";
                    newEvent.CarRegisteredNumber = "No Found";
                    newEvent.TimeStamp = default(DateTime);
                    newEvent.EventType = "NA";
                    List<ParkingEvents> parkingEvents = new List<ParkingEvents>();
                    parkingEvents.Add(newEvent);
                    return parkingEvents;
                }
                return output;
            }
        }
    }
}
