using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StringDrawer : MonoBehaviour
{
    [SerializeField] protected CellDrawer cellDrawerPrefab;
    [SerializeField] protected LayoutGroup layoutGroup;
    private List<CellDrawer> _cellDrawers;

    public List<int> Value => _cellDrawers.Select(x => x.Value).ToList();

    public void Init(List<int> row)
    {
        _cellDrawers = new List<CellDrawer>();
        foreach (var i in row)
        {
            var instance = Instantiate(cellDrawerPrefab, layoutGroup.transform);
            instance.Init(i);
            _cellDrawers.Add(instance);
        }
    }
}
