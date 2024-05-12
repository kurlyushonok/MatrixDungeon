using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnswerCellDrawer: CellDrawer
    {
        [SerializeField] private TMP_InputField _inputField;

		public override int Value
		{
			get
			{
				if (_inputField.text.ToString() != "")
					return int.Parse(_inputField.text.ToString());
				else return 0;
			}
		}

		public override void Init(int number)
        {
            
        }
    }
}