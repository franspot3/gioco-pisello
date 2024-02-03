using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Battlestate{Start, PlayerTurn, EnemyTurn, Won, Lost }
public class BattleSystem : MonoBehaviour
{


    public GameObject PlayerUnit;
    public GameObject EnemyUnit;

    public Transform EnemySpawn;
    public Transform PlayerSpawn;

    Unit playerUnit;
    Unit enemyUnit;


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

        yield return new WaitForSeconds(2f);

        state = Battlestate.PlayerTurn;
        playerturn ();
    
    }

    IEnumerator PlayerAttack(){

    //danneggiare nemico

    bool ËMorto = EnemyUnit.TakeDamage(playerUnit.damage);
    //enemyHUD.setHP(enemyUnit.CurrentHp);


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

     bool ËMorto = playerUnit.TakeDamage(enemyUnit.damage);

     //playerHUD.SetHP(playerUnit.CurrentHp);

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

    }

   public void AttackButton(){

   if (state != Battlestate.PlayerTurn)
     return;

     StartCoroutine(PlayerAttack());


    }



}


