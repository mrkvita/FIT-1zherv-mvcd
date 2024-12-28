using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class WeaponController : MonoBehaviour
{
    public Transform weaponTransform;
    private Vector2 mousePos;
    private Vector2 weaponPos;
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        if (playerController != null)
        {
            Shooting weapon = gameObject.GetComponentInChildren<Shooting>();
            if (weapon != null)
            {
                weapon.isEquiped = true;
            }
        }
    }
    void Update()
    {
        if (playerController == null)
        {
            return;
        }
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        weaponPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - weaponPos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        
        // used to control the weapon direction, because it is a child of the player 
        if (playerController.facingRight)
        {
            // limiting the range in which the player can aim 
            angle = Mathf.Clamp(angle, -70f, 70f);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            // limiting the range in which the player can aim
            if (angle < 0)
            {
                angle = Mathf.Clamp(angle, -180f, -70f);
            }
            else
            {
                angle = Mathf.Clamp(angle, 110f, 180f);
            }
            // it is done like this because : the first call establishes a set frame of reference so that 
            // it works allways no matter where the player aimed before 
            transform.rotation = Quaternion.Euler(0f, 180.0f, 0f);
            transform.rotation = Quaternion.Euler(180f, 0f, -angle);
        }
       // transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
