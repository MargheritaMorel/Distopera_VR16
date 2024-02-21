using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NPC : MonoBehaviour
{
    public Action OnButtonPressed;
    public bool isClicked = false;

    public UnityEvent evento;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Press()
    {

        if (!isClicked)
        {
            if (OnButtonPressed != null)
                OnButtonPressed();
            evento.Invoke();
            isClicked = true;
            
        }
        else
        {
           
           
            isClicked = false;
            
        }




    }
}
