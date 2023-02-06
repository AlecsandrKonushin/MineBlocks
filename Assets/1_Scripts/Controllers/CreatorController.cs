using System.Collections.Generic;
using _1_Scripts.Core.PickData;
using _1_Scripts.Core.TileData;
using _1_Scripts.Core.TileSource;
using Core;
using UnityEngine;
using Tile = _1_Scripts.Core.TileData.Tile;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CreatorController", menuName = "Controllers/CreatorController")]
    public class CreatorController : MonoController
    {
        [SerializeField] private GameTile _gameTilePrefab;
        [SerializeField] private NonGameTile _nonGameTilePrefab;
        [SerializeField] private Pick _pickPrefab;
        [SerializeField] private Sprite[] _nonGameTiles;
        [SerializeField] private Sprite[] _gameTiles;
        [SerializeField] private TilesData _tileData;

        private GameObject parents, tilesParent;

        public override void OnInitialize()
        {
            parents = new GameObject("Parents");
            tilesParent = new GameObject("Tiles");

            tilesParent.transform.SetParent(parents.transform);
        }
        
        public Pick CreatePick()
        {
            return Instantiate(_pickPrefab, transform.position, Quaternion.identity);
        }

        public Tile[] CreateMap()
        {
            var nonGameTile = SpawnTiles(_nonGameTilePrefab);
            var gameTiles = SpawnTiles(_gameTilePrefab);

            return gameTiles.ToArray();
        }

        public TileConnector[] CreateConnections(Tile[] tiles)
        {
            var tilesConnector = new List<TileConnector>();
            
            for (int i = _tileData.Height - 1; i > 0; i--)
            {
                for (int j = _tileData.Width - 1; j > 0; j--)
                {
                    var idxX = i + 1;
                    var idxY = j + 1;
                    
                    tilesConnector.Add(new TileConnector(tiles[i * j], tiles[idxX * idxY]));
                    Debug.Log(i * j + "  " + idxX * idxY);
                }
            }

            return tilesConnector.ToArray();
        }

        private List<Tile> SpawnTiles(Tile tilePrefab)
        {
            var tilesList = new List<Tile>();

            for (int i = _tileData.Height; i > 0 ; i--)
            {
                for (int j = _tileData.Width; j > 0 ; j--)
                {
                    var tile = Instantiate(tilePrefab, tilesParent.transform);
                    tile.transform.position = new Vector3(j, i, 0);
            
                    InstallSprite(tile);
                    tile.transform.SetParent(tilesParent.transform);
                    
                    tilesList.Add(tile);
                }
            }

            return tilesList;
        }

        private void InstallSprite(Tile tile)
        {
            var randomSprite = tile is GameTile ? _gameTiles[Random.Range(0, _gameTiles.Length)] : 
                _nonGameTiles[Random.Range(0, _nonGameTiles.Length)];
            
            tile.gameObject.GetComponent<SpriteRenderer>().sprite = randomSprite;
            tile.gameObject.GetComponent<SpriteRenderer>().sortingOrder = tile is GameTile ? 1 : 0;
        }
    }
}