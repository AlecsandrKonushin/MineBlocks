using _1_Scripts.Core.TileData;
using Core;
using Gameplay;
using UnityEngine;

namespace _1_Scripts.Controllers
{
    [CreateAssetMenu(fileName = "TilesController", menuName = "Controllers/TilesController")]
    public class TilesController : Controller
    {
        private Tile[] _tiles;

        public override void OnInitialize()
        {
            _tiles = BoxControllers.GetController<CreatorController>().CreateTiles();
        }
    }
}