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

    private GameObject player;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!GameManager.instance.gameIsOver && player != null) {
            armor = player.GetComponent<Health>().currentHealth;
            power = basePower + player.GetComponent<ShootingController>().projectilePrefab.GetComponent<Damage>().damageAmount + player.GetComponent<ShootingController>().basePower;
            speed = baseSpeed +  player.GetComponent<Controller>().moveSpeed;
            player.GetComponent<ShootingController>().shootStyle = this.shootStyle;
            player.GetComponent<ShootingController>().projectilePrefab = player.GetComponent<ShootingController>().projectilePrefabList[this.shootStyle];
        }
    }


}
