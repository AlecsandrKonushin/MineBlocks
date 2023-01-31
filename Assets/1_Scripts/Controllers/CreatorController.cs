using Core;
using UnityEngine;

namespace Gameplay
{
    public class CreatorController : Controller
    {
        private GameObject parents, tilesParent;

        //[SerializeField] private Tile tilePrefab;

        public override void OnInitialize()
        {
            parents = new GameObject("Parents");
            tilesParent = new GameObject("Tiles");

            tilesParent.transform.SetParent(parents.transform);
        }

        //public Tile CreateZombie(TileData data, Vector2 position)
        //{
        //    Tile newTile = Instantiate(tilePrefab, tilesParent);

        //}
    }
}