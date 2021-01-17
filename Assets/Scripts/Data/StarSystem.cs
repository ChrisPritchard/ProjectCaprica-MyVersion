
namespace FleetLords
{
    using UnityEngine;

    public enum StarType { Blue, White, Yellow, Orange, Red }

    public class StarSystem
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public StarType Type { get; set; }

        public Planet[] Planets { get; set; }

        public StarSystem()
        {
            Planets = new Planet[Config.MaxPlanets];
        }

        public void GeneratePlanets(StarSystem system)
        {
            var count = 0;
            for (var i = 0; i < Planets.Length; i++)
            {
                if(Random.Range(0f, 1f) > Config.PlanetChance)
                    continue;

                count++;
                var planet = new Planet();
                planet.Name = system.Name + "-"+count;
                Planets[i] = planet;
            }
        }
    }
}