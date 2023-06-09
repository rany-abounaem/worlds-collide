using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldsCollide.Interaction
{
    public class InteractionComponent : MonoBehaviour
    {

        public void Interact()
        {
            var pointA = (Vector2)transform.position - new Vector2(0.5f, -0.5f);
            var pointB = (Vector2)transform.position + new Vector2(0.5f, -0.5f);
            var results = new List<Collider2D>();
            Physics2D.OverlapArea(pointA, pointB, new ContactFilter2D(), results);
            foreach (var collider in results)
            {
                if (collider.TryGetComponent(out IInteractable __interactable))
                {
                    var __player = GetComponent<Player>();
                    __interactable.Interact(__player);
                    break;
                }
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var __interactable = collision.GetComponentInParent<IInteractable>();
            __interactable?.DisplayInfo();
        }
    }
}
