using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public int maxHealth;
    public int experience;
    public int level;
    public float characterSpeed;
    public float characterTurnSpeed;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int money; 

    public int maxWormStackSize;
    [HideInInspector]
    public int currentWormStackSize;

    public int maxEggStackSize;
    [HideInInspector]
    public int eggStackSize;
}
