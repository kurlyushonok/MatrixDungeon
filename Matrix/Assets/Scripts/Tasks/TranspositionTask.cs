using DefaultNamespace.Extensions;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tasks
{
	[CreateAssetMenu(fileName = "BaseTranspositionTask", menuName = "Tasks/TranspositionTask", order = 50)]
	public class TranspositionTask : BaseTask
    {
		[SerializeField] private int maxValue;
		[SerializeField] private int minValue;
		[SerializeField] private int rowCnt;
		[SerializeField] private int columnCnt;
		[SerializeField] private TMP_Text textPrefab;

		private List<List<int>> _matrix;

		protected override void GenerateTask()
		{
			Clear();
			_matrix = MatrixGenerator.GetMatrix(minValue, maxValue, rowCnt, columnCnt);
			var matrixDrawer = GenerateMatrix(_matrix);

			var instance = Instantiate(textPrefab, _layoutGroup.transform);
			instance.text = "=";
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
					row.Add(_matrix[j][i]);
				}
				answer.Add(row);
			}

			return answer;
		}
	}
}