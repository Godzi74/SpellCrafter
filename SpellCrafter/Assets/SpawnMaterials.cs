using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaterials : MonoBehaviour
{
    public Transform materialSpawnLocation;
    public GameObject Fire;
    public GameObject Water;
    public GameObject Ice;
    public GameObject Earth;
    public GameObject Thunder;
    public GameObject Attack;
    public GameObject AoE;
    public GameObject Blessing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //spawns the spcified material based on the button pressed in the UI
    public void spawnFire()
    {
        Instantiate(Fire, materialSpawnLocation.transform);
        Fire.transform.localPosition = materialSpawnLocation.transform.localPosition;
    }

    public void spawnWater()
    {
        Instantiate(Water, materialSpawnLocation.transform);
        Water.transform.localPosition = materialSpawnLocation.transform.localPosition;
    }
    public void spawnIce()
    {
        Instantiate(Ice, materialSpawnLocation.transform);
        Ice.transform.localPosition = materialSpawnLocation.transform.localPosition;
    }

    public void spawnEarth()
    {
        Instantiate(Earth, materialSpawnLocation.transform);
        Earth.transform.localPosition = materialSpawnLocation.transform.localPosition;
    }

    public void spawnThunder()
    {
        Instantiate(Thunder, materialSpawnLocation.transform);
        Thunder.transform.localPosition = materialSpawnLocation.transform.localPosition;
    }
    public void spawnAttack()
    {
        Instantiate(Attack, materialSpawnLocation.transform);
        Attack.transform.localPosition = materialSpawnLocation.transform.localPosition;
    }

    public void spawnAoE()
    {
        Instantiate(AoE, materialSpawnLocation.transform);
        AoE.transform.localPosition = materialSpawnLocation.transform.localPosition;
    }

    public void spawnBlessing()
    {
        Instantiate(Blessing, materialSpawnLocation.transform);
        Blessing.transform.localPosition = materialSpawnLocation.transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
