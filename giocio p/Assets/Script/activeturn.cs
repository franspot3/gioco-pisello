using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeturn : MonoBehaviour
{

public BattleSystem battlesystem;



public void IndicateTurn(){

if(battlesystem.turnOrder[battlesystem.turn] == 0 || battlesystem.turnOrder[battlesystem.turn] == 1){

   if (battlesystem.EnemyOrUs[battlesystem.turn] == 0){

   transform.position = battlesystem.PlayerSpawn[battlesystem.turnOrder[battlesystem.turn]].position + new Vector3 (0,2.41f,0);

} else {

 transform.position = battlesystem.EnemySpawn[battlesystem.turnOrder[battlesystem.turn]].position + new Vector3 (0,2.41f,0);

  }

}

 }

}
