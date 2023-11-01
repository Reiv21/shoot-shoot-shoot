using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] PlayerCharacter playerCharacter;
    public Weapon weapon;
    int tempAmmoInMagazine;
    public bool canShoot = true;
    public bool isReloading;
    float tempCooldown;

    float timeOfShooting;
    // Update is called once per frame
    void Start()
    {
        tempAmmoInMagazine = weapon.ammoInMagazine;
    }

    void Update()
    {
        if(timeOfShooting > 0) timeOfShooting -= Time.deltaTime * 0.5f;
        
        tempCooldown -= Time.deltaTime;
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            if(tempCooldown > 0 || !canShoot || isReloading) return;
            Shoot();
        }
        
        if(tempAmmoInMagazine <= 0) Reload();
    }

    void Reload()
    {
        isReloading = true;
        tempAmmoInMagazine = weapon.ammoInMagazine;
        Invoke("ReloadEnd", weapon.reloadTime);
    }
    void ReloadEnd()
    {
        isReloading = false;
    }
    void Shoot()
    {
        if(timeOfShooting < 1) timeOfShooting += 0.5f;
        
        tempCooldown = weapon.attackSpeed;
        tempAmmoInMagazine--;
        
        float z = -transform.rotation.eulerAngles.y +( Random.Range(-weapon.recoil, weapon.recoil) * Mathf.Clamp(timeOfShooting, 0, 1));
        projectile projectile =  Instantiate(weapon.projectile, transform.position, Quaternion.Euler(90, 0, z) ).GetComponent<projectile>();
        projectile.SetDamage(weapon.damage);
        
        playerCharacter.rb.AddForce(weapon.recoil * 50 * -transform.forward);
        playerCharacter.rb.AddForce(weapon.recoil * 30 * (Random.Range(0,2)*2-1) * transform.right);
    }
}
