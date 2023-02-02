using System;
using _1_Scripts.Core.TileData;
using Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1_Scripts.Controllers
{
    public class ClickController : MonoController
    {
        private EventsController _eventsController;

        private Camera _camera;
        // Есть EventsController и в нем пример как подписываться/отписываться/вызывать событие

        public override void OnStart()
        {
        }
        
        public override void OnInitialize()
        {
            _camera = Camera.main;
            _eventsController = BoxControllers.GetController<EventsController>(); 
            Debug.Log(_eventsController.Equals(null));
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = _camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.gameObject.TryGetComponent(out Tile tile))
                    {
                        Debug.Log(tile + "Tile clicked");
                        _eventsController.TileClicked(tile);
                    }
                }
            }
        }
    }
}