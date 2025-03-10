using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spellcrafting : MonoBehaviour
{
    private string material1;
    private string material2;
    private string material3;
    public Canvas getCraftUI;
    public Canvas getBattleUI;
    public Button turnOffCraftButton;
    private int fireCounter = 0;
    private int waterCounter = 0;
    private int iceCounter = 0;
    private int earthCounter = 0;
    private int thunderCounter = 0;
    private int attackCounter = 0;
    private int aoeCounter = 0;
    private int blessingCounter = 0;
    public float baseDmg;
    public string element1;
    public string element2;
    public string elementalShield1;
    public string elementalShield2;
    public string shieldUses;
    public string spellType;
    public Transform spellSpawnLocation;
    public ArrayList items_in_box = new ArrayList();
    public ArrayList emptyArrayList = new ArrayList();
    public ArrayList items_casted_to_string = new ArrayList();
    public GameObject basicFireSpell;
    public GameObject getPlayerStats;
    void Update()
    {
     
    }

    //delcares an empty string list of three objects
    private void Awake()
    {
        items_in_box.Add("");
        items_in_box.Add("");
        items_in_box.Add("");
    }

    public void EmptyMyLists()
    {
        //clears current materials in the array list
        items_in_box[0] = "";
        items_in_box[1] = "";
        items_in_box[2] = "";
        fireCounter = 0;
        waterCounter = 0;
        iceCounter = 0;
        earthCounter = 0;
        thunderCounter = 0;
        attackCounter = 0;
        aoeCounter = 0;
        blessingCounter = 0;
        print(items_in_box[0]);
    }

    void OnCollisionEnter(Collision collision)
    {
        //adds material type to array list
        if (collision.gameObject.tag == "Material" && items_in_box[0] == "")
        {
            items_in_box[0] = Variables.Object(collision.gameObject).Get("material_type").ToString(); 
            Destroy(collision.gameObject);
            print(items_in_box[0]);
        }   
        
        else if (collision.gameObject.tag == "Material" && items_in_box[1] == "")
        {
            items_in_box[1] = Variables.Object(collision.gameObject).Get("material_type").ToString(); 
            Destroy(collision.gameObject);
            print(items_in_box[1]);
        }   
        
        else if (collision.gameObject.tag == "Material" && items_in_box[2] == "")
        {
            items_in_box[2] = Variables.Object(collision.gameObject).Get("material_type").ToString(); 
            Destroy(collision.gameObject);
            print(items_in_box[2]);
            CountMaterials();

        }

        else if (collision.gameObject.tag == "Material")
        {
            Destroy(collision.gameObject);
        }

    }

    public void CountMaterials()
    {
        for (int i = 0; i < items_in_box.Count; i++)
        {
            //counts how many of each material is currently in the spell table
            if (items_in_box[i].ToString() == "Fire")
            {
                fireCounter = fireCounter + 1;
                //print(fireCounter);
            }

            if (items_in_box[i].ToString() == "Water")
            {
                waterCounter = waterCounter + 1;
                //print(fireCounter);
            }

            if (items_in_box[i].ToString() == "Ice")
            {
                iceCounter = iceCounter + 1;
                //print(fireCounter);
            }

            if (items_in_box[i].ToString() == "Earth")
            {
                earthCounter = earthCounter + 1;
                //print(fireCounter);
            }

            if (items_in_box[i].ToString() == "Thunder")
            {
                thunderCounter = thunderCounter + 1;
                //print(fireCounter);
            }

            if (items_in_box[i].ToString() == "Attack")
            {
                attackCounter = attackCounter + 1;
                //print(fireCounter);
            }

            if (items_in_box[i].ToString() == "AoE")
            {
                aoeCounter = aoeCounter + 1;
                //print(fireCounter);
            }

            if (items_in_box[i].ToString() == "Blessing")
            {
                blessingCounter = blessingCounter + 1;
                //print(fireCounter);
            }
        }

        //creates the spell based on how many times each material was entered into the table
        if (fireCounter == 2 && attackCounter == 1)
        {
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Fire Spell!";
            print("Created a Concentrated Fire Spell!");
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 360f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "water";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 2 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Fire Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Fire Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 180f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "water";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }   

        if (fireCounter == 2 && blessingCounter == 1)
        {
            print("Created a Fire Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Fire Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "water";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && waterCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Raging Water Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Raging Water Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "thunder";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && waterCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Raging Water Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Raging Water Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "thunder";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && waterCounter == 1 && blessingCounter == 1)
        {
            print("Created a Raging Water Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Raging Water Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "thunder";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && iceCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Frostflame Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Frostflame Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && iceCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Frostflame Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Frostflame Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && iceCounter == 1 && blessingCounter == 1)
        {
            print("Created a FrostFlame Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a FrostFlame Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 9;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && earthCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Tectonic Blaze Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Tectonic Blaze Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && earthCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Tectonic Blaze Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Tectonic Blaze Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && earthCounter == 1 && blessingCounter == 1)
        {
            print("Created a Tectonic Blaze Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Tectonic Blaze Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && thunderCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Thundering Heat Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Thundering Heat Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && thunderCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Thundering Heat Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Thundering Heat Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (fireCounter == 1 && thunderCounter == 1 && blessingCounter == 1)
        {
            print("Created a Thundering Heat Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Thundering Heat Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 2 && attackCounter == 1)
        {
            print("Created a Concentrated Water Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Water Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 360f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "thunder";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 2 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Water Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Water Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 180f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "thunder";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 2 && blessingCounter == 1)
        {
            print("Created a Water Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Water Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "thunder";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && iceCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Glacial Torrent Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Glacial Torrent Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && iceCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Glacial Torrent Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Glacial Torrent Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && iceCounter == 1 && blessingCounter == 1)
        {
            print("Created a Glacial Torrent Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Glacial Torrent Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 9;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && earthCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Crushing Tides Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Crushing Tides Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && earthCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Crushing Tides Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Crushing Tides Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && earthCounter == 1 && blessingCounter == 1)
        {
            print("Created a Crushing Tides Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Crushing Tides Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && thunderCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Flowing Current Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Flowing Current Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && thunderCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Flowing Current Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Flowing Current Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (waterCounter == 1 && thunderCounter == 1 && blessingCounter == 1)
        {
            print("Created a Flowing Current Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Flowing Current Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 2 && attackCounter == 1)
        {
            print("Created a Concentrated Ice Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Ice Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 360f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 2 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Ice Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Ice Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 180f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 2 && blessingCounter == 1)
        {
            print("Created an Ice Blessing Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created an Ice Blessing Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 12f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "fire";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 1 && earthCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Ice Age Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Ice Age Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 1 && earthCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Ice Age Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Ice Age Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 1 && earthCounter == 1 && blessingCounter == 1)
        {
            print("Created an Ice Age Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created an Ice Age Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 9f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 1 && thunderCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Flash Freeze Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Flash Freeze Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 1 && thunderCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Flash Freeze Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Flash Freeze Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (iceCounter == 1 && thunderCounter == 1 && blessingCounter == 1)
        {
            print("Created a Flash Freeze Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Flash Freeze Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 9f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "fire";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (earthCounter == 2 && attackCounter == 1)
        {
            print("Created a Concentrated Earth Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Earth Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 360f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (earthCounter == 2 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Earth Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Earth Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 180f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (earthCounter == 2 && blessingCounter == 1)
        {
            print("Created an Earth Blessing Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created an Earth Blessing Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "ice";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (earthCounter == 1 && thunderCounter == 1 && attackCounter == 1)
        {
            print("Created a Concentrated Voltaic Eruption Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Voltaic Eruption Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 300f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (earthCounter == 1 && thunderCounter == 1 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Voltaic Eruption Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Voltaic Eruption Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 150f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (earthCounter == 1 && thunderCounter == 1 && blessingCounter == 1)
        {
            print("Created a Voltaic Eruption Blessing Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Voltaic Eruption Blessing Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "ice";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (thunderCounter == 2 && attackCounter == 1)
        {
            print("Created a Concentrated Thunder Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Concentrated Thunder Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 360f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "ST";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (thunderCounter == 2 && aoeCounter == 1)
        {
            print("Created a Wide-Spread Thunder Spell!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Wide-Spread Thunder Spell!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().element2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 180f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "AOE";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().strength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().weakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }

        if (thunderCounter == 2 && blessingCounter == 1)
        {
            print("Created a Thunder Blessing!");
            Instantiate(basicFireSpell);
            basicFireSpell.transform.position = spellSpawnLocation.position;
            EmptyMyLists();
            getPlayerStats.GetComponent<BattleSystem>().dialogue.text = "Created a Thunder Blessing!";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shieldUses = 7f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield1 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().elementalShield2 = "thunder";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().baseDmg = 0f;
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().spellType = "Bless";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength1 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shStrength2 = "water";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness1 = "earth";
            getPlayerStats.GetComponent<BattleSystem>().playerGO.GetComponent<Unit>().shWeakness2 = "earth";
            getBattleUI.enabled = true;
            getCraftUI.enabled = false;
            turnOffCraftButton.interactable = false;
            this.gameObject.SetActive(false);
        }
    }

}
