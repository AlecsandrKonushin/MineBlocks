using _1_Scripts.Core.TileData;

namespace _1_Scripts.Core.TileSource
{
    public class GameTile : Tile
    {
        protected override int AffectDamage(int damage)
        {
            return damage;
        }
    }
}