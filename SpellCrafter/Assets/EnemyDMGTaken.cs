using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMGTaken : MonoBehaviour
{

    public float dmgTakenMultiplier;
    public float dmgDealtMultiplier;
    public Unit getEnemyUnit;
    public bool isStrong;
    public bool isVeryStrong = false;
    public bool isWeak;
    public bool isVeryWeak = false;

    public bool enemyIsStrong;
    public bool enemyIsVeryStrong = false;
    public bool enemyIsWeak;
    public bool enemyIsVeryWeak = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //calculates whether the enemy is strong or weak against the player's typings.
    public void CheckWeaknesses()
    {
        GameObject getPlayerGO = GameObject.Find("Player GameObject");
        if (getPlayerGO.GetComponent<Unit>().strength1 == getEnemyUnit.GetComponent<Unit>().element1 || getPlayerGO.GetComponent<Unit>().strength2 == getEnemyUnit.GetComponent<Unit>().element1)
        {
            isStrong = true;
        }

        if (getPlayerGO.GetComponent<Unit>().weakness1 == getEnemyUnit.GetComponent<Unit>().element1 || getPlayerGO.GetComponent<Unit>().weakness2 == getEnemyUnit.GetComponent<Unit>().element1)
        {
            isWeak = true;
        }

        if (getPlayerGO.GetComponent<Unit>().strength1 != getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().strength2 != getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().weakness1 != getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().weakness2 != getEnemyUnit.GetComponent<Unit>().element1)
        {
            //dmgTakenmultiplier = 1f;
            isStrong = false;
            isWeak = false;
            isVeryStrong = false;
            isVeryWeak = false;
        }

        if (getPlayerGO.GetComponent<Unit>().strength1 == getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().strength2 == getEnemyUnit.GetComponent<Unit>().element1)
        {
            isVeryStrong = true;
            isVeryWeak = false;
            isWeak = false;
        }

        if (getPlayerGO.GetComponent<Unit>().weakness1 == getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().weakness2 == getEnemyUnit.GetComponent<Unit>().element1)
        {
            isVeryStrong = false;
            isVeryWeak = true;
            isStrong = false;
        }

        if (isStrong == true && isWeak == true)
        {
            dmgTakenMultiplier = 1f;
        }

        if (isStrong == false && isWeak == false && isVeryStrong == false && isVeryWeak == false)
        {
            dmgTakenMultiplier = 1f;
        }

        if (isStrong == true && isWeak == false && isVeryStrong == false)
        {
            dmgTakenMultiplier = 1.15f;
        }

        if (isStrong == true && isWeak == false && isVeryStrong == true)
        {
            dmgTakenMultiplier = 1.35f;
        }

        if (isWeak == true && isStrong == false && isVeryWeak == false)
        {
            dmgTakenMultiplier = 0.75f;
        }

        if (isWeak == true && isStrong == false && isVeryWeak == true)
        {
            dmgTakenMultiplier = 0.5f;
        }
    }

    public void CheckPlayerWeakness()
    {
        GameObject getPlayerGO = GameObject.Find("Player GameObject");
        if (getPlayerGO.GetComponent<Unit>().shStrength1 == getEnemyUnit.GetComponent<Unit>().element1 || getPlayerGO.GetComponent<Unit>().shStrength2 == getEnemyUnit.GetComponent<Unit>().element1)
        {
            enemyIsWeak = true;
        }

        if (getPlayerGO.GetComponent<Unit>().shWeakness1 == getEnemyUnit.GetComponent<Unit>().element1 || getPlayerGO.GetComponent<Unit>().shWeakness2 == getEnemyUnit.GetComponent<Unit>().element1)
        {
            enemyIsStrong = true;
        }

        if (getPlayerGO.GetComponent<Unit>().shStrength1 != getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().shStrength2 != getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().shWeakness1 != getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().shWeakness2 != getEnemyUnit.GetComponent<Unit>().element1)
        {
            enemyIsStrong = false;
            enemyIsWeak = false;
            enemyIsVeryStrong = false;
            enemyIsVeryWeak = false;
        }

        if (getPlayerGO.GetComponent<Unit>().shStrength1 == getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().shStrength2 == getEnemyUnit.GetComponent<Unit>().element1)
        {
            enemyIsVeryWeak = true;
            enemyIsVeryStrong = false;
            enemyIsStrong = false;

        }

        if (getPlayerGO.GetComponent<Unit>().shWeakness1 == getEnemyUnit.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().shWeakness2 == getEnemyUnit.GetComponent<Unit>().element1)
        {
            enemyIsVeryStrong = true;
            enemyIsVeryWeak = false;
            enemyIsWeak = false;
        }

        if (getPlayerGO.GetComponent<Unit>().shWeakness1 == "none" && getPlayerGO.GetComponent<Unit>().shWeakness2 == "none")
        {
            enemyIsVeryStrong = false;
            enemyIsStrong = false;
            enemyIsVeryWeak = false;
            enemyIsWeak = false;
            dmgDealtMultiplier = 2f;
        }

        if (getPlayerGO.GetComponent<Unit>().elementalShield1 == this.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().elementalShield2 == this.GetComponent<Unit>().element1)
        {
            enemyIsVeryStrong = false;
            enemyIsStrong = false;
            enemyIsVeryWeak = false;
            enemyIsWeak = false;
            dmgDealtMultiplier = 1f;
        }

        if (enemyIsStrong == true && enemyIsWeak == true)
        {
            dmgDealtMultiplier = 1f;
        }

        if (enemyIsStrong == false && enemyIsWeak == false && enemyIsVeryStrong == false && enemyIsVeryWeak == false && getPlayerGO.GetComponent<Unit>().shWeakness1 != this.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().shWeakness2 != this.GetComponent<Unit>().element1 && getPlayerGO.GetComponent<Unit>().shWeakness1 != "none" && getPlayerGO.GetComponent<Unit>().shWeakness2 != "none")
        {
            dmgDealtMultiplier = 1f;
        }

        if (enemyIsStrong == true && enemyIsWeak == false && enemyIsVeryStrong == false)
        {
            dmgDealtMultiplier = 1.25f;
        }

        if (enemyIsStrong == true && isWeak == false && enemyIsVeryStrong == true)
        {
            dmgDealtMultiplier = 1.5f;
        }

        if (enemyIsWeak == true && enemyIsStrong == false && enemyIsVeryWeak == false)
        {
            dmgDealtMultiplier = 0.75f;
        }

        if (enemyIsWeak == true && enemyIsStrong == false && enemyIsVeryWeak == true)
        {
            dmgDealtMultiplier = 0.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckWeaknesses();
        CheckPlayerWeakness();
    }
}
