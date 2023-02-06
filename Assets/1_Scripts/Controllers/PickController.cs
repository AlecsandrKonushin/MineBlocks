using System.Collections.Generic;
using System.Linq;
using _1_Scripts.Core.PickData;
using _1_Scripts.Core.TileData;
using _1_Scripts.Core.TileSource;
using Core;
using Gameplay;
using UnityEngine;
using DG.Tweening;

namespace _1_Scripts.Controllers
{
    [CreateAssetMenu(fileName = "PickController", menuName = "Controllers/PickController")]
    public class PickController : Controller
    {
        private Pick _pick;
        private EventsController _eventsController;
        private List<TileConnector> _tilesConnector = new List<TileConnector>();

        private bool _isAttack;

        public override void OnInitialize()
        {
            _pick = BoxControllers.GetController<CreatorController>().CreatePick();
            _eventsController = BoxControllers.GetController<EventsController>();

            _pick.gameObject.SetActive(false);

            _eventsController.SubscribeOnTileClicked(OnTileClicked);
        }

        private void OnTileClicked(Tile tile)
        {
            var connect = BoxControllers.GetController<TilesController>()
                .TileConnectors
                .Select(conn => conn.CanTouch(tile))
                .FirstOrDefault();

            Debug.Log("Conn is: " + connect);
            if (_isAttack == false && connect)
            {
                _isAttack = true;
                _pick.gameObject.SetActive(true);
                _pick.transform.position = tile.transform.position;
                _pick.transform
                    .DORotateQuaternion(Quaternion.Euler(0f, 0f, -90f), _pick.AttackDuration)
                    .OnComplete(() =>
                    {
                        tile.TakeDamage(_pick.Damage);
                        _pick.gameObject.SetActive(false);
                        _pick.transform.position = Vector3.zero;
                        _pick.transform.eulerAngles = Vector3.zero;
                        _isAttack = false;
                    });

                return;
            }
            
            Debug.Log("Такого нету");
        }
    }
}