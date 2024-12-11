using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class WeaponSO : ScriptableObject
{
    public int damage;
    public float atkSpeed;
    public float atkRange;
}
