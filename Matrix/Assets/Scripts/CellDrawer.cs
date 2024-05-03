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
        if (number <= 5) text.color = new Color32(154, 205, 50, (byte)(0.2f * 255));
        else if (number <= 10) text.color = new Color32(154, 205, 50, (byte)(0.5f * 255));
        else if (number <= 50) text.color = new Color32(154, 205, 50, (byte)(0.8f * 255));
        else text.color = new Color32(154, 205, 50, 255);
        
        // if (number <= 5) text.color = Color.blue;
        // else if (number <= 10) text.color = Color.cyan;
        // else if (number <= 50) text.color = Color.magenta;
        // else text.color = Color.red;
    }
}
