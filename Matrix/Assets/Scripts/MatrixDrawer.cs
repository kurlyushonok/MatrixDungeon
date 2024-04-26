using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixDrawer : MonoBehaviour
{
    [SerializeField] private StringDrawer stringDrawerPrefab;
    [SerializeField] private LayoutGroup layoutGroup;
    [SerializeField] private Button button;

    private List<List<int>> array = new ()
    {
        new List<int>(){1,2,3},
        new List<int>(){4,5,6},
        new List<int>(){9,8,7},
    };
    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            Init(array);
            for (int j = 0; j < array.Count; j++)
            {
                for (int i = 0; i < array[j].Count; i++)
                {
                    array[j][i] *= 2;
                }
            }
        });
    }

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
