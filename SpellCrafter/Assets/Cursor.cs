using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public GameObject getEnemyHover;
    public bool hoveringenemy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //hoveringenemy = true;
            getEnemyHover = other.gameObject;
            print(other.gameObject);
        }

        if (other.gameObject.tag != "Enemy")
        {
           // hoveringenemy = false;
        }

        print(hoveringenemy);
    }

    
}
