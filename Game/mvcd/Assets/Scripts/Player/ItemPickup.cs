using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public Transform weaponHolder;
   public GameObject currentItem; 
   public KeyCode pickupKey = KeyCode.E;

   private void OnTriggerStay2D(Collider2D other)
   {
       if (other.gameObject.CompareTag("Weapon"))
       {
           GameObject groundItem = other.gameObject;
           if (Input.GetKeyDown(pickupKey))
           {
               DropWeapon();
               PickupWeapon(groundItem);
           }
       }
   }
   private void DropWeapon()
   {
       if (currentItem != null)
       {
           currentItem.transform.SetParent(null);
           currentItem.transform.position = transform.position;
           currentItem.GetComponent<Shooting>().isEquiped = false;
       }
   }
   private void PickupWeapon(GameObject newItem)
   {
       newItem.transform.SetParent(weaponHolder);
       newItem.transform.position = weaponHolder.transform.position;
       newItem.transform.rotation = currentItem.transform.rotation;
       newItem.GetComponent<Shooting>().isEquiped = true;
       currentItem = newItem;
   }

}
