using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int DmgCalculator(int Attack) {
        return (Attack / 6);
    }
    public int HealCalculator(int MagicAttack) {
        return (MagicAttack / 8);
    }
}
