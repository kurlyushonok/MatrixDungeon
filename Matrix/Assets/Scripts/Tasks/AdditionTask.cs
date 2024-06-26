﻿using System.Collections.Generic;
using DefaultNamespace.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Tasks
{
    [CreateAssetMenu(fileName = "BaseAdditionTask", menuName = "Tasks/AdditionTask", order = 50)]
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
            Clear();
            
            _matrix1 = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
            _matrix2 = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
            var matrix1Drawer = GenerateMatrix(_matrix1);
            var instance = Instantiate(textPrefab, _layoutGroup.transform);
            instance.text = "+";
            var matrix2Drawer = GenerateMatrix(_matrix2);
            
            var instance2 = Instantiate(textPrefab, _layoutGroup.transform);
            instance2.text = "=";
        }

        public override bool CheckTask(List<List<int>> answer)
        {
            return answer.IsEqual(GetRightAnswer());
        }

        public override List<List<int>> GetRightAnswer()
        {
            var answer = new List<List<int>>();
            for (int i = 0; i < rowCnt; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < columnCnt; j++)
                {
                    row.Add(_matrix1[i][j] + _matrix2[i][j]);
                }
                answer.Add(row);
            }

            return answer;
        }
    }
}