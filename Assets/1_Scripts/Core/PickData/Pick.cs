using UnityEngine;

namespace _1_Scripts.Core.PickData
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Pick : MonoBehaviour
    {
        [SerializeField] private GameObject _damageEffect;
        [SerializeField] private int _damage;
        private SpriteRenderer _renderer;

        public int Damage => _damage;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
    }
}