using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum Battlestate{Start, PlayerTurn, EnemyTurn, Won, Lost, Neutral }
public class BattleSystem : MonoBehaviour
{


   public int turn = 0;
   public int[] turnOrder = new int[4] {1,2,3,4};
   public int[] EnemyOrUs = new int[4] {0,0,1,1};

    public GameObject[] PlayerUnit;
    public GameObject[] EnemyUnit;

    public Transform[] PlayerSpawn;
    public Transform[] EnemySpawn; 

   public int deathenemies = 0;
   public int deathplayers = 0;


    public Unit[] playerUnit = new Unit[4];
    public Unit[] enemyUnit = new Unit[4];
    

    public Calculator calculator;
    public MyInputSystem Target;
    public activeturn Activeturn;


    public BattleHUD[] playerHUD;
    public BattleHUD[] enemyHUD;


    public Battlestate state;
 

    void Start()
    {
        state = Battlestate.Start;
        StartCoroutine(StartBattle());
    }


   IEnumerator StartBattle() {
        int[] SpeedStats = new int[4];
    for(int i=0; i<=1; i++){
       GameObject playerGO = Instantiate (PlayerUnit[i], PlayerSpawn[i]);
        playerUnit[i] = playerGO.GetComponent<Unit>();

       GameObject enemyGO = Instantiate (EnemyUnit[i], EnemySpawn[i]);
        enemyUnit[i] = enemyGO.GetComponent<Unit>();


            playerHUD[i].SetHUD(playerUnit[i]);
            enemyHUD[i].SetHUD(enemyUnit[i]);
        }


        yield return new WaitForSeconds(2f);



        for(int i=0; i <= 1; i++) {
            SpeedStats[i] = playerUnit[i].Speed;
            SpeedStats[i+2] = enemyUnit[i].Speed;
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
        for (int j = 0; j <= 3; j++) {
            if (turnOrder[j]== 1 || turnOrder[j]== 3 ) {
                turnOrder[j] = 0;
            } else { 
                turnOrder[j] = 1;
            }
        }
        if (EnemyOrUs[turn] == 0) {
            state = Battlestate.PlayerTurn;
            playerturn();
            Activeturn.IndicateTurn();
        } else {
            state = Battlestate.EnemyTurn;
            StartCoroutine(EnemyTurn());

            Activeturn.IndicateTurn();
        }

    }
    void playerturn() {
        // serve per le scritte dopo penso

        if (turnOrder[turn] == 2 ){

        changeturn();
        
        }


    }
    IEnumerator EnemyTurn() {

        
       if (turnOrder[turn] == 3 ){

        changeturn();
        
        }

        int EnemyTarget;
        EnemyTarget = Random.Range(0, 2);

        if(playerUnit[EnemyTarget].CurrentHp <= 0){
         Debug.Log("non puoi");
         state=Battlestate.EnemyTurn;

         yield return null;

         EnemyTurn();
        }

        bool èMorto = playerUnit[EnemyTarget].TakeDamage(calculator.DmgCalculator(enemyUnit[turnOrder[turn]].Attack));

        

        playerHUD[EnemyTarget].SetHp(playerUnit[EnemyTarget].CurrentHp);

        
       
        yield return new WaitForSeconds(1f);


     if (èMorto) {

     
             turnOrder [turn] = 2;
             deathplayers ++;

             if (deathplayers == 2 ){

               state = Battlestate.Lost;
               EndBattle();

             }
         }
      changeturn();



    }
    IEnumerator PlayerAttack() {

    
        bool èMorto = enemyUnit[Target.selected].TakeDamage(calculator.DmgCalculator(playerUnit[turnOrder[turn]].Attack));
         enemyHUD[Target.selected].SetHp(enemyUnit[Target.selected].CurrentHp);


         yield return new WaitForSeconds(2f);

        //controlla se nemico morto o no

        if (èMorto) {
            Target.Control(1);

                    turnOrder [turn] = 3;
             deathenemies ++;
             Debug.Log("è morto");

             if (deathenemies == 2 ){

               state = Battlestate.Won;
               EndBattle();

             }
            
         }
         changeturn();
    }

    IEnumerator PlayerHeal() {
        playerUnit[turnOrder[turn]].Heal(calculator.HealCalculator(playerUnit[turnOrder[turn]].MagicAttack));

        playerHUD[turnOrder[turn]].SetHp(playerUnit[turnOrder[turn]].CurrentHp);

        yield return new WaitForSeconds(2f);

       changeturn();
    }




        void changeturn() {
            if (turn == 3) {
            turn = 0;
        }
        else {
            turn++;
        }


        if (EnemyOrUs[turn] == 0) {
            state = Battlestate.PlayerTurn;
            playerturn();
            Debug.Log("il turno è" + turn);
            Activeturn.IndicateTurn();
        }
        else {
            state = Battlestate.EnemyTurn;
            StartCoroutine(EnemyTurn());
            Debug.Log("il turno è" + turn);
            Activeturn.IndicateTurn();
        }}

    public void AttackButton() {

        if (state != Battlestate.PlayerTurn)
            return;

        state = Battlestate.Neutral;
        StartCoroutine(PlayerAttack());


    }

    public void HealButton() {

        if (state != Battlestate.PlayerTurn)
            return;

        state = Battlestate.Neutral;
        StartCoroutine(PlayerHeal());


    }

    
    

    
    
    
    
    
    void EndBattle(){
    if(state == Battlestate.Won) {

    }
    
    
    }



    

 


}


