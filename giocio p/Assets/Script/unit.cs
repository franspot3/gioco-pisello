using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Stats{
    public int MaxHp;
    public int CurrentHp;
    public int MaxMana;
    public int CurrentMana;
    public int Armor;
    public int CurrentArmor;
    public int MagicAmor;
    public int CurrentMagicArmor;
    public int Attack;
    public int CurrentAttack;
    public int MagicAttack;
    public int CurrentMagicAttack;
    public int Speed;
    public int CurrentSpeed;
    public int AttackSpeed;
    public int CurrentAttackSpeed;
    public int Accuracy;
    public int CurrentAccuracy;
    public int Evasion;
    public int CurrentEvasion;}
    

public class Unit : MonoBehaviour {
    public Stats Stat;

    public bool TakeDamage(int Dmg){

    CurrentHp -= Dmg;

    if(CurrentHp <= 0 ){
          return true;
    }else{
          return false;}

    }

    public void Heal(int amount) {

        CurrentHp += amount;

        if (CurrentHp > MaxHp ) {
            CurrentHp = MaxHp;
        }
        

    }

}
