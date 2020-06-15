using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Text dialogText;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle()); //coroutines for delays
    }
    IEnumerator SetupBattle(){
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogText.text = "You see a " +enemyUnit.unitName + " get into battle stance..";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f); //causes delay

        state = BattleState.PLAYERTURN; //switching to player turn
        PlayerTurn();
    }

    void PlayerTurn(){
        dialogText.text = "What do you do?";
    }

    IEnumerator PlayerHeal(){
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogText.text = "You are filled with determination.. and strength";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerAttack(){
        //Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogText.text = "The attack was successful";

        yield return new WaitForSeconds(2f);

        if(isDead){
            //end battle
            state = BattleState.WON;
            EndBattle();
        }else{
            // enemyturn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        //check if enemy is dead

        // change state based on what happened

    }

    IEnumerator EnemyTurn(){
        dialogText.text = enemyUnit.unitName + " strikes!";

        yield return new WaitForSeconds(1f);

        bool isDead =playerUnit.TakeDamage(enemyUnit.damage); //did player die

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead){
            state = BattleState.LOST;
            EndBattle();
        }else{
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle(){
        if(state == BattleState.WON){
            dialogText.text = "You emerge victorious!";
        }
        else if(state == BattleState.LOST){
            dialogText.text = "Death has won this day...";
        }
    }
    public void OnAttackButton(){
        if(state != BattleState.PLAYERTURN){
            return; //dont want to do anything if not player turn
        }
        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton(){
        if(state != BattleState.PLAYERTURN){
            return; //dont want to do anything if not player turn
        }
        StartCoroutine(PlayerHeal());
    }
}
