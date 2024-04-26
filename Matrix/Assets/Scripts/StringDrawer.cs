using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringDrawer : MonoBehaviour
{
    [SerializeField] private CellDrawer cellDrawerPrefab;
    [SerializeField] private LayoutGroup layoutGroup;
    public void Init(List<int> row)
    {
        foreach (var i in row)
        {
            var instance = Instantiate(cellDrawerPrefab, layoutGroup.transform);
            instance.Init(i);
        }
    }
}
