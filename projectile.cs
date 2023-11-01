using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float liveTime;
    public bool isProjectileManager;
    public projectile[] projectiles;
    
    void Update()
    {
        transform.position += (transform.up * Time.deltaTime * speed);
        liveTime -= Time.deltaTime;
        if(liveTime < 0) Destroy(gameObject);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 0.5f))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Health>().ChangeHealth(-damage);
                Destroy(gameObject);
            }
        }
    }
    
    public void SetDamage(float damage)
    {
        if (isProjectileManager)
        {
            foreach (var projectile in projectiles)
            {
                projectile.damage = damage;
            }
            return;
        }
        this.damage = damage;
    }
}
