using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class Presa : MonoBehaviour
{
    public Action OnButtonPressed;
    [SerializeField] private GameObject _faro;
    private bool isClicked = false;

    public UnityEvent evento;
    public UnityEvent evento1;


    void Start()
    {


    }

    public void Press()
    {

        if (!isClicked)
        {
            evento.Invoke();
            isClicked = true;
            _faro.SetActive(true);
        }
        else
        {
            evento1.Invoke();
            isClicked = false;
            _faro.SetActive(false);
        }




    }
}
