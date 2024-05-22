using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Player: MonoBehaviour
    {
        private int _hp = 3;
        private int _maxHp = 3;
        [SerializeField] private TaskDrawer taskDrawer;

        [FormerlySerializedAs("OnHpChanged")] public UnityEvent HpChanged;
        public UnityEvent CharacterDied;

        private void Awake()
        {
            taskDrawer.notRightAnswerGetted.AddListener(GetDamage);
        }

        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                HpChanged.Invoke();
                if (value == 0) CharacterDied.Invoke();
            }
        }

        public int MaxHp => _maxHp;

        public void GetDamage()
        {
            Hp--;
        }
    }
}