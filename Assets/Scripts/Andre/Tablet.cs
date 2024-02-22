using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tablet : MonoBehaviour
{
    [SerializeField] private GameObject _tablet;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Canvas _canvas;
    public bool isOpen = false;
    public bool isTaken = false;
    public float oggettoScenaPiazzato;
    public float luceAccesa;
    private float vestitoScelto;
    private bool oggettiCompleto = false;
    private bool luciAccese = false;




    // Start is called before the first frame update
    void Start()
    {

    }

    public void CheckOggettiScena()
    {
        if(oggettoScenaPiazzato == 1){
            _text.text = "Task SCENOGRAFIA 1/4";
        }
        if(oggettoScenaPiazzato == 2){
            _text.text = "Task SCENOGRAFIA 2/4";
        }
        if(oggettoScenaPiazzato == 3){
            _text.text = "Task SCENOGRAFIA 3/4";
        }
        if (oggettoScenaPiazzato == 4)
        {
            oggettiCompleto = true;
             _text.text = "TASK COMPLETATO 4/4";
            _toggle.isOn = true;
        }
    }

    public void OpenCanvas()
    {
        _canvas.gameObject.SetActive(true);
        isOpen = true;
        
    }

    public void CloseCanvas()
    {
        _canvas.gameObject.SetActive(false);
        isOpen = false;
    }

    public void CheckLuciAccese()
    {
        if (luceAccesa == 3) luciAccese = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
