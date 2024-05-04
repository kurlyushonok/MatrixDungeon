using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellDrawer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public virtual int Value => int.Parse(text.text.ToString());

    public virtual void Init(int number)
    {
        text.text = number.ToString();
        text.color = Color.black;
    }
}
