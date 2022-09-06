using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public List<Step> Steps;

    [SerializeField] string _name;
    [SerializeField] string _description;
    [SerializeField] string _notes;
}

[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _objectiveType;
    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }
}
