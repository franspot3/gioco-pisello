using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputSystem : MonoBehaviour
{

    public Transform[] EnemySpawn;
    public int selected = 1;
    private void Awake() {
        transform.position = EnemySpawn[selected].position + new Vector3(0, 2.41f, 0);

        InputSystem inputSystem = new InputSystem();
        inputSystem.Combat.Enable();
        inputSystem.Combat.ChangeTargetright.performed += RightChange;
        inputSystem.Combat.ChangeTargetleft.performed += LeftChange;
    }

    

    public void LeftChange(InputAction.CallbackContext contex) {
        if (selected == 1) {
            selected = 0;
        } else {
            selected++;
        }
        transform.position = EnemySpawn[selected].position + new Vector3(0, 2.41f, 0);

    }

    public void RightChange(InputAction.CallbackContext contex) {
        if (selected == 0) {
            selected = 1;
        }
        else {
            selected--;
        }
        transform.position = EnemySpawn[selected].position + new Vector3(0, 2.41f, 0);

    }
}
