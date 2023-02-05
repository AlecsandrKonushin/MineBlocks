using System;
using UnityEngine;

namespace _1_Scripts.Core.TileData
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Tile : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private GameObject _damageEffect;
        private SpriteRenderer _renderer;

        public event Action Died;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void TakeDamage(int damage)
        {
            _hp -= AffectDamage(damage);
            
            if (_hp <= 0)
            {
                _hp = 0;
                Die();
            }
            
            //Instantiate(_damageEffect, transform.position, Quaternion.identity);
        }

        protected virtual int AffectDamage(int damage)
        {
            return damage;
        }

        private void Die()
        {
            Died?.Invoke();
            
            Destroy(gameObject);
        }
    }
}