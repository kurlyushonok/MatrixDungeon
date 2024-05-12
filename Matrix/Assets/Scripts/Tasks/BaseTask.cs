using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseTask : ScriptableObject
{
    protected LayoutGroup _layoutGroup;
    [SerializeField] private MatrixDrawer matrixDrawerPrefab;

    protected abstract void GenerateTask();
    public abstract bool CheckTask(List<List<int>> answer);
    public abstract List<List<int>> GetRightAnswer();

    protected MatrixDrawer GenerateMatrix(List<List<int>> matrix)
    {
        var instance = Instantiate(matrixDrawerPrefab, _layoutGroup.transform);
        instance.Init(matrix);
        return instance;
    }

    public void Init(LayoutGroup group)
    {
        this._layoutGroup = group;
        GenerateTask();
    }
}
