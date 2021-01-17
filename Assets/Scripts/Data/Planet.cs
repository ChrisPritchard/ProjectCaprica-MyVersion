
namespace FleetLords
{
    using System.Collections.Generic;

    public class PlanetGraphic { }

    public enum PlanetSize { Tiny, Small, Medium, Large, Huge }

    public enum PlanetType { Asteroid, GasGiant, Continental, Gaian, Oceanic, Barren, Radiated, Toxic, Desert, Arid, Tundra }

    public enum PlanetRichness { VeryPoor, Poor, Abundant, Rich, VeryRich }

    public enum PlanetTraits { GoldDeposit, ArtifactWorld, Natives }

    public class Planet
    {
        public string Name { get; set; }
        public PlanetGraphic Graphic { get; set; }
        
        public PlanetSize Size { get; set; }
        public PlanetType Type { get; set; }
        public PlanetRichness Richness { get; set; }

        private List<PlanetTraits> traits;
        private Colony colony;

        public Colony GetColony() 
        { 
            return colony; 
        }
    }    
}