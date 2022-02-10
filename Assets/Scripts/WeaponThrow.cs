using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrow : MonoBehaviour
{
    public GameObject weapon;
    public Vector2 mousePos;
    //Camera.main.ScreenToWorldPoint(Input.mousePosition))
    void Start()
    {
        PlayerController.instance.rightClickPressed.AddListener(() => UpdateLastRightClickPos());
        PlayerController.instance.throwWeapon.AddListener(() => ThrowWeapon());
    }

    void UpdateLastRightClickPos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void ThrowWeapon()
    {
        int xScale = PlayerController.instance.faceRight? 1 : -1;
        float rotValue = xScale > 0 ? 230 : 120;
        Rigidbody2D wepRb = Instantiate(weapon, transform.position, Quaternion.Euler(new Vector3(0,0,rotValue))).GetComponent<Rigidbody2D>();
        wepRb.AddTorque(10f * xScale, ForceMode2D.Impulse);
        wepRb.AddForce((mousePos - (Vector2)PlayerController.instance.gameObject.transform.position).normalized * 25f, ForceMode2D.Impulse);

    }
}
