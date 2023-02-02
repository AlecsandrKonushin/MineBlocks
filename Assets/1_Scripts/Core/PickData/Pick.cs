using UnityEngine;

namespace _1_Scripts.Core.PickData
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Pick : MonoBehaviour
    {
        [SerializeField] private GameObject _damageEffect;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDuration;
        private SpriteRenderer _renderer;
        
        public float AttackDuration => _attackDuration;

        public int Damage => _damage;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
    }
}