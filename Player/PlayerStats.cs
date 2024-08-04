using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ResetPlayer()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        Level = 1;
        CurrentExperience = 0f;
        NextLevelExperience = InitialNextLevelExperience;
    }
}
