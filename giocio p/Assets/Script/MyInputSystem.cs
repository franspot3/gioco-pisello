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

        

    }

    public void RightChange(InputAction.CallbackContext contex) {

    Control(1);

   

    }





    public void Control(int direction) {
        bool finish = false;
        ControlSelected = selected;
        while(finish == false) {
         Debug.Log("controllato");
        ControlSelected += direction;
            if (ControlSelected == 3) {
                ControlSelected = 0;
            }
            else if (ControlSelected == -1) {
                ControlSelected = 2;
            }

            if (BattleSystem.enemyUnit[ControlSelected].CurrentHp > 0) {
                selected = ControlSelected;
                finish = true;
            }
            
        }
          transform.position = BattleSystem.EnemySpawn[selected].position + new Vector3(0, 2.41f, 0);
    }}


