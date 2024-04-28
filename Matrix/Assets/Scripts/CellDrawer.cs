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
        // text.color = number % 2 == 0 ? Color.green : Color.blue;
        // switch (number) 
        // {
        //     case (number <= 5):
        //     {
        //         text.color = new Color(154, 205, 50, 0.2);
        //         break;
        //     }
        //     case (number <= 10):
        //     {
        //         text.color = new Color(154, 205, 50, 0.5);
        //         break;
        //     }
        //     case (number <= 50):
        //     {
        //         text.color = new Color(154, 205, 50, 0.8);
        //         break;
        //     }
        //     case (number <= 100):
        //     {
        //         text.color = new Color(154, 205, 50, 1);
        //         break;
        //     }
        // };

        // if (number <= 5) text.color = new Color(154, 205, 50, 0.2f);
        // else if (number <= 10) text.color = new Color(154, 205, 50, 0.5f);
        // else if (number <= 50) text.color = new Color(154, 205, 50, 0.8f);
        // else text.color = new Color(154, 205, 50, 1);
        
        if (number <= 5) text.color = Color.blue;
        else if (number <= 10) text.color = Color.cyan;
        else if (number <= 50) text.color = Color.magenta;
        else text.color = Color.red;
    }
}
