using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellDrawer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void Init(int number)
    {
        text.text = number.ToString();
        text.color = number % 2 == 0 ? Color.red : Color.blue;
    }
}
