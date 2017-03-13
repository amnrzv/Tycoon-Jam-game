using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Requirements
{
    public uint code;
    public uint design;
    public uint production;
}

[Serializable]
public class Reward
{
    public uint money;
    public uint rep;
}

[CreateAssetMenu(fileName = "Project", menuName = "TycoonGame/Project", order = 10)]
public class Project : ScriptableObject
{
    public string projectName;
    public string description;
    public uint dayStart;
    public uint dayExpire;
    public uint upfrontPayment;
    public Requirements requirements;
    public Reward reward;
    public uint expectedTurnaroundInDays;
}
