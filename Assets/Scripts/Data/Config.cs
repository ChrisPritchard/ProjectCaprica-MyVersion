namespace FleetLords
{
    using UnityEngine;

    public static class Config
    {
        public static int GetInt(string key)
        {
            switch (key)
            {
                case "MAX_PLANETS":
                    return 6;
                case "PLANET_MAX_POP_Tiny":
                    return 4;
                case "PLANET_MAX_POP_Small":
                    return 6;
                case "PLANET_MAX_POP_Medium":
                    return 8;
                case "PLANET_MAX_POP_Large":
                    return 12;
                case "PLANET_MAX_POP_Huge":
                    return 16;
            }

            Debug.Log("Invalid config key: "+key);
            return -1;
        }
    }
}