using _1_Scripts.Core.PickData;
using _1_Scripts.Core.TileData;
using Core;
using UnityEngine;

namespace _1_Scripts.Controllers
{
    public class PickController : MonoController
    {
        [SerializeField] private Pick _pick;
        private ClickController _clickController;

        public override void OnStart()
        {
            _clickController = BoxControllers.GetController<ClickController>();
         // load from resources
            _pick.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _clickController.ClickDowned += OnClickDowned;
            _clickController.ClickUpped += OnClickUpped;
        }

        private void OnDisable()
        {
            _clickController.ClickDowned -= OnClickDowned;
            _clickController.ClickUpped -= OnClickUpped;
        }

        private void OnClickDowned(Tile tile, Vector3 tilePosition)
        {
            _pick.gameObject.SetActive(true);
            _pick.transform.position = tilePosition;
            tile.TakeDamage(_pick.Damage);
        }

        private void OnClickUpped()
        {
            _pick.gameObject.SetActive(false);
        }
    }
}