using Core;
using UnityEngine;
using Tile = _1_Scripts.Core.TileData.Tile;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CreatorController", menuName = "New Controller/CreatorController")]
    public class CreatorController : Controller
    {
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        private GameObject parents, tilesParent;

        public override void OnInitialize()
        {
            parents = new GameObject("Parents");
            tilesParent = new GameObject("Tiles");

            tilesParent.transform.SetParent(parents.transform);
            
            CreateField();
        }

        public override void OnStart()
        {
           
        }

        private void CreateField()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    var tile = Instantiate(tilePrefab, tilesParent.transform);
                    tile.transform.position = new Vector3(j, i, 0);
                    InstallSprite(tile);
                    
                    tile.transform.SetParent(tilesParent.transform);
                }
            }
        }

        private void InstallSprite(Tile tile)
        {
            var randomSprite = _sprites[Random.Range(0, _sprites.Length)];
            tile.gameObject.GetComponent<SpriteRenderer>().sprite = randomSprite;
        }

        // public Tile CreateZombie(TileData data, Vector2 position)
        // {
        //     Tile newTile = Instantiate(tilePrefab, tilesParent);
        //
        // }
    }
}