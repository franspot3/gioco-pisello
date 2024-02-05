using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputSystem : MonoBehaviour
{

    
    
    

    public BattleSystem BattleSystem;


    public int selected = 1;
    int ControlSelected;

    private void Awake() {
        transform.position = BattleSystem.EnemySpawn[selected].position + new Vector3(0, 2.41f, 0);

        InputSystem inputSystem = new InputSystem();
        inputSystem.Combat.Enable();
        inputSystem.Combat.ChangeTargetright.performed += RightChange;
        inputSystem.Combat.ChangeTargetleft.performed += LeftChange;
    }

    

    public void LeftChange(InputAction.CallbackContext contex) {
        Control(-1);
        if (selected == 1) {
            selected = 0;
        } else {
            selected++;
        }
        transform.position = BattleSystem.EnemySpawn[selected].position + new Vector3(0, 2.41f, 0);

    }

    public void RightChange(InputAction.CallbackContext contex) {
        Control(1);
        if (selected == 0) {
            selected = 1;
        }
        else {
            selected--;
        }
        transform.position = BattleSystem.EnemySpawn[selected].position + new Vector3(0, 2.41f, 0);

    }

    void Control(int direction) {
        bool finish = false;

        while(finish == false) {
            ControlSelected = selected + direction;
            if (ControlSelected == 2) {
                ControlSelected = 0;
            }
            else if (ControlSelected == -1) {
                ControlSelected = 1;
            }

            if (BattleSystem.enemyUnit[ControlSelected].CurrentHp > 0) {
                selected = ControlSelected;
                finish = true;
            }
        }

    }

}
