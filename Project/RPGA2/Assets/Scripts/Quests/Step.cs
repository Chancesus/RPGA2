using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Step
{
    [SerializeField] string _instructions;
    public List<Objective> Objective;
}