using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Step
{
    [SerializeField] string _instruct;
    public string Instructions => _instruct;
    public List<Objective> Objectives;
}