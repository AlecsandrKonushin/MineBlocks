﻿using System;
using _1_Scripts.Core.TileData;
using Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1_Scripts.Controllers
{
    // Его не нужно делать Mono
    public class ClickController : MonoController, IPointerDownHandler
    {
        private Camera _camera;

        // Не нужно никаких событие к контроллерах, будет спагети
        // Есть EventsController и в нем пример как подписываться/отписываться/вызывать событие
        public event Action<Tile, Vector3> ClickDowned;
        public event Action ClickUpped;

        public override void OnStart()
        {
            _camera = Camera.main;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                    		Debug.Log (this.gameObject.name + " Was Clicked.");

            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.transform.TryGetComponent(out Tile tile))
                {
                    ClickDowned?.Invoke(tile, hit.transform.position);
                }
            }
        }

        private void OnMouseUp()
        {
            ClickUpped?.Invoke();
        }
    }
}