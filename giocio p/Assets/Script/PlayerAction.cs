using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAction : MonoBehaviour {


    public BattleSystem BattleSystem;
    public IEnumerator PlayerAttack() {


        bool ËMorto = BattleSystem.enemyUnit[BattleSystem.Target.selected].TakeDamage(BattleSystem.calculator.DmgCalculator(BattleSystem.playerUnit[BattleSystem.turnOrder[BattleSystem.turn]].Attack));
        BattleSystem.enemyHUD[BattleSystem.Target.selected].SetHp(BattleSystem.enemyUnit[BattleSystem.Target.selected].CurrentHp);




        //controlla se nemico morto o no

        if (ËMorto) {

            for (int i = 0; i <= 3; i++) {

                if (BattleSystem.turnOrder[i] == BattleSystem.Target.selected && BattleSystem.EnemyOrUs[i] == 1) {
                    BattleSystem.turnOrder[i] = 3;
                }

            }
            BattleSystem.deathEnemies++;

            if (BattleSystem.deathEnemies < 2) {
                BattleSystem.Target.Control(1);
            }

            if (BattleSystem.deathEnemies == 2) {
                Debug.Log("entrato");
                BattleSystem.state = Battlestate.Won;
                BattleSystem.EndBattle();
                yield break;
            }
        }
        yield return new WaitForSeconds(2f);
        BattleSystem.changeturn();
    }

    public IEnumerator PlayerHeal() {
        BattleSystem.playerUnit[BattleSystem.turnOrder[BattleSystem.turn]].Heal(BattleSystem.calculator.HealCalculator(BattleSystem.playerUnit[BattleSystem.turnOrder[BattleSystem.turn]].MagicAttack));

        BattleSystem.playerHUD[BattleSystem.turnOrder[BattleSystem.turn]].SetHp(BattleSystem.playerUnit[BattleSystem.turnOrder[BattleSystem.turn]].CurrentHp);

        yield return new WaitForSeconds(2f);

        BattleSystem.changeturn();
    }
}