using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleHUD : MonoBehaviour
{


    public Slider HpSlider;

    public void SetHUD(Unit unit){

        HpSlider.maxValue = unit.MaxHp;
        HpSlider.value = unit.CurrentHp;
     }

    public void SetHp(int hp) {
        HpSlider.value = hp;
     }

}
