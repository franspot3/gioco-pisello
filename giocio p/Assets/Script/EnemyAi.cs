using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {


    public BattleSystem BattleSystem;

    public void AIDecison() {
        StartCoroutine(AttackAction());
    }
     IEnumerator AttackAction() {
        Debug.Log("mi ha chiamato");

        int EnemyTarget;
        EnemyTarget = Random.Range(0, 2);

        if (BattleSystem.playerUnit[EnemyTarget].CurrentHp <= 0) {
            Debug.Log("non puoi");
            BattleSystem.state = Battlestate.EnemyTurn;

            yield return null;

            BattleSystem.EnemyTurn();
        }
        else {

            bool èMorto = BattleSystem.playerUnit[EnemyTarget].TakeDamage(BattleSystem.calculator.DmgCalculator(BattleSystem.enemyUnit[BattleSystem.turnOrder[BattleSystem.turn]].Attack));
            Debug.Log("Attacco " + EnemyTarget);


            BattleSystem.playerHUD[EnemyTarget].SetHp(BattleSystem.playerUnit[EnemyTarget].CurrentHp);



            yield return new WaitForSeconds(1f);


            if (èMorto) {
                for (int i = 0; i <= 3; i++) {
                    if (BattleSystem.turnOrder[i] == EnemyTarget && BattleSystem.EnemyOrUs[i] == 0) {
                        BattleSystem.turnOrder[i] = 2;
                        Debug.Log(BattleSystem.turnOrder[i]);
                    }

                }

                BattleSystem.deathplayers++;

                if (BattleSystem.deathplayers == 2) {

                    BattleSystem.state = Battlestate.Lost;
                    BattleSystem.EndBattle();
                }
            }
            BattleSystem.changeturn();
        }
    }
}
