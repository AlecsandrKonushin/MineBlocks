using _1_Scripts.Core.PickData;
using _1_Scripts.Core.TileData;
using Core;
using UnityEngine;

namespace _1_Scripts.Controllers
{
    // Его не нужно делать Mono
    public class PickController : MonoController
    {
        // Создает creator controller - убрать [SerializeField]
        [SerializeField] private Pick _pick;
        private ClickController _clickController;

        public override void OnStart()
        {
            _clickController = BoxControllers.GetController<ClickController>();
         // load from resources
            _pick.gameObject.SetActive(false);
        }

        // Должен подписываться на EventsController
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
            // Тут еще анимацию через doTween сделать нужно, удар киркой и в onComplete выключать кирку
            tile.TakeDamage(_pick.Damage);
        }

        private void OnClickUpped()
        {
            // пользователь быстро нажмет и отпустит и кирка быстро исчезнет
            _pick.gameObject.SetActive(false);
        }
    }
}