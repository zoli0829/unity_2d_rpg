using System;
using UnityEngine;

[Serializable]
public class FSMTransition
{
    public FSMDecision Decision; // PlayerInRangeOfAttack -> True or False
    public string TrueState; // Current State -> Attack State
    public string FalseState; // Current State -> Patrol State
}
