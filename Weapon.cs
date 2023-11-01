using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Item/Weapon", order = 1)]

public class Weapon : Item
{
    
    public float damage;
    public float attackSpeed;
    public int  ammoInMagazine;
    public float reloadTime;
    public float recoil;
    public GameObject projectile;
}
