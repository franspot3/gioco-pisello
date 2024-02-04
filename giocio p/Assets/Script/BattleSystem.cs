using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum Battlestate{Start, PlayerTurn, EnemyTurn, Won, Lost, Neutral }
public class BattleSystem : MonoBehaviour
{

    int turn = 0;
    int[] turnOrder = new int[4] {1,2,3,4};
    int[] EnemyOrUs = new int[4] {0,0,1,1};

    public GameObject[] PlayerUnit;
    public GameObject[] EnemyUnit;

    public Transform[] PlayerSpawn;
    public Transform[] EnemySpawn; 

   
    Unit[] playerUnit = new Unit[4];
    Unit[] enemyUnit = new Unit[4];
    

    public Calculator calculator;
    public MyInputSystem Target;

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


           state = Battlestate.PlayerTurn;

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
        } else {
            state = Battlestate.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }

    }
    void playerturn() {
        // serve per le scritte dopo penso
    }
    IEnumerator EnemyTurn() {
        
        int EnemyTarget;
        EnemyTarget = Random.Range(0, 1);

        Debug.Log(EnemyTarget);

        bool èMorto = playerUnit[EnemyTarget].TakeDamage(calculator.DmgCalculator(enemyUnit[turnOrder[turn]].Attack));

        

        playerHUD[EnemyTarget].SetHp(playerUnit[EnemyTarget].CurrentHp);

        
        yield return new WaitForSeconds(1f);
        /* if (èMorto) {


             state = Battlestate.Lost;
             EndBattle();
         }
         else {*/
        

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
        }
        else {
            state = Battlestate.EnemyTurn;
            StartCoroutine(EnemyTurn());
            Debug.Log("il turno è" + turn);
        }
    
        //}
    }
    IEnumerator PlayerAttack() {


        Debug.Log("secondo stadio");
        bool èMorto = enemyUnit[Target.selected].TakeDamage(calculator.DmgCalculator(playerUnit[turnOrder[turn]].Attack));
         enemyHUD[Target.selected].SetHp(enemyUnit[Target.selected].CurrentHp);


         yield return new WaitForSeconds(2f);

        //controlla se nemico morto o no

        /*if (èMorto) {
             //termina battaglia
             state = Battlestate.Won;
             EndBattle();
         }
         else {*/
        // selettore turno
       
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
        }
            else {
                state = Battlestate.EnemyTurn;
            StartCoroutine(EnemyTurn());
            Debug.Log("il turno è" + turn);
        }
        }
    // }

    IEnumerator PlayerHeal() {
        playerUnit[turnOrder[turn]].Heal(calculator.HealCalculator(playerUnit[turnOrder[turn]].MagicAttack));

        playerHUD[turnOrder[turn]].SetHp(playerUnit[turnOrder[turn]].CurrentHp);

        yield return new WaitForSeconds(2f);

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
        }
        else {
            state = Battlestate.EnemyTurn;
            StartCoroutine(EnemyTurn());
            Debug.Log("il turno è" + turn);
        }
    }

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


