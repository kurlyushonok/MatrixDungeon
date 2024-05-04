using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixDrawer : MonoBehaviour
{
    [SerializeField] protected StringDrawer stringDrawerPrefab;
    [SerializeField] protected LayoutGroup layoutGroup;
    [SerializeField] protected Button button;

    public void Init(List<List<int>> list)
    {
        var oldStrings = GetComponentsInChildren<StringDrawer>();
        foreach (var oldString in oldStrings)
        {
            Destroy(oldString.gameObject);
        }
        
        for (int i = 0; i < list.Count; i++)
        {
            var row = list[i];
            var instance = Instantiate(stringDrawerPrefab, layoutGroup.transform);
            instance.Init(row);
        }
    }
}
