using DefaultNamespace.Extensions;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tasks
{
    [CreateAssetMenu(fileName = "BaseFinalTask", menuName = "Tasks/FinalTask", order = 50)]
    public class FinalTask : BaseTask
    {
        [SerializeField] private int maxValue;
        [SerializeField] private int minValue;
        [SerializeField] private int rowCnt;
        [SerializeField] private int columnCnt;
        [SerializeField] private TMP_Text textPrefab;

        private List<List<int>> _matrixA;
        private List<List<int>> _matrixB;
        private List<List<int>> _matrixC;
        private List<List<int>> _matrixD;

        protected override void GenerateTask()
        {
            Clear();
            _matrixA = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
            _matrixB = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
            _matrixC = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
            _matrixD = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
            var matrixADrawer = GenerateMatrix(_matrixA);
            
            var instanceAdd = Instantiate(textPrefab, _layoutGroup.transform);
            instanceAdd.text = "+";
            
            var matrixBDrawer = GenerateMatrix(_matrixB);
            
            var instanceMult = Instantiate(textPrefab, _layoutGroup.transform);
            instanceMult.text = "*";
            
            var matrixCDrawer = GenerateMatrix(_matrixC);
            
            var instanceMult2 = Instantiate(textPrefab, _layoutGroup.transform);
            instanceMult2.text = "*";

            var matrixDDrawer = GenerateMatrix(_matrixD);
            
            var instance2 = Instantiate(textPrefab, _layoutGroup.transform);
            instance2.text = "=";
        }

        public override bool CheckTask(List<List<int>> answer)
        {
            return answer.IsEqual(GetRightAnswer());
        }

        public override List<List<int>> GetRightAnswer()
        {
            var answerC = GetTranspositionAnswer();
            var answerBMultC = GetMiltiplicationAnswer(_matrixB, answerC);
            var answerAdd = GetAdditionAnswer(answerBMultC);
            var answerDet = GetDeterminantAnswer();
            var answer = GetMultiplicationValueAnswer(answerDet[0][0], answerAdd);
            
            return answer;
        }
        
        private List<List<int>> GetMiltiplicationAnswer(List<List<int>> _matrix1, List<List<int>> _matrix2)
        {
            var answer = new List<List<int>>();
            for (int i = 0; i < rowCnt; i++)//3
            {
                var row = new List<int>();
                for (int j = 0; j < columnCnt; j++)//1
                {
                    var cell = 0;
                    for (int k = 0; k < rowCnt; k++)//3
                    {
                        cell += _matrix1[i][k] * _matrix2[k][j];
                    }
                    row.Add(cell);
                }
                answer.Add(row);
            }

            return answer;
        }
        
        private List<List<int>> GetTranspositionAnswer()
        {
            var answer = new List<List<int>>();
            for (int i = 0; i < rowCnt; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < columnCnt; j++)
                {
                    row.Add(_matrixC[j][i]);
                }
                answer.Add(row);
            }

            return answer;
        }
        
        private List<List<int>> GetMultiplicationValueAnswer(int value, List<List<int>> matrix)
        {
            var answer = new List<List<int>>();
            for (int i = 0; i < rowCnt; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < columnCnt; j++)
                {
                    row.Add(matrix[i][j] * value);
                }
                answer.Add(row);
            }

            return answer;
        }
        
        private List<List<int>> GetAdditionAnswer(List<List<int>> B)
        {
            var answer = new List<List<int>>();
            for (int i = 0; i < rowCnt; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < columnCnt; j++)
                {
                    row.Add(_matrixA[i][j] + B[i][j]);
                }
                answer.Add(row);
            }

            return answer;
        }
        
        private List<List<int>> GetDeterminantAnswer()
        {
            var result = new List<List<int>>();
            var A00 = _matrixD[0][0] * _matrixD[1][1] - _matrixD[0][1] * _matrixD[1][0];
            var rowAnswer = new List<int>() { A00 };
            result.Add(rowAnswer);
            return result;
        }
    }
}