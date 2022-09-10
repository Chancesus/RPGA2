using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    

    [SerializeField] string _displayName;
    [SerializeField] string _description;
    [SerializeField] string _notes;
    [SerializeField] Sprite _sprite;

    int _currentStepIndex;

    public List<Step> Steps;

    public string Description => _description;
    public string DisplayName => _displayName;

    public Sprite Sprite => _sprite;

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
        }
    }

    
    private Step GetCurrentStep()
    {
        return Steps[_currentStepIndex];
    }
}
[Serializable]
public class Step
{
    [SerializeField] string _instruct;
    public string Instructions => _instruct;
    public List<Objective> Objectives;

    public bool HasAllObjectivesCompleted()
    {
        return Objectives.TrueForAll(t => t.IsCompleted);
    }
}



[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _objectiveType;

    public bool IsCompleted { get; }

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }

    public override string ToString()
    {
       return _objectiveType.ToString();
    }
}
