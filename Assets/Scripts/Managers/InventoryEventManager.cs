using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.Events.InventoryEventManager
{
    public class InventoryEventManager : MonoBehaviour
    {
        public delegate void QuickInventoryAddHandler(Sprite itemIcon);
        public static event QuickInventoryAddHandler quickInventoryAddEvent;

        public delegate void QuickInventoryRemoveHandler();
        public static event QuickInventoryAddHandler quickInventoryRemoveEvent;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }
    }
}
