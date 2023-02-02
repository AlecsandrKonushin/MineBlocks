using System;
using System.Linq;
using _1_Scripts.Core.TileData;
using Logs;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "EventsController", menuName = "Controllers/EventsController")]
    public class EventsController : Controller
    {
        private Action StartGameEvent;
        private Action<int> ChangeGoldEvent;

        private Action<Tile> TileClick;

        public void SubscribeOnChangeGold(Action<int> sender)
        {
            if (ChangeGoldEvent!= null && ChangeGoldEvent.GetInvocationList().Contains(sender))
            {
                LogManager.LogError($"Try 2 subscribes on ChangeGoldEvent");
            }
            else
            {
                ChangeGoldEvent += sender;
            }
        }

        public void UnsubscribeOnChangeGold(Action<int> sender)
        {
            ChangeGoldEvent -= sender;
        }

        public void ChangeGold(int value)
        {
            ChangeGoldEvent?.Invoke(value);
        }
        
        public void SubscribeOnTileClicked(Action<Tile> sender)
        {
            if (ChangeGoldEvent!= null && ChangeGoldEvent.GetInvocationList().Contains(sender))
            {
                LogManager.LogError($"Try 2 subscribes on ChangeGoldEvent");
            }
            else
            {
                TileClick += sender;
            }
        }

        public void UnsubscribeOnTileClicked(Action<Tile> sender)
        {
            TileClick -= sender;
        }

        public void TileClicked(Tile tile)
        {
            TileClick?.Invoke(tile);
        }
    }
}