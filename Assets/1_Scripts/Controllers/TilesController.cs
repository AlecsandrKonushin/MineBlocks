using _1_Scripts.Core.TileData;
using Core;
using UnityEngine;

public class TilesController : Controller
{
    // без [SerializeField]
    // Вызывает у creatorController inst tile и добавляет экземпляр в массив
    [SerializeField] private Tile _tilePrefab;
    private Tile[] _tiles;
}