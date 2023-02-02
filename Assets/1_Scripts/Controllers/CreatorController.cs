using System.Collections.Generic;
using _1_Scripts.Core.PickData;
using _1_Scripts.Core.TileData;
using Core;
using UnityEngine;
using Tile = _1_Scripts.Core.TileData.Tile;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CreatorController", menuName = "New Controller/CreatorController")]
    public class CreatorController : MonoController
    {
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private Pick _pickPrefab;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private TilesData _tileData;

        private GameObject parents, tilesParent;

        public override void OnInitialize()
        {
            parents = new GameObject("Parents");
            tilesParent = new GameObject("Tiles");

            tilesParent.transform.SetParent(parents.transform);
        }

        public override void OnStart()
        {
           
        }
        
        public Pick CreatePick()
        {
            return Instantiate(_pickPrefab, transform.position, Quaternion.identity);
        }

        public Tile[] CreateTiles()
        {
            var tilesList = new List<Tile>();
            
            for (int i = 0; i < _tileData.Height; i++)
            {
                for (int j = 0; j < _tileData.Width; j++)
                {
                    var tile = Instantiate(tilePrefab, tilesParent.transform);
                    tile.transform.position = new Vector3(j, i, 0);
                    InstallSprite(tile);
                    
                    tile.transform.SetParent(tilesParent.transform);

                    tilesList.Add(tile);
                }
            }

            return tilesList.ToArray();
        }

        private void InstallSprite(Tile tile)
        {
            var randomSprite = _sprites[Random.Range(0, _sprites.Length)];
            tile.gameObject.GetComponent<SpriteRenderer>().sprite = randomSprite;
        }
    }
}