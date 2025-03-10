using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public LayerMask whatIsEnemy;
    public GameObject playerGO;
    public GameObject enemyGO1;
    public GameObject enemyGO2;
    public GameObject enemyGO3;
    public float killCount = 0f;
    public int wave = 1;

    public GameObject[] enemiesOnField;

    public Transform enemyBattleStation1;
    public Transform enemyBattleStation2;
    public Transform enemyBattleStation3;

    public Transform playerBattleStation;
    public SpellFX spellEffect;

    public Text dialogue;
    public float totalDamage;


    public WaveSystem getWave;

    public Canvas getBattleUI;
    public Canvas CraftCanvas;
    public Button turnOnCraftButton;
    public GameObject getTable;

    Unit playerUnit;

    Unit enemyUnit1;
    Unit enemyUnit2;
    Unit enemyUnit3;

    public GameObject menuScreen;
    public GameObject helpScreen1;
    public GameObject helpScreen2;
    public GameObject helpScreen3;
    public GameObject defeatScreen;
    public GameObject victoryScreen;
 
    //generates the game
    public void StartGame()
    {
        state = BattleState.START;
        StartCoroutine(GenerateBattle());
        menuScreen.SetActive(false);
    }

    public IEnumerator GenerateBattle()
    {
        //spawns enemies depending on the wave
        if (wave == 1)
        {
            enemiesOnField[0] = getWave.Wave1[0];
            enemyGO1 = Instantiate(enemiesOnField[0]);
            enemyGO1.transform.position = enemyBattleStation1.transform.position;
            


            enemiesOnField[1] = getWave.Wave1[1];
            enemyGO2 = Instantiate(enemiesOnField[1]);
            enemyGO2.transform.position = enemyBattleStation2.transform.position;
            

            enemiesOnField[2] = getWave.Wave1[2];
            enemyGO3 = Instantiate(enemiesOnField[0]);
            enemyGO3.transform.position = enemyBattleStation3.transform.position;
            
        }

        if (wave == 2)
        {
            enemiesOnField[0] = getWave.Wave2[0];
            enemyGO1 = Instantiate(enemiesOnField[0]);
            enemyGO1.transform.position = enemyBattleStation1.transform.position;
            


            enemiesOnField[1] = getWave.Wave2[1];
            enemyGO2 = Instantiate(enemiesOnField[1]);
            enemyGO2.transform.position = enemyBattleStation2.transform.position;
            

            enemiesOnField[2] = getWave.Wave2[2];
            enemyGO3 = Instantiate(enemiesOnField[0]);
            enemyGO3.transform.position = enemyBattleStation3.transform.position;
            
        }

        if (wave == 3)
        {
            enemiesOnField[0] = getWave.Wave3[0];
            enemyGO1 = Instantiate(enemiesOnField[0]);
            enemyGO1.transform.position = enemyBattleStation1.transform.position;
            


            enemiesOnField[1] = getWave.Wave3[1];
            enemyGO2 = Instantiate(enemiesOnField[1]);
            enemyGO2.transform.position = enemyBattleStation2.transform.position;
            

            enemiesOnField[2] = getWave.Wave3[2];
            enemyGO3 = Instantiate(enemiesOnField[0]);
            enemyGO3.transform.position = enemyBattleStation3.transform.position;
            
        }

        //ensures player health is set before enabling the player's turn
        playerGO.GetComponent<Unit>().curHP = playerGO.GetComponent<Unit>().maxHP;
        dialogue.text = "Wave " + wave + ": BEGIN!";

        yield return new WaitForSeconds (2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogue.text = "Craft a spell!";

        //heals player if they have a water shield
        if (playerGO.GetComponent<Unit>().elementalShield1 == "water")
        {
            playerGO.GetComponent<Unit>().curHP += playerGO.GetComponent<Unit>().maxHP * 0.125f;
        }

        if (playerGO.GetComponent<Unit>().elementalShield2 == "water")
        {
            playerGO.GetComponent<Unit>().curHP += playerGO.GetComponent<Unit>().maxHP * 0.125f;
        }

    }

    //gets the enemy that the player targeted and performs spell action based on what the spell is, then returns the battle outcome to the player
    public IEnumerator PlayerAction(GameObject target)
    {
        if (playerGO.GetComponent<Unit>().spellType == "ST")
        {
            if (playerGO.GetComponent<Unit>().elementalShield1 == "fire" || playerGO.GetComponent<Unit>().elementalShield2 == "fire")
            {
                target.GetComponent<Unit>().curHP -= (playerGO.GetComponent<Unit>().baseDmg * target.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier) * 1.1f ;
                dialogue.text = "You did " + ((playerGO.GetComponent<Unit>().baseDmg * target.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier) * 1.1f).ToString() + " damage to " + target.GetComponent<Unit>().name + "!";
            }

            else if (playerGO.GetComponent<Unit>().elementalShield1 == "fire" && playerGO.GetComponent<Unit>().elementalShield2 == "fire")
            {
                target.GetComponent<Unit>().curHP -= (playerGO.GetComponent<Unit>().baseDmg * target.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier) * 1.2f;
                dialogue.text = "You did " + ((playerGO.GetComponent<Unit>().baseDmg * target.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier) * 1.2f).ToString() + " damage to " + target.GetComponent<Unit>().name + "!";
            }

            else
            {
                target.GetComponent<Unit>().curHP -= (playerGO.GetComponent<Unit>().baseDmg * target.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier);
                dialogue.text = "You did " + ((playerGO.GetComponent<Unit>().baseDmg * target.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier)).ToString() + " damage to " + target.GetComponent<Unit>().name + "!";
            }

            spellEffect.GetElements(playerGO.GetComponent<Unit>().element1.ToString(), playerGO.GetComponent<Unit>().element2.ToString());
            //calls the enemy turn to begin
            StartCoroutine(EnemyAction());
            yield return new WaitForSeconds(3f);
        }

        if (playerGO.GetComponent<Unit>().spellType == "AOE")
        {
            StartCoroutine(AoEDamage());
        }

        if (playerGO.GetComponent<Unit>().spellType == "Bless")
        {
            dialogue.text = "You used a blessing!";
            StartCoroutine(EnemyAction());
        }

    }

    public void CheckPlayerShield()
    {
        //disables player elements if they have no shields
        if (playerGO.GetComponent<Unit>().shieldUses <= 0)
        {
            playerGO.GetComponent<Unit>().elementalShield1 = "none";
            playerGO.GetComponent<Unit>().elementalShield2 = "none";
            playerGO.GetComponent<Unit>().shStrength1 = "none";
            playerGO.GetComponent<Unit>().shStrength1 = "none";
            playerGO.GetComponent<Unit>().shWeakness1 = "none";
            playerGO.GetComponent<Unit>().shWeakness2 = "none";
        }
    }
    public IEnumerator EnemyAction()
    {
        //begins enemy turn
        yield return new WaitForSeconds(2f);
        
        StartCoroutine(EnemyDMG());
        getBattleUI.enabled = true;
        
    }

    public IEnumerator AoEDamage()
    {
        //calculates the total damage dealt by the wide spread/AoE tome
        Collider[] enemiesToAOE = Physics.OverlapBox(this.gameObject.transform.position, transform.localScale / 2, Quaternion.identity, whatIsEnemy);
        for (int i = 0; i < enemiesToAOE.Length; i++)
        {
            if (enemiesToAOE[i].gameObject.GetComponent<Unit>().isDead == false)
            {
                if(playerGO.GetComponent<Unit>().elementalShield1 == "thunder" || playerGO.GetComponent<Unit>().elementalShield1 == "thunder")
                {
                    enemiesToAOE[i].gameObject.GetComponent<Unit>().curHP -= (playerGO.GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier) * 1.1f ;
                    totalDamage += (playerGO.GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier) * 1.1f;
                }

                else if (playerGO.GetComponent<Unit>().elementalShield1 == "thunder" && playerGO.GetComponent<Unit>().elementalShield1 == "thunder")
                {
                    enemiesToAOE[i].gameObject.GetComponent<Unit>().curHP -= (playerGO.GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier) * 1.2f;
                    totalDamage += (playerGO.GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier) * 1.2f;
                }

                else
                {
                    enemiesToAOE[i].gameObject.GetComponent<Unit>().curHP -= playerGO.GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier;
                    totalDamage += playerGO.GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgTakenMultiplier;
                }
            }
        }
        spellEffect.GetElements(playerGO.GetComponent<Unit>().element1, playerGO.GetComponent<Unit>().element2);
        dialogue.text = "You did a total of " + totalDamage + " damage!";
        yield return new WaitForSeconds(2.5f);
        totalDamage = 0f;
        StartCoroutine(EnemyAction());
    }

    public IEnumerator EnemyDMG()
    {
        //calculates enemy damage dealt to player
        Collider[] enemiesToAOE = Physics.OverlapBox(this.gameObject.transform.position, transform.localScale / 2, Quaternion.identity, whatIsEnemy);
        for (int i = 0; i < enemiesToAOE.Length; i++)
        {
            if (enemiesToAOE[i].gameObject.GetComponent<Unit>().isDead == false)
            {
                if (enemiesToAOE[i].gameObject.GetComponent<Unit>().name == "Hexer")
                {
                    //checks the amount of resistance the player has before calculating damage taken
                    if (playerGO.GetComponent<Unit>().elementalShield1 == "earth" || playerGO.GetComponent<Unit>().elementalShield2 == "earth")
                    {
                        playerGO.GetComponent<Unit>().curHP -= (enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier) * 0.9f;
                        playerGO.GetComponent<Unit>().shieldUses -= 2;
                        dialogue.text = enemiesToAOE[i].GetComponent<Unit>().name + " did " + (enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier) * 0.9f + " damage!";
                        yield return new WaitForSeconds(3f);
                    }

                    else if (playerGO.GetComponent<Unit>().elementalShield1 == "earth" && playerGO.GetComponent<Unit>().elementalShield2 == "earth")
                    {
                        playerGO.GetComponent<Unit>().curHP -= (enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier) * 0.8f;
                        playerGO.GetComponent<Unit>().shieldUses -= 2;
                        dialogue.text = enemiesToAOE[i].GetComponent<Unit>().name + " did " + (enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier) * 0.8f + " damage!";
                        yield return new WaitForSeconds(3f);
                    }

                    else
                    {
                        playerGO.GetComponent<Unit>().curHP -= enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier;
                        playerGO.GetComponent<Unit>().shieldUses -= 2;
                        dialogue.text = enemiesToAOE[i].GetComponent<Unit>().name + " did " + enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier + " damage!";
                        yield return new WaitForSeconds(3f);
                    }
                }

                if (enemiesToAOE[i].gameObject.GetComponent<Unit>().name != "Hexer")
                {
                    //checks the amount of resistance the player has before calculating damage taken
                    if (playerGO.GetComponent<Unit>().elementalShield1 == "earth" || playerGO.GetComponent<Unit>().elementalShield2 == "earth")
                    {
                        playerGO.GetComponent<Unit>().curHP -= (enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier) * 0.9f;
                        playerGO.GetComponent<Unit>().shieldUses -= 1;
                        dialogue.text = enemiesToAOE[i].GetComponent<Unit>().name + " did " + (enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier) * 0.9f + " damage!";
                        yield return new WaitForSeconds(3f);
                    }

                    else if (playerGO.GetComponent<Unit>().elementalShield1 == "earth" && playerGO.GetComponent<Unit>().elementalShield2 == "earth")
                    {
                        playerGO.GetComponent<Unit>().curHP -= (enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier) * 0.8f;
                        playerGO.GetComponent<Unit>().shieldUses -= 1;
                        dialogue.text = enemiesToAOE[i].GetComponent<Unit>().name + " did " + (enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier) * 0.8f + " damage!";
                        yield return new WaitForSeconds(3f);
                    }

                    else
                    {
                        playerGO.GetComponent<Unit>().curHP -= enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier;
                        playerGO.GetComponent<Unit>().shieldUses -= 1;
                        dialogue.text = enemiesToAOE[i].GetComponent<Unit>().name + " did " + enemiesToAOE[i].GetComponent<Unit>().baseDmg * enemiesToAOE[i].gameObject.GetComponent<EnemyDMGTaken>().dmgDealtMultiplier + " damage!";
                        yield return new WaitForSeconds(3f);
                    }
                }
            }
        }
        //re enables player interface when the enemy turn is completed.
        turnOnCraftButton.interactable = true;
        getTable.SetActive(true);
        PlayerTurn();
    }

    public void CheckEnemyDead()
    {
        //checks if wave has been completed
        if (killCount >= 3 && wave == 1)
        {
            wave += 1;
            killCount = 0;
            StartCoroutine(GenerateBattle());
        }

        if (killCount >= 3 && wave == 2)
        {
            wave += 1;
            killCount = 0;
            StartCoroutine(GenerateBattle());
        }

        if (killCount >= 3 && wave == 3)
        {
            killCount = 0;
            WinGame(); 
        }
    }

    public void CheckIfPlayerDied()
    {
        //checks if player lost
        if (playerGO.GetComponent<Unit>().curHP <= 0)
        {
            CraftCanvas.enabled = false;
            getBattleUI.enabled = false;
            defeatScreen.SetActive(true);
        }
    }

    public void WinGame()
    {
        //checks if player won
        CraftCanvas.enabled = false;
        getBattleUI.enabled = false;
        victoryScreen.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerShield();
        CheckEnemyDead();
        CheckIfPlayerDied();
    }
}
