using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    
    public Transform bulletSpawn;
    
    public bool isEquiped = true;
    
    public AudioSource audioSource;
    
    public AudioClip shootingAudioclip;
    
    [SerializeField] private int shotType = 0;
    
    [SerializeField] private int shotGunBullets;
    
    [SerializeField] private float shotGunSpread ;
    
    public float bulletForce = 20f;
    
    void Update()
    {
        if (isEquiped && Input.GetButtonDown("Fire1"))
        {
            // pistol
            switch (shotType)
            {
                case 0:
                    ShootPistol();
                    break;
                case 1:
                    ShootShotGun();
                    break;
                default:
                    break;
            }
        }
    }

    void ShootPistol()
    {
        audioSource.PlayOneShot(shootingAudioclip);
        SpawnBullet(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation, bulletSpawn.right);
    }
    
    private void SpawnBullet(GameObject bulletPre, Vector3 position, Quaternion rotation, Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPre, position, rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
    void ShootShotGun()
    {
        
            audioSource.PlayOneShot(shootingAudioclip);
            for (int i = 0; i < shotGunBullets; i++)
            {
                float angle = (i - (shotGunBullets/2f)) * shotGunSpread / shotGunBullets;
                Vector3 dir = Quaternion.Euler(0, 0, angle) * bulletSpawn.right;
                SpawnBullet(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation,dir);
            }
    }
}
