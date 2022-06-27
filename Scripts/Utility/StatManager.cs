using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int baseArmor;
    public int basePower;
    public int baseSpeed;

    public int armor = 30;
    public int power = 5;
    public float speed = 1;
    public int shootStyle = 0;

    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameIsOver) { 
            armor = baseArmor +  player.GetComponent<Health>().currentHealth;
            power = basePower + player.GetComponent<ShootingController>().projectilePrefab.GetComponent<Damage>().damageAmount + player.GetComponent<ShootingController>().basePower;
            speed = baseSpeed +  player.GetComponent<Controller>().moveSpeed;
            shootStyle = player.GetComponent<ShootingController>().shootStyle;
        }
    }


}
