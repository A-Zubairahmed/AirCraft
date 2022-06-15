using Rusada.Models;

namespace Rusada.Service
{
    public interface IAircraft
    {
        public List<AirCraftViewModel> GetAirCrafts();
        public void Create(AirCraftViewModel airCraft);
        public AirCraftViewModel GetAirCraft(int Id);
        public void Edit(AirCraftViewModel airCraft);
        public void Delete(int Id);
    }
}
