using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExperience(300f);
        }
    }

    public void AddExperience(float amount)
    {
        stats.TotalExperience += amount;
        stats.CurrentExperience += amount;
        while (stats.CurrentExperience >= stats.NextLevelExperience)
        { 
            stats.CurrentExperience -= stats.NextLevelExperience;
            NextLevel();
        }
    }

    private void NextLevel()
    {
        stats.Level++;
        stats.AttributePoints++;
        float currentExpRequired = stats.NextLevelExperience;
        float newNextLevelExp = Mathf.Round(currentExpRequired + stats.NextLevelExperience * (stats.ExperienceMultiplier / 100f));
        stats.NextLevelExperience = newNextLevelExp;
    }
}
