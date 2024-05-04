using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Tasks
{
    [CreateAssetMenu(fileName = "BaseAdditionTask", menuName = "Task", order = 50)]
    public class AdditionTask: BaseTask
    {
        [SerializeField] private int maxValue;
        [SerializeField] private int minValue;
        [SerializeField] private int rowCnt;
        [SerializeField] private int columnCnt;
        [FormerlySerializedAs("plusTextPrefab")] [SerializeField] private TMP_Text textPrefab;
        private List<List<int>> _matrix1;
        private List<List<int>> _matrix2;

        protected override void GenerateTask()
        {
            _matrix1 = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
            _matrix2 = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
            var matrix1Drawer = GenerateMatrix(_matrix1);
            var instance = Instantiate(textPrefab, _layoutGroup.transform);
            instance.text = "+";
            var matrix2Drawer = GenerateMatrix(_matrix2);
            
            var instance2 = Instantiate(textPrefab, _layoutGroup.transform);
            instance2.text = "=";
        }

        protected override void CheckTask()
        {
            throw new System.NotImplementedException();
        }

        public override List<List<int>> GetRightAnswer()
        {
            return _matrix1;
        }
    }
}