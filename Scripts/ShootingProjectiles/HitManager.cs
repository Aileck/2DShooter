using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thisHit;

    public GameObject enermyUI;
    public Text hpText;
    public Image enermyImage;
    public Slider enermyHPBar;

    public bool unkown;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (thisHit != null)
        {
            enermyUI.SetActive(true);
            enermyImage.sprite = this.thisHit.GetComponent<SpriteRenderer>().sprite;

            enermyHPBar.maxValue = this.thisHit.GetComponent<Health>().maximumHealth;
            enermyHPBar.minValue = 0;
            enermyHPBar.value = this.thisHit.GetComponent<Health>().currentHealth;

            string currentHP = "????";
            if (!unkown)
                currentHP = this.thisHit.GetComponent<Health>().currentHealth + "/" + this.thisHit.GetComponent<Health>().maximumHealth;
            hpText.text = currentHP;
        }
        else {
            enermyUI.SetActive(false);
        }
    }
}
