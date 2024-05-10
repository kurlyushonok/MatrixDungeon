using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _phrases;
    [SerializeField] private Transform position;
    private TMP_Text _currentPhrase;
    private int _cntPhrases;
    private int _numberOfPhrase;
    private int _numberOfScene = 1;
    
    private void Start()
    {
        _cntPhrases = _phrases.Length;
    }

    public void ShowPhrase()
    {
        if (_currentPhrase != null) Destroy(_currentPhrase.gameObject);
        if (_numberOfPhrase == _cntPhrases)
        {
            LoadScene(_numberOfScene);
            _numberOfScene++;
        }
        else
        {
            _currentPhrase = Instantiate(_phrases[_numberOfPhrase], position);
            _numberOfPhrase++;
        }
    }

    private void LoadScene(int number)
    {
        SceneManager.LoadScene(number);
    }
}
