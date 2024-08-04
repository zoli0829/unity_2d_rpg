using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    // this property will return the stats var
    public PlayerStats Stats => stats;

    private PlayerAnimations animations;

    private void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
    }

    public void ResetPlayer()
    {
        stats.ResetPlayer();
        animations.ResetPlayer();
    }
}
