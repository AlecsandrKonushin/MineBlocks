using _1_Scripts.Core.TileData;
using Core;
using UnityEngine;

public class TilesController : Controller
{
    [SerializeField] private Tile _tilePrefab;
    private Tile[] _tiles;
}