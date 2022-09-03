using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using System.Text;

public class DialogController : MonoBehaviour
{
    [SerializeField] TMP_Text _storyText;
    [SerializeField] Button[] _choiceButtons;
    [SerializeField] TextAsset _dialog;
    Story _story;

    [ContextMenu("Start Dialog")]
    void StartDialog()
    {
        _story = new Story(_dialog.text);
        RefreshView();
    }

    private void RefreshView()
    {
       StringBuilder storyTextBuilder = new StringBuilder();
        while (_story.canContinue)
            storyTextBuilder.AppendLine(_story.Continue());

        _storyText.SetText(storyTextBuilder);

        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            var button = _choiceButtons[i];
            button.gameObject.SetActive(i < _story.currentChoices.Count); 
            button.onClick.RemoveAllListeners();
            if (i < _story.currentChoices.Count)
            {
                var choice = _story.currentChoices[i];
                button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                button.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefreshView();
                });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}