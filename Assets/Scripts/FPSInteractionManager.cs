﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;

    [SerializeField] private Image _target;

    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    private CharacterController _fpsController;
    private Vector3 _rayOrigin;

    private Grabbable _grabbedObject = null;

    [SerializeField] private List<SnapPoint> snapPoints;
    [SerializeField] private float snapRange = 2f;
    private OggettoScena _oggettoScena = null;

    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        if(_grabbedObject == null)
            CheckInteraction();

        if (_grabbedObject != null && Input.GetMouseButtonDown(0))
            Drop();

        UpdateUITarget();

        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {
        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            //Check if is interactable
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            if (_pointingInteractable)
            { 
                if(Input.GetMouseButtonDown(0))
                    _pointingInteractable.Interact(gameObject);
            }

            //Check if is grabbable
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            _oggettoScena = hit.transform.GetComponent<OggettoScena>();

            if (_grabbedObject == null && _pointingGrabbable)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    _pointingGrabbable.Grab(gameObject);
                    if (_pointingGrabbable.tag == "OggettoScena")
                        GrabOggettoScena(_pointingGrabbable, _oggettoScena);
                    else
                        Grab(_pointingGrabbable);
                }
                    
            }
        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractable = null;
            _pointingGrabbable = null;
        }
    }

    private void UpdateUITarget()
    {
        if (_pointingInteractable)
            _target.color = Color.green;
        else if (_pointingGrabbable)
            _target.color = Color.yellow;
        else
            _target.color = Color.red;
    }

    private void Drop()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;

        //controllo se oggetto grabbato è un oggetto che va sul palco , magari con tag "oggettoPalco"
        if (_grabbedObject.tag == "OggettoScena")
        {
            DropOggettoInScena(_grabbedObject, _oggettoScena);
        }
        _grabbedObject.Drop();

        _target.enabled = true;
        _grabbedObject = null;
    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;
        grabbable.transform.SetParent(_fpsCameraT);

        _target.enabled = false;
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }

    private void GrabOggettoScena(Grabbable grabbable, OggettoScena oggetto)
    {
        if (oggetto._isPlaced == true)
        {
            if (oggetto._snappoint.isUsed == true)
            {
                oggetto._snappoint.isUsed = false;
                oggetto._snappoint.gameObject.SetActive(true);
                oggetto._snappoint = null;
            }
            oggetto._isPlaced = false;
        }
        Grab(grabbable);
    }

    //si può pensare di portare fuori questa funzione dall FPS controller
    private void DropOggettoInScena(Grabbable grabbable, OggettoScena oggetto)
    {
        float closestDistance = -1;
        SnapPoint closestSnapPoint = null;

        //magari ci possono essere 4 posizioni prestabilite sul palco, quindi cerco quello più vicino al blocco
        foreach (SnapPoint snapPoint in snapPoints)
        {
            if (!snapPoint.isUsed)
            {
                float currentDistance = Vector3.Distance(grabbable.transform.localPosition, snapPoint.transform.localPosition);

                if (closestSnapPoint == null || currentDistance < closestDistance)
                {
                    closestSnapPoint = snapPoint;
                    closestDistance = currentDistance;
                }
            }
        }

        //snapRange è il valore entro il quale il drop risulta "corretto"
        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            grabbable.transform.localPosition = closestSnapPoint.transform.localPosition;
            oggetto._isPlaced = true;
            oggetto._snappoint = closestSnapPoint;
            oggetto._snappoint.isUsed = true;
            closestSnapPoint.gameObject.SetActive(false);

        }
            grabbable.Drop();
    }
}
