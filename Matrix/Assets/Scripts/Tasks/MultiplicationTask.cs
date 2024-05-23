using DefaultNamespace.Extensions;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tasks
{
	[CreateAssetMenu(fileName = "BaseMultiplicationTask", menuName = "Tasks/MultiplicationTask", order = 50)]
	public class MultiplicationTask : BaseTask
    {
		[SerializeField] private int maxValue;
		[SerializeField] private int minValue;
		[SerializeField] private int rowCnt1;
		[SerializeField] private int columnCnt1;
		[SerializeField] private int rowCnt2;
		[SerializeField] private int columnCnt2;
		[SerializeField] private TMP_Text textPrefab;

		private List<List<int>> _matrix1;
		private List<List<int>> _matrix2;

		protected override void GenerateTask()
		{
			Clear();
			_matrix1 = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt1, columnCnt1);
			_matrix2 = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt2, columnCnt2);
			var matrix1Drawer = GenerateMatrix(_matrix1);
			var instance = Instantiate(textPrefab, _layoutGroup.transform);
			instance.text = "*";
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
			for (int i = 0; i < rowCnt1; i++)//3
			{
				var row = new List<int>();
				for (int j = 0; j < columnCnt2; j++)//1
				{
					var cell = 0;
					for (int k = 0; k < rowCnt2; k++)//3
					{
						cell += _matrix1[i][k] * _matrix2[k][j];
					}
					row.Add(cell);
				}
				answer.Add(row);
			}

			return answer;
		}
	}
}