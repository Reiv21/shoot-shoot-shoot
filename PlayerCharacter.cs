using System;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, Idead
{
    public float speed = 5f;
    float xAxis;
    float zAxis;
    Vector3 movement;
    [SerializeField] Health healthScript;
    [SerializeField] GameObject gameoverMenu;
    [SerializeField] PlayerShooting playerShooting;
    public Rigidbody rb;
    void Awake()
    {
        healthScript.Dead = this;
        InvokeRepeating("Regen", 0, 0.5f);
    }

    void Regen()
    {
        healthScript.OnHealthChange();
    }
    void Update()
    {
        
        xAxis = Input.GetAxis("Horizontal"); 
        zAxis = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) && zAxis == 1)
        {
            xAxis *= 0.5f;
            zAxis *= 1.5f;
            playerShooting.canShoot = false;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) playerShooting.canShoot = true;
        movement = (xAxis * transform.right) + (zAxis * transform.forward);
        /*transform.position += Time.deltaTime * speed * movement;*/
        rb.velocity = movement * speed;
        
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            float singleStep = speed * Time.deltaTime;
            Vector3 target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 targetDirection = target - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void Dead()
    {
        gameoverMenu.SetActive(true);
        Destroy(gameObject);
    }
    
}
