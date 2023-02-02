using _1_Scripts.Core.PickData;
using _1_Scripts.Core.TileData;
using Core;
using Gameplay;
using UnityEngine;

namespace _1_Scripts.Controllers
{
    [CreateAssetMenu(fileName = "PickController", menuName = "Controllers/PickController")]
    public class PickController : Controller
    {
        private Pick _pick;
        private EventsController _eventsController;

        public override void OnInitialize()
        {
            _pick = BoxControllers.GetController<CreatorController>().CreatePick();
            _eventsController = BoxControllers.GetController<EventsController>();

            _pick.gameObject.SetActive(false);

            _eventsController.SubscribeOnTileClicked(OnTileClicked);
        }

        // Должен подписываться на EventsController

        // зачем отписка? контроллеры не отключаюьтся/не включаются
        private void OnDisable()
        {
           // _eventsController.UnsubscribeOnTileClicked(OnTileClicked);
        }

        private void OnTileClicked(Tile tile)
        {
            _pick.gameObject.SetActive(true);
            _pick.transform.position = tile.transform.position;
            Debug.Log("Tile clicked");
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