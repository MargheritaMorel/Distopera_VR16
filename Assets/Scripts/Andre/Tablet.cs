using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    [SerializeField] private GameObject _tablet;
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
        if (oggettoScenaPiazzato == 3)
        {
            oggettiCompleto = true;
        }
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
