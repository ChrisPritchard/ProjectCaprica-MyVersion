namespace FleetLords
{
    using System;
    using System.Collections.Generic;

    // represents a constructed building on a planet / could also be a template
    public class Building
    {
        public string Name { get; set; }
        public int RequiredProduction { get; set; }
        public int UnlockedByTechID { get; set; }

        public int BonusFlatProduction { get; set; }
        public int BonusProductionPerWorker { get; set; }
        public int BonusFlatFood { get; set; }
        public int BonusFoodPerFarmer { get; set; }
        public int BonusFlatScience { get; set; }
        public int BonusSciencePerScientist { get; set; }

        public Action<Colony> EndOfTurn { get; set; }
    }

    public static class SetupBuildings
    {
        public static Dictionary<string, Building> Init()
        {
            return new Dictionary<string, Building>()
            {
                ["Barracks"] = new Building { Name = "Barracks", RequiredProduction = 100, UnlockedByTechID = 1, EndOfTurn = c => {} }
            };
        }
    }
}