using _1_Scripts.Core.TileData;
using _1_Scripts.Core.TileSource;
using Core;
using Gameplay;
using UnityEngine;

namespace _1_Scripts.Controllers
{
    [CreateAssetMenu(fileName = "TilesController", menuName = "Controllers/TilesController")]
    public class TilesController : Controller
    {
        private Tile[] _tiles;
        private TileConnector[] _tilesConnectors;

        public TileConnector[] TileConnectors => _tilesConnectors;

        public override void OnInitialize()
        {
            _tiles = BoxControllers.GetController<CreatorController>().CreateMap();
            _tilesConnectors = BoxControllers.GetController<CreatorController>().CreateConnections(_tiles);
        }
    }
}