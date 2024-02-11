using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum Battlestate{Start, PlayerTurn, EnemyTurn, Won, Lost, Neutral }
public class BattleSystem : MonoBehaviour
{


   public int turn = 0;
   public int[] turnOrder = new int[6] {0,1,2,0,1,2};
   public int[] EnemyOrUs = new int[6] {0,0,0,1,1,1};
   
    public GameObject[] PlayerUnit;
    public GameObject[] EnemyUnit;

    public Transform[] PlayerSpawn;
    public Transform[] EnemySpawn; 

   public int deathEnemies = 0;
   public int deathplayers = 0;


    public Unit[] playerUnit = new Unit[4];
    public Unit[] enemyUnit = new Unit[4];
    

    public Calculator calculator;
    public MyInputSystem Target;
    public activeturn Activeturn;
    public EnemyAi EnemyAi;
    public PlayerAction PlayerAction;


    public BattleHUD[] playerHUD;
    public BattleHUD[] enemyHUD;


    public Battlestate state;
    

    void Start()
    {
        
        state = Battlestate.Start;
        StartCoroutine(StartBattle());
    }


   IEnumerator StartBattle() {
           
        int[] SpeedStats = new int[6];
    for(int i=0; i<=PlayerUnit.Length-1; i++){
       GameObject playerGO = Instantiate (PlayerUnit[i], PlayerSpawn[i]);
        playerUnit[i] = playerGO.GetComponent<Unit>();

       GameObject enemyGO = Instantiate (EnemyUnit[i], EnemySpawn[i]);
        enemyUnit[i] = enemyGO.GetComponent<Unit>();


            playerHUD[i].SetHUD(playerUnit[i]);
            enemyHUD[i].SetHUD(enemyUnit[i]);
        }


        yield return new WaitForSeconds(2f);



        for (int i = 0; i <= PlayerUnit.Length - 1; i++) {
            SpeedStats[i] = playerUnit[i].Speed;
            SpeedStats[i + PlayerUnit.Length - 1] = enemyUnit[i].Speed;
        }
        int temp;
        int temp2;
        int temp3;
        for (int j = 0; j < (SpeedStats.Length - 1); j++)
            for (int i = 0; i < (SpeedStats.Length - 1); i++)
                if (SpeedStats[i] < SpeedStats[i + 1]) {
                  
                    temp = SpeedStats[i];
                    SpeedStats[i] = SpeedStats[i + 1];
                    SpeedStats[i + 1] = temp;
                    temp2 = turnOrder[i];
                    turnOrder[i] = turnOrder[i + 1];
                    turnOrder[i + 1] = temp2;
                    temp3 = EnemyOrUs[i];
                    EnemyOrUs[i] = EnemyOrUs[i + 1];
                    EnemyOrUs[i + 1] = temp3;
                }
        if (EnemyOrUs[turn] == 0) {
            state = Battlestate.PlayerTurn;
            playerturn();
            Activeturn.IndicateTurn();
        } else {
            state = Battlestate.EnemyTurn;
            EnemyTurn();

            Activeturn.IndicateTurn();
        }

    }
    void playerturn() {
        // serve per le scritte dopo penso

        Debug.Log(turnOrder[turn]);
        //attento cambiare dopo
        if (turnOrder[turn] == 2 ){

        changeturn();
        
        }


    }
    public void EnemyTurn() {

        Debug.Log(turnOrder[turn]);

        if (turnOrder[turn] == 3) {

            changeturn();

        }
        else {
            EnemyAi.AIDecison();
        }
    }

      public  void changeturn() {
            if (turn == 5) {
            turn = 0;
        }
        else {
            turn++;
        }


        if (EnemyOrUs[turn] == 0) {
            state = Battlestate.PlayerTurn;
            playerturn();
            Debug.Log("il turno è " + turn);
            Activeturn.IndicateTurn();
        }
        else {
            state = Battlestate.EnemyTurn;
            EnemyTurn();
            Debug.Log("il turno è " + turn);
            Activeturn.IndicateTurn();
        }}

    public void AttackButton() {

        if (state != Battlestate.PlayerTurn)
            return;

        state = Battlestate.Neutral;
        StartCoroutine(PlayerAction.PlayerAttack());


    }

    public void HealButton() {

        if (state != Battlestate.PlayerTurn)
            return;

        state = Battlestate.Neutral;
        StartCoroutine(PlayerAction.PlayerHeal());


    }

    
    
    public void EndBattle(){
    if(state == Battlestate.Won) {
    }
    }
    

}