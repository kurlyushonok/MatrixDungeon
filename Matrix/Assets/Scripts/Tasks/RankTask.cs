using DefaultNamespace.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Tasks
{
	[CreateAssetMenu(fileName = "BaseRankTask", menuName = "Tasks/RankTask", order = 50)]
	public class RankTask : BaseTask
	{
		[SerializeField] private int maxValue;
		[SerializeField] private int minValue;
		[SerializeField] private int rowCnt;
		[SerializeField] private int columnCnt;
		[SerializeField] private TMP_Text textPrefab;

		private int readyColumnsCount;
		private int dependentVariablesCount;
		private int[][] _mat;
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
			_mat = new int[rowCnt][];
			for (int i = 0; i < rowCnt; i++)
			{
				_mat[i] = new int[columnCnt];
				for (int j = 0; j < columnCnt; j++)
				{
					_mat[i][j] = _matrix[i][j];
				}
			}

			while (readyColumnsCount < columnCnt)
				PrepareColumn(dependentVariablesCount, readyColumnsCount);

			var rank = rowCnt;

			for (int lineIndex = 0; lineIndex < rowCnt; lineIndex++)
				if (IsNullLine(lineIndex))
					rank--;

			var result = new List<List<int>>();
			var rowAnswer = new List<int>() { rowCnt };
			result.Add(rowAnswer);
			return result;
		}

		private void MultiplayLine(int lineNumber, int factor)
		{
			_mat[lineNumber] = _mat[lineNumber]
			  .Select(elem => elem * factor)
			  .ToArray();
		}

		private void AddMultiplayLine(int toIndex, int fromIndex, int factor)
		{
			for (int i = 0; i < columnCnt; i++)
			{
				_mat[toIndex][i] += _mat[fromIndex][i] * factor;
				if (Math.Abs(_mat[toIndex][i]) < 1e-6)
					_mat[toIndex][i] = 0;
			}
		}

		private void RearrangeLines(int firstIndex, int secondIndex)
		{
			if (firstIndex < 0 | firstIndex > rowCnt - 1 | secondIndex < 0 | secondIndex > rowCnt - 1) return;
			(_mat[firstIndex], _mat[secondIndex]) = (_mat[secondIndex], _mat[firstIndex]);
		}

		private bool IsNullLine(int lineIndex) => _mat[lineIndex].All(elem => elem == 0);

		private void PrepareColumn(int lineIndex, int columnIndex)
		{
			if (readyColumnsCount == columnCnt) return;
			if (lineIndex >= rowCnt)
			{
				readyColumnsCount++;
				return;
			}

			var elemDivision = _mat[lineIndex][columnIndex];
			if (elemDivision == 0)
			{
				PrepareColumn(lineIndex + 1, columnIndex);
				return;
			}

			MultiplayLine(lineIndex, 1 / elemDivision);
			for (int i = 0; i < rowCnt; i++)
			{
				if (i == lineIndex) continue;
				AddMultiplayLine(i, lineIndex, -_mat[i][columnIndex]);
			}

			if (lineIndex != readyColumnsCount)
				RearrangeLines(lineIndex, readyColumnsCount);
			readyColumnsCount++;
			dependentVariablesCount++;
		}
	}
}
