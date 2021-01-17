
namespace FleetLords
{
    using System.Collections.Generic;
    using UnityEngine;

    public class StarGraphic { }

    public enum StarType { Blue, White, Yellow, Orange, Red }

    public class StarSystem
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }

        public StarGraphic Graphic { get; set; }
        public StarType Type { get; set; }

        private Planet[] planets;

        public StarSystem()
        {
            planets = new Planet[Config.GetInt("MAX_PLANETS")];

            GeneratePlanets();
        }
        public void GeneratePlanets()
        {
            
        }

        public Planet GetPlanet(int index)
        {
            if (index < 0 || index > planets.Length)
            {
                return null;
            }

            return planets[index];
        }
    }
}