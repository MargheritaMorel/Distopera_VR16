using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarettoTurnOnButton : MonoBehaviour
{

    [SerializeField] private Button3D _turnLightButton;
    [SerializeField] private GameObject _faro;
    //public GameObject txtToDisplay;

    private FPSInteractionManager _fpscheck;


    void Start()
    {
        //txtToDisplay.SetActive(false);
        _turnLightButton.OnButtonPressed += OnLightOpenButtonPressed;
    }

    private void OnLightOpenButtonPressed()
    {
        _faro.SetActive(!_faro.activeSelf);
    }

    /*private void OnTriggerEnter(Collider Other)
    {

        if (Other.gameObject.tag == "Player")
        {
            txtToDisplay.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        txtToDisplay.SetActive(false);
    }*/
}
