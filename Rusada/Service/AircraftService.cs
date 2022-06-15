using Rusada.DBModels;
using Rusada.Models;

namespace Rusada.Service
{
    public class AircraftService :IAircraft
    {
        public List<AirCraftViewModel> GetAirCrafts()
        {
            var Context = new AircraftContext();
            var aircraftDetails=new List<AirCraftViewModel>();
            var details = Context.AircraftDetails.ToList();
            details.ForEach(x =>
            {
                var aircraft = new AirCraftViewModel
                {
                    Make = x.Make,
                    Registration=x.Registration,
                    Model=x.Model,
                    Location=x.Location,
                    Time=x.Time,
                    Id=x.Id,


                };
                aircraftDetails.Add(aircraft);

            });
            return aircraftDetails;
        }
        public AirCraftViewModel GetAirCraft(int Id)
        {
            var Context = new AircraftContext();
          var aircraft=new AirCraftViewModel();
            var detail = Context.AircraftDetails.FirstOrDefault(x=>x.Id==Id);
            if (detail != null)
            {
                aircraft.Make = detail.Make;
                aircraft.Model = detail.Model;
                aircraft.Registration = detail.Registration;
                aircraft.Location = detail.Location;
                aircraft.Time = detail.Time;
            }
            return aircraft;
        }
        public void Create(AirCraftViewModel airCraft)
        {
            var Context = new AircraftContext();
            var dbAircreaft = new AircraftDetail();
            dbAircreaft.Make = airCraft.Make;
            dbAircreaft.Model = airCraft.Model;
            dbAircreaft.Registration = airCraft.Registration;
            dbAircreaft.Location = airCraft.Location;
            dbAircreaft.Time = airCraft.Time;
            Context.AircraftDetails.Add(dbAircreaft);
            Context.SaveChanges();
        }

        public void Edit(AirCraftViewModel airCraft)
        {
            var Context = new AircraftContext();

           
            var dbAircreaft = Context.AircraftDetails.FirstOrDefault(X => X.Id == airCraft.Id);
            if (dbAircreaft != null)
            {
                //   dbAircreaft.Id =airCraft.Id
                dbAircreaft.Make = airCraft.Make;
                dbAircreaft.Model = airCraft.Model;
                dbAircreaft.Registration = airCraft.Registration;
                dbAircreaft.Location = airCraft.Location;
                dbAircreaft.Time = airCraft.Time;
                Context.AircraftDetails.Update(dbAircreaft);
                Context.SaveChanges();

            }
           
        }
        public void Delete(int Id)
        {
            var Context = new AircraftContext();
            var dbAircreaft = Context.AircraftDetails.FirstOrDefault(X => X.Id == Id);
            if (dbAircreaft != null)
            {
                Context.AircraftDetails.Remove(dbAircreaft);
                Context.SaveChanges();
            }
        }
    }
}
