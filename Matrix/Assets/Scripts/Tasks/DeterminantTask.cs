using System.Collections.Generic;
using DefaultNamespace.Extensions;
using TMPro;
using UnityEngine;

namespace Tasks
{
    [CreateAssetMenu(fileName = "BaseDeterminantTask", menuName = "Tasks/DeteminantTask", order = 50)]
    public class DeterminantTask : BaseTask
    {
        [SerializeField] private int maxValue;
        [SerializeField] private int minValue;
        [SerializeField] private TMP_Text textPrefab;

        
        private List<List<int>> _matrix;
        protected override void GenerateTask()
        {
            Clear();
            _matrix = MatrixGenerator.GetMatrix(minValue, maxValue, 3, 3);
            var matrixDrawer = GenerateMatrix(_matrix);
            
            var instance2 = Instantiate(textPrefab, _layoutGroup.transform);
            instance2.text = "=";
        }

        public override bool CheckTask(List<List<int>> answer)
        {
            return answer.IsEqual(GetRightAnswer());
        }

        public override List<List<int>> GetRightAnswer()
        {
            var result = new List<List<int>>();
            var A00 = _matrix[0][0] * (_matrix[1][1] * _matrix[2][2] - _matrix[1][2] * _matrix[2][1]);
            var A01 = _matrix[0][1] * (_matrix[1][0] * _matrix[2][2] - _matrix[1][2] * _matrix[2][0]);
            var A02 = _matrix[0][2] * (_matrix[1][0] * _matrix[2][1] - _matrix[1][1] * _matrix[2][0]);
            var rowAnswer = new List<int>() { A00 - A01 + A02 };
            result.Add(rowAnswer);
            return result;
        }
    }
}