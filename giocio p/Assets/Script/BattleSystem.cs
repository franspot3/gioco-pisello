using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Battlestate{Start, PlayerTurn, EnemyTurn, Won, Lost }
public class BattleSystem : MonoBehaviour
{


    public GameObject PlayerUnit;
    public GameObject EnemyUnit;

    public Transform EnemySpawn;
    public Transform PlayerSpawn;


    public Battlestate state;
    void Start()
    {
        state = Battlestate.Start;
        StartBattle();
    }


    void StartBattle() {
        Instantiate (PlayerUnit, PlayerSpawn);
        Instantiate (EnemyUnit, EnemySpawn);  
    }

}
