
namespace FleetLords
{
    public class Colony
    {
        public Planet Planet { get; set; }

        int popFarmers;
        int popWorkers;
        int popScientists;

        int flatProduction;
        int productionPerWorker; //richness/2+1

        public int ProductionPerTurn()
        {
            return flatProduction + productionPerWorker * popWorkers;
        }

        public int Population => popFarmers + popWorkers + popScientists;

        string[] buildings;

        public void DoEndTurn()
        {
            // go through all buildings and run end of turn func
        }

        public int MaxPopulation()
        {
            // Could be improved by traits

            return Config.GetInt("PLANET_MAX_POP_"+Planet.Size.ToString());
        }
    }
}