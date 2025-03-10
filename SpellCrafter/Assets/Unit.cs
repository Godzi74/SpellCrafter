using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string name;
    public float baseDmg;
    public float curHP;
    public float maxHP;
    public string element1;
    public string element2;
    public string elementalShield1;
    public string elementalShield2;
    public string strength1;
    public string strength2;
    public string weakness1;
    public string weakness2;
    public string shStrength1;
    public string shStrength2;
    public string shWeakness1;
    public string shWeakness2;
    public float shieldUses;
    public string spellType;
    public bool isDead = false;
    public GameObject battleSystem;

    private void Start()
    {
        //looks for battle system
        battleSystem = GameObject.Find("Battle System");
    }
    public void CheckIsDead()
    {
        //destroys the enemy upon death and adds it to the kill counter
        if (curHP <= 0 && this.tag == "Enemy")
        {
            battleSystem.GetComponent<BattleSystem>().killCount += 1f;
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        //sets health to never go above max health
        CheckIsDead();

        if (curHP > maxHP)
        {
            curHP = maxHP;
        }

        if (curHP <= 0)
        {
            isDead = true;
        }
    }
}


