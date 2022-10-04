using Abstract;

namespace DefaultNamespace
{
    public class KillerBomb : KillerZone
    {
        protected override void KillFunction(Player ply)
        {
            print("Kill player!");
        }
    }
}