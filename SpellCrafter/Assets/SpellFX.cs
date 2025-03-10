using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFX : MonoBehaviour
{
    public GameObject fireFX;
    public GameObject waterFX;
    public GameObject iceFX;
    public GameObject thunderFX;
    public GameObject earthFX;
    public float fireCD;
    public float waterCD;
    public float iceCD;
    public float thunderCD;
    public float earthCD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //gets the player's elements when called
    public void GetElements(string element1, string element2)
    {
        if (element1 == "fire" || element2 == "fire")
        {
            fireCD = 3f;
        }

        if (element1 == "water" || element2 == "water")
        {
            waterCD = 3f;
        }

        if (element1 == "ice" || element2 == "ice")
        {
            iceCD = 3f;
        }

        if (element1 == "thunder" || element2 == "thunder")
        {
            thunderCD = 3f;
        }

        if (element1 == "earth" || element2 == "earth")
        {
            earthCD = 3f;
        }
    }

    //turns the specified effect either on or off.
    public void ToggleFX()
    {
        if (fireCD > 0)
        {
            fireFX.SetActive(true);
        }

        if (waterCD > 0)
        {
            waterFX.SetActive(true);
        }

        if (iceCD > 0)
        {
            iceFX.SetActive(true);
        }

        if (thunderCD > 0)
        {
            thunderFX.SetActive(true);
        }

        if(earthCD > 0)
        {
            earthFX.SetActive(true);
        }

        if (fireCD <= 0)
        {
            fireFX.SetActive(false);
        }

        if (waterCD <= 0)
        {
            waterFX.SetActive(false);
        }

        if (iceCD <= 0)
        {
            iceFX.SetActive(false);
        }

        if (thunderCD <= 0)
        {
            thunderFX.SetActive(false);
        }

        if (earthCD <= 0)
        {
            earthFX.SetActive(false);
        }
    }

    //counts duration of spell effects
    public void CountdownFX()
    {
        if (fireCD > 0)
        {
            fireCD -= Time.deltaTime;
        }

        if (waterCD > 0)
        {
            waterCD -= Time.deltaTime;
        }

        if (iceCD > 0)
        {
            iceCD -= Time.deltaTime;
        }

        if (thunderCD > 0)
        {
            thunderCD -= Time.deltaTime;
        }

        if(earthCD > 0)
        {
            earthCD -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ToggleFX();
        CountdownFX();
    }
}
