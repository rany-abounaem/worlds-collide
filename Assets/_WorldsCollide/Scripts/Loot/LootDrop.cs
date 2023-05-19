using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LootDrop : MonoBehaviour, IInteractable
{
    [field: SerializeField]
    public Item Item { get; set; }

    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
    BoxCollider2D _boxCollider;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Interact(Player player)
    {
        var __playerInventory = player.Inventory;
        __playerInventory.AddItem(Item);
        Destroy(gameObject);
    }

    public void Drop()
    {
        var randomX = Random.Range(-2f, 2f);
        var randomY = Random.Range(1f, 3f);
        _rigidbody.AddForce(new Vector2(randomX, randomY) * 200f);
        _rigidbody.AddTorque(randomX * 10f);
        _spriteRenderer.sprite = Item.GetSprite();
        _boxCollider.size = new Vector2(0.5f, 0.5f);
    }

}
