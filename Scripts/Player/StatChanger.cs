using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public int armor = 0;
    public int power = 0;
    public int speed = 0;

    public float dissapear = 20f;
    public bool ifDissapear = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dissapear -= Time.deltaTime;
        if (dissapear <= 0) {
            Destroy(this.gameObject);
        }
    }
}
