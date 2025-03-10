using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellShieldUI : MonoBehaviour
{
    public Text shieldValue;
    public Image ele1;
    public Image ele2;
    public Sprite Fire;
    public Sprite Water;
    public Sprite Ice;
    public Sprite Earth;
    public Sprite Thunder;
    public Unit playerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //sets shield image to display current shield element
    public void SetImage()
    {
        if (playerStats.elementalShield1 == "none")
        {
            ele1.gameObject.SetActive(false);
        }

        if (playerStats.elementalShield2 == "none")
        {
            ele2.gameObject.SetActive(false);
        }

        if (playerStats.elementalShield1 == "fire")
        {
            ele1.gameObject.SetActive(true);
            ele1.sprite = Fire;
        }

        if (playerStats.elementalShield1 == "water")
        {
            ele1.gameObject.SetActive(true);
            ele1.sprite = Water;
        }

        if (playerStats.elementalShield1 == "ice")
        {
            ele1.gameObject.SetActive(true);
            ele1.sprite = Ice;
        }

        if (playerStats.elementalShield1 == "thunder")
        {
            ele1.gameObject.SetActive(true);
            ele1.sprite = Thunder;
        }

        if (playerStats.elementalShield1 == "earth")
        {
            ele1.gameObject.SetActive(true);
            ele1.sprite = Earth;
        }

        if (playerStats.elementalShield2 == "fire")
        {
            ele2.gameObject.SetActive(true);
            ele2.sprite = Fire;
        }

        if (playerStats.elementalShield2 == "water")
        {
            ele2.gameObject.SetActive(true);
            ele2.sprite = Water;
        }

        if (playerStats.elementalShield2 == "ice")
        {
            ele2.gameObject.SetActive(true);
            ele2.sprite = Ice;
        }

        if (playerStats.elementalShield2 == "thunder")
        {
            ele2.gameObject.SetActive(true);
            ele2.sprite = Thunder;
        }

        if (playerStats.elementalShield2 == "earth")
        {
            ele2.gameObject.SetActive(true);
            ele2.sprite = Earth;
        }
    }

    //sets the text to display remainig shield uses.
    public void SetShieldValue()
    {
        if (playerStats.shieldUses > 0)
        {
            shieldValue.text = "Shield remaining: " + playerStats.shieldUses;
        }

        if (playerStats.shieldUses <= 0)
        {
            shieldValue.text = "You have no shield";
        }
    }
    // Update is called once per frame
    void Update()
    {
        SetImage();
        SetShieldValue();
    }
}
