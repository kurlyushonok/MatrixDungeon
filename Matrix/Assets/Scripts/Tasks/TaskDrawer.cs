using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class TaskDrawer : MonoBehaviour
{
    [SerializeField] private BaseTask baseTask;
    [SerializeField] protected LayoutGroup _layoutGroup;
    [SerializeField] protected LayoutGroup _answerLayoutGroup;
    [SerializeField] private AnswerMatrixDrawer _answerMatrixDrawerPrefab;
    [SerializeField] private Button checkButton;
    private AnswerMatrixDrawer _answerMatrixDrawer;
    private bool needRedraw;
    private List<List<int>> _rightAnswer;

    private void Awake()
    {
        baseTask.Init(_layoutGroup);
        needRedraw = true;
        
        var instance = Instantiate(_answerMatrixDrawerPrefab, _answerLayoutGroup.transform);
        _rightAnswer = baseTask.GetRightAnswer();
        checkButton.onClick.AddListener(OnButtonClick);
        instance.Init(_rightAnswer);
        _answerMatrixDrawer = instance;
    }

    private void FixedUpdate()
    {
        if (needRedraw)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_layoutGroup.GetComponent<RectTransform>());
            needRedraw = false;
        }
    }

    private void OnButtonClick()
    {
        var isAnswerRight = _answerMatrixDrawer.Value.IsEqual(_rightAnswer);
        Debug.Log(isAnswerRight ? "Ok" : "Not ok");
    }
}
