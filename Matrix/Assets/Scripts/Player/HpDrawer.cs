using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class HpDrawer: MonoBehaviour
    {
        [SerializeField] private TMP_Text textField;
        [SerializeField] private TaskDrawer taskDrawer;
        [SerializeField] private Player _player;

        public void Awake()
        {
            _player.HpChanged.AddListener(OnHpChanged);
            OnHpChanged();
        }

        private void OnHpChanged()
        {
            textField.text = $"{_player.Hp}";
        }
    }
}