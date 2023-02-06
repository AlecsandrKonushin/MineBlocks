using _1_Scripts.Core.TileData;

namespace _1_Scripts.Core.TileSource
{
    public class TileConnector
    {
        private Tile _source;
        private Tile _destination;

        public TileConnector(Tile source, Tile destination)
        {
            _source = source;
            _destination = destination;
        }

        public bool CanTouch(Tile tile)
        {
            return tile == _source;
        }
    }
}