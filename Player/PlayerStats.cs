using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    Strength,
    Dexterity,
    Intelligence
}

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Config")]
    public int Level;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")]
    public float Mana;
    public float MaxMana;

    [Header("Experience")]
    public float CurrentExperience;
    public float NextLevelExperience;
    public float InitialNextLevelExperience; // this is only needed to reach level 2, when the player dies we reset the NextLevelExperience to this value
    [Range(1, 100f)] public float ExperienceMultiplier;

    [Header("Attack")]
    public float BaseDamage;
    public float CriticalChance;
    public float CriticalDamage;

    [Header("Attributes")]
    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public int AttributePoints;

    [HideInInspector] public float TotalExperience;
    [HideInInspector] public float TotalDamage;

    public void ResetPlayer()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        Level = 1;
        CurrentExperience = 0f;
        NextLevelExperience = InitialNextLevelExperience;
        TotalExperience = 0f;
        BaseDamage = 2;
        CriticalChance = 10;
        CriticalDamage = 50;
        Strength = 0;
        Dexterity = 0;
        Intelligence = 0;
        AttributePoints = 0;
    }
}
