
namespace FleetLords
{
    using System.Collections.Generic;

    public enum PlanetSize { Tiny, Small, Medium, Large, Huge }

    public enum PlanetType { Asteroid, GasGiant, Continental, Gaian, Oceanic, Barren, Radiated, Toxic, Desert, Arid, Tundra }

    public enum PlanetRichness { VeryPoor, Poor, Abundant, Rich, VeryRich }

    public enum PlanetTraits { GoldDeposit, ArtifactWorld, Natives }

    public class Planet
    {
        public string Name { get; set; }
        
        public PlanetSize Size { get; set; }
        public PlanetType Type { get; set; }
        public PlanetRichness Richness { get; set; }
        public int Variant { get; set; } // used for randomisation, e.g. a seed

        private List<PlanetTraits> traits;
        private Colony colony;

        public Colony GetColony() 
        { 
            return colony; 
        }
    }    
}