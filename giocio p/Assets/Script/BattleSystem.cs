using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Battlestate{Start, PlayerTurn, EnemyTurn, Won, Lost }
public class BattleSystem : MonoBehaviour
{
    //int turn = 0;

    public GameObject PlayerUnit;
    public GameObject EnemyUnit;
    public GameObject Player2Unit;
    public GameObject Enemy2Unit;

    
    public Transform EnemySpawn;
    public Transform PlayerSpawn;
    public Transform Enemy2Spawn;
    public Transform Player2Spawn;

    Unit playerUnit;
    Unit enemyUnit;
    //Unit[] playerUnit = new Unit[4];
    //Unit[] enemyUnit = new Unit[4];
    

    public Calculator calculator;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Battlestate state;
 
    void Start()
    {
        state = Battlestate.Start;
        StartCoroutine(StartBattle());
    }


   IEnumerator StartBattle() {


       GameObject playerGO = Instantiate (PlayerUnit, PlayerSpawn);
        playerUnit = playerGO.GetComponent<Unit>();

       GameObject enemyGO = Instantiate (EnemyUnit, EnemySpawn);
        enemyUnit = enemyGO.GetComponent<Unit>();

      /* GameObject player2GO = Instantiate(Player2Unit, Player2Spawn);
        playerUnit = player2GO.GetComponent<Unit>();

       GameObject enemy2GO = Instantiate(Enemy2Unit, Enemy2Spawn);
        enemyUnit = enemy2GO.GetComponent<Unit>();*/

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);


       state = Battlestate.PlayerTurn;
        playerturn ();
    
    }

    IEnumerator PlayerAttack(){

    //danneggiare nemico

    bool ËMorto = enemyUnit.TakeDamage(calculator.DmgCalculator(playerUnit.Attack));
    enemyHUD.SetHp(enemyUnit.CurrentHp);


    yield return new WaitForSeconds(2f);

    //controlla se nemico morto o no

    if(ËMorto){
    //termina battaglia
    state=Battlestate.Won;
    EndBattle();
    }else{
    //turno avversario
    state = Battlestate.EnemyTurn;
    StartCoroutine(EnemyTurn());
    }}

    
    
    IEnumerator EnemyTurn(){

     bool ËMorto = playerUnit.TakeDamage(calculator.DmgCalculator(enemyUnit.Attack));

     playerHUD.SetHp(playerUnit.CurrentHp);

     yield return new WaitForSeconds(1f);
     if(ËMorto){
        

     state = Battlestate.Lost;
     EndBattle();
     }else {

     state = Battlestate.PlayerTurn;
     playerturn();
     }
    }
    
    
    void EndBattle(){
    if(state == Battlestate.Won) {

    }
    
    
    }



    void playerturn(){
        // serve per le scritte dopo penso
    }


    IEnumerator PlayerHeal() {
        playerUnit.Heal(calculator.HealCalculator(playerUnit.MagicAttack));

        playerHUD.SetHp(playerUnit.CurrentHp);

        yield return new WaitForSeconds(2f);

        state = Battlestate.EnemyTurn;
        StartCoroutine(EnemyTurn());
    }



   public void AttackButton(){

   if (state != Battlestate.PlayerTurn)
     return;

     StartCoroutine(PlayerAttack());


    }

    public void HealButton() {

        if (state != Battlestate.PlayerTurn)
            return;

        StartCoroutine(PlayerHeal());


    }


}


