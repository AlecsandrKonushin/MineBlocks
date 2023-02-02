using UnityEngine;

namespace _1_Scripts.Core.TileData
{
    [CreateAssetMenu(fileName = "TilesData", menuName = "Create Data/TilesData")]
    public class TilesData : ScriptableObject
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
                
        public int Width => _width;
        public int Height => _height;
    }
}