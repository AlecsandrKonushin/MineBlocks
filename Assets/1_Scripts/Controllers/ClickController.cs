using _1_Scripts.Core.TileSource;
using Core;
using UnityEngine;

namespace _1_Scripts.Controllers
{
    public class ClickController : MonoController
    {
        private EventsController _eventsController;
        private Camera _camera;

        public override void OnInitialize()
        {
            _camera = Camera.main;
            _eventsController = BoxControllers.GetController<EventsController>(); 
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = _camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.gameObject.TryGetComponent(out GameTile tile))
                    {
                        Debug.Log("tile hitted");
                        _eventsController.TileClicked(tile);
                    }
                }
            }
        }
    }
}