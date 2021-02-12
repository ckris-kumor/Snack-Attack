using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AtkStruct", order = 1)]
public class AtkStruct : ScriptableObject
{
    public string fireKey;
    public GameObject atkObj;
    public float cooldownTimer;
    public float cooldown;
    public bool canFire;
    public float atkDistance;
}
