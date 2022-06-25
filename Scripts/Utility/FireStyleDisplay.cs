using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireStyleDisplay : MonoBehaviour
{
    public Image[] icons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().shootStyle == 0)
        {
            icons[0].color = new Color(icons[0].color.r, icons[0].color.g, icons[0].color.b, 1f);
            icons[1].color = new Color(icons[1].color.r, icons[1].color.g, icons[1].color.b, 0.5f);
            icons[2].color = new Color(icons[2].color.r, icons[2].color.g, icons[2].color.b, 0.5f);
        }
        else if (GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().shootStyle == 1)
        {
            icons[0].color = new Color(icons[0].color.r, icons[0].color.g, icons[0].color.b, 0.5f);
            icons[1].color = new Color(icons[1].color.r, icons[1].color.g, icons[1].color.b, 1f);
            icons[2].color = new Color(icons[2].color.r, icons[2].color.g, icons[2].color.b, 0.5f);
        }
        else {
            icons[0].color = new Color(icons[0].color.r, icons[0].color.g, icons[0].color.b, 0.5f);
            icons[1].color = new Color(icons[1].color.r, icons[1].color.g, icons[1].color.b, 0.5f);
            icons[2].color = new Color(icons[2].color.r, icons[2].color.g, icons[2].color.b, 1f);
        }
    }
}
