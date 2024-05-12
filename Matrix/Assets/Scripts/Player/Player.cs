using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Player: MonoBehaviour
    {
        private int _hp = 3;
        private int _maxHp = 3;
        [SerializeField] private TaskDrawer taskDrawer;

        public UnityEvent OnHpChanged;
        public UnityEvent CharacterDied;

        private void Awake()
        {
            taskDrawer.NotOkAnswerGetted.AddListener(GetDamage);
        }

        public int Hp
        {
            get => _hp;
            set
            {
                if (value == 0) CharacterDied.Invoke();
            }
        }

        public int MaxHp => _maxHp;

        public void GetDamage()
        {
            _hp--;
        }
    }
}