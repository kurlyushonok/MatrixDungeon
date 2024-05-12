using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class AnswerMatrixDrawer: MatrixDrawer
    {
        private List<StringDrawer> _stringDrawers;

        public List<List<int>> Value => _stringDrawers.Select(x => x.Value).ToList();

        public new void Init(List<List<int>> list)
        {
            _stringDrawers = new List<StringDrawer>();
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
                _stringDrawers.Add(instance);
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }
    }
}