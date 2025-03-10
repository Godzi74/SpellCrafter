using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class basicSpellShot : MonoBehaviour
{
    public GameObject testSpell;
    public Transform spawnPoint;
    public GameObject actualSpell;
    public float projectileSpeed = 20;
    public GameObject getbattlestate;
    public bool hoveringEnemy = false;
    public GameObject retrieveTarget;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(LaunchSpell);
        getbattlestate = GameObject.Find("Battle System");
    }


    public void CheckForEnemyOverlap()
    {
        
        //creates a raycast that checks if the spell is aimed at an enemy
        Ray ray = new Ray (spawnPoint.position, spawnPoint.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            Debug.DrawLine(spawnPoint.position, hitInfo.point, Color.red);
            if (hitInfo.collider.gameObject.tag == "Enemy")
            {
                hoveringEnemy = true;
                retrieveTarget = hitInfo.collider.gameObject;
                print("Yipee!");
            }

            if (hitInfo.collider.gameObject.tag != "Enemy")
            {
                hoveringEnemy = false;
                retrieveTarget = null;
 
            }
            
        }
        
        
    }

    public void LaunchSpell(ActivateEventArgs arg)
    {
        //allows the user to cast the spell if aimed at the enemy
        if (hoveringEnemy == true)
        {
            StartCoroutine(getbattlestate.GetComponent<BattleSystem>().PlayerAction(retrieveTarget));
            GameObject spawnedSpell = Instantiate(testSpell);
            spawnedSpell.transform.position = spawnPoint.position;
            spawnedSpell.GetComponent<Rigidbody>().velocity = spawnPoint.forward * projectileSpeed;
            Destroy(actualSpell);
            Destroy(spawnedSpell, 1);
        }
    }

    void Update()
    {
        CheckForEnemyOverlap();
    }
}
