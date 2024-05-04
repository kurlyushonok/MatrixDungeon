using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnswerCellDrawer: CellDrawer
    {
        [SerializeField] private TMP_InputField _inputField;

        public override int Value => int.Parse(_inputField.text.ToString());
        
        public override void Init(int number)
        {
            
        }
    }
}