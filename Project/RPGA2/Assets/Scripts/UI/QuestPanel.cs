using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System;

public class QuestPanel : ToggleablePanel
{
    [SerializeField] Quest _selectedQuest;
    [SerializeField] TMP_Text _questNameText;
    [SerializeField] TMP_Text _questDescriptionText;
    [SerializeField] TMP_Text _currentObjectivesText;
    [SerializeField] Image _questIcon;
    [SerializeField] Step _selectedStep;


    [ContextMenu("Bind")]
    public void Bind()
    {
        _questIcon.sprite = _selectedQuest.Sprite;

        _questNameText.SetText(_selectedQuest.DisplayName);
        _questDescriptionText.SetText(_selectedQuest.Description);


        _selectedStep = _selectedQuest.Steps.FirstOrDefault();
        DisplayStepInstructionsAndObjectives();

    }

    private void DisplayStepInstructionsAndObjectives()
    {
        StringBuilder builder = new StringBuilder();
        if (_selectedStep != null)
        {
            builder.AppendLine(_selectedStep.Instructions);
            foreach (var objective in _selectedStep.Objectives)
            {
                builder.AppendLine(objective.ToString());
            }

        }
        _currentObjectivesText.SetText(builder.ToString());
    }

    internal void SelectQuest(Quest quest)
    {
        _selectedQuest = quest;
        Bind();
        Show();
    }
}
