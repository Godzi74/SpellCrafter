using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Sprite Fire;
    public Sprite Water;
    public Sprite Ice;
    public Sprite Earth;
    public Sprite Thunder;
    public Sprite Attack;
    public Sprite AoE;
    public Sprite Blessing;
    public Spellcrafting getArrayData;
    void Start()
    {
        
    }

    void DisableImage()
    {
        //turns off craftUI if spell table is empty
        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "")
        {
            slot1.gameObject.SetActive(false);
        }
        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "")
        {
            slot2.gameObject.SetActive(false);
        }
        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "")
        {
            slot3.gameObject.SetActive(false);
        }
    }

    void SetImage()
    {
        //sets craft UI image based on what is currently in the table
        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "Fire")
        {
            slot1.gameObject.SetActive(true);
            slot1.sprite = Fire;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "Fire")
        {
            slot2.gameObject.SetActive(true);
            slot2.sprite = Fire;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "Fire")
        {
            slot3.gameObject.SetActive(true);
            slot3.sprite = Fire;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "Water")
        {
            slot1.gameObject.SetActive(true);
            slot1.sprite = Water;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "Water")
        {
            slot2.gameObject.SetActive(true);
            slot2.sprite = Water;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "Water")
        {
            slot3.gameObject.SetActive(true);
            slot3.sprite = Water;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "Ice")
        {
            slot1.gameObject.SetActive(true);
            slot1.sprite = Ice;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "Ice")
        {
            slot2.gameObject.SetActive(true);
            slot2.sprite = Ice;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "Ice")
        {
            slot3.gameObject.SetActive(true);
            slot3.sprite = Ice;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "Earth")
        {
            slot1.gameObject.SetActive(true);
            slot1.sprite = Earth;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "Earth")
        {
            slot2.gameObject.SetActive(true);
            slot2.sprite = Earth;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "Earth")
        {
            slot3.gameObject.SetActive(true);
            slot3.sprite = Earth;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "Thunder")
        {
            slot1.gameObject.SetActive(true);
            slot1.sprite = Thunder;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "Thunder")
        {
            slot2.gameObject.SetActive(true);
            slot2.sprite = Thunder;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "Thunder")
        {
            slot3.gameObject.SetActive(true);
            slot3.sprite = Thunder;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "Attack")
        {
            slot1.gameObject.SetActive(true);
            slot1.sprite = Attack;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "Attack")
        {
            slot2.gameObject.SetActive(true);
            slot2.sprite = Attack;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "Attack")
        {
            slot3.gameObject.SetActive(true);
            slot3.sprite = Attack;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "AoE")
        {
            slot1.gameObject.SetActive(true);
            slot1.sprite = AoE;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "AoE")
        {
            slot2.gameObject.SetActive(true);
            slot2.sprite = AoE;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "AoE")
        {
            slot3.gameObject.SetActive(true);
            slot3.sprite = AoE;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[0].ToString() == "Blessing")
        {
            slot1.gameObject.SetActive(true);
            slot1.sprite = Blessing;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[1].ToString() == "Blessing")
        {
            slot2.gameObject.SetActive(true);
            slot2.sprite = Blessing;
        }

        if (getArrayData.GetComponent<Spellcrafting>().items_in_box[2].ToString() == "Blessing")
        {
            slot3.gameObject.SetActive(true);
            slot3.sprite = Blessing;
        }
    }
    // Update is called once per frame
    void Update()
    {
        DisableImage();
        SetImage();
    }
}
