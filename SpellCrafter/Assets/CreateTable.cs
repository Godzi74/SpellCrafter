using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateTable : MonoBehaviour
{
    public GameObject spellTable;
    public GameObject battleCanvas;
    public GameObject craftCanvas;
    void Start()
    {
    }

    
    void Update()
    {
        
    }

    //spawns table on button press
    public void SpawnTable()
    {
        spellTable.SetActive(true);
        craftCanvas.GetComponent<Canvas>().enabled = true;
        battleCanvas.GetComponent<Canvas>().enabled = false;
    }

    //removes table on button press
    public void removeTable()
    {
        spellTable.SetActive(false);
        battleCanvas.GetComponent<Canvas>().enabled = true;
        craftCanvas.GetComponent<Canvas>().enabled = false;
    }
}
