using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldsCollide.Input;

namespace WorldsCollide.Interaction
{
    public class InteractionManager : MonoBehaviour
    {
        [SerializeField]
        InputManager _inputManager;


        private void Start()
        {
            _inputManager.InputActions.Game.Pickup.performed += _ => HandlePickup();
        }
        private void HandlePickup()
        {
            var pointA = (Vector2)transform.position - new Vector2(0.5f, -0.5f);
            var pointB = (Vector2)transform.position + new Vector2(0.5f, -0.5f);
            var results = new List<Collider2D>();
            Physics2D.OverlapArea(pointA, pointB, new ContactFilter2D(), results);
            foreach (var collider in results)
            {
                if (collider.TryGetComponent(out LootDrop lootDrop))
                {
                    var __playerInventory = GetComponent<InventoryManager>();
                    __playerInventory.AddItem(lootDrop.Item);
                    Destroy(lootDrop.gameObject);
                    break;
                }
            }

        }
    }
}
