using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class AmountOfTasksDrawer: MonoBehaviour
    {
        [SerializeField] private TMP_Text textField;
        [SerializeField] private TaskDrawer taskDrawer;
        private int neededAmoundsOfTasks = 3;

        public void Awake()
        {
            taskDrawer.amountOfTasksChanged.AddListener(OnTasksChanged);
            OnTasksChanged();
        }

        private void OnTasksChanged()
        {
            textField.text = $"Количество решенных заданий: {taskDrawer.AmountOfTasks} / {neededAmoundsOfTasks}";
        }
    }
}