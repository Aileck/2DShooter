using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainEnermy : MonoBehaviour
{
    // Start is called before the first frame update
    public Text displayText = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (displayText != null) {
            displayText.text = "Enermies to defeat: " + (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().enemiesToDefeat - GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().enemiesDefeated);
        }   
    }
}
