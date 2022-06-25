using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Text displayText = null;

    public int select;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (displayText != null && select == 0)
        {
            displayText.text = "Armor: " + GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().armor;
        }

        if (displayText != null && select == 1)
        {
            displayText.text = "Power: " + GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().power;
        }

        if (displayText != null && select == 2)
        {
            displayText.text = "Speed: " + GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>().speed;
        }
    }
}
