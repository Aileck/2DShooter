using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleChanger : MonoBehaviour
{
    public int style;

    public float dissapear = 20f;
    public bool ifDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dissapear -= Time.deltaTime;
        if (dissapear <= 0 && ifDestroy)
        {
            Destroy(this.gameObject);
        }
    }


}
