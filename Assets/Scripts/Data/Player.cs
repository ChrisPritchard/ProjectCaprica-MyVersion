
namespace FleetLords
{
    using System.Collections.Generic;

    public abstract class Player
    {
        public Player(int playerIndex)
        {
            PlayerIndex = playerIndex;
            colonies = new List<Colony>();
        }

        public readonly int PlayerIndex;
        int Race;
        int Money;
        bool[] unlockedTechnologies;

        List<Colony> colonies;

        public abstract void DoTurn();
    }
}