using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Extensions;
using UnityEngine;
using UnityEngine.Events;
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
    private int amountOfTasks;
    private int notRightAmountOfTasks;

    public UnityEvent rightAnswerGetted;
    public UnityEvent notRightAnswerGetted;
    public UnityEvent amountOfTasksChanged;
    public UnityEvent NextTaskUnlocked;

    public int AmountOfTasks => amountOfTasks;
    public int NotRightAmountOfTasks => notRightAmountOfTasks;

    private void Awake()
    {
        checkButton.onClick.AddListener(OnButtonClick);
        GetTask();
    }

    public void GetTask()
    {
        baseTask.Init(_layoutGroup);
        needRedraw = true;
        if (_answerMatrixDrawer != null) Destroy(_answerMatrixDrawer.gameObject);
        
        var instance = Instantiate(_answerMatrixDrawerPrefab, _answerLayoutGroup.transform);
        _rightAnswer = baseTask.GetRightAnswer();
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

    private void OnButtonClick() //заходит повторно в метод
    {
        var isAnswerRight = baseTask.CheckTask(_answerMatrixDrawer.Value);
        if (isAnswerRight)
        {
            rightAnswerGetted.Invoke();
            amountOfTasks++;
            amountOfTasksChanged.Invoke();
            if (amountOfTasks >= 3) NextTaskUnlocked.Invoke();
        }
        else
        {
            notRightAnswerGetted.Invoke();
        }
    }
}
