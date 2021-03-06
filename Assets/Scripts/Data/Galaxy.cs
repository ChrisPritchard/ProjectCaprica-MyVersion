
namespace FleetLords
{
    using UnityEngine;

    public class Galaxy
    {
        private System.Random baseRandom = new System.Random();

        public StarSystem[] starSystems;

        public void GenerateStarSystems()
        {
            starSystems = new StarSystem[Config.NumStars];

            for (var i = 0; i < starSystems.Length; i++)
            {
                var system = new StarSystem();
                system.Name = GetStarName();
                system.Type = GetStarType();
                system.Position = GetRandomPosition(i-1);
                system.GeneratePlanets(system);
                starSystems[i] = system;
            }

            Debug.Log("Generated "+starSystems.Length+" star systems");
        }

        private Vector2 GetRandomPosition(int soFar)
        {
            var dim = Config.GalaxyWidth;
            var candidate = new Vector2(
                Random.Range(-dim,dim),
                Random.Range(-dim,dim)
            );
            for (var i = 0; i <= soFar; i++)
            {
                var distance = Vector2.Distance(candidate, starSystems[i].Position);
                if (distance < Config.MinDistance)
                {
                    return GetRandomPosition(soFar);
                }
            }
            return candidate;
        }

        private string GetStarName()
        {
            var buffer = new byte[4];
            baseRandom.NextBytes(buffer);
            var name = new System.Text.StringBuilder();
            foreach(var b in buffer)
            {
                name.AppendFormat("{0:x2}", b);
            }
            return name.ToString();
        }

        private StarType GetStarType()
        {
            return (StarType)(int)Random.Range(0, 5);
        }

        public void SaveGalaxy()
        {

        }

        public void LoadGalaxy()
        {

        }
    }
}