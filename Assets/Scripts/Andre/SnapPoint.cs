using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    [SerializeField] private GameObject _snapPoint;
    public bool isUsed = false;
    public bool isPlaced = false;
    //private Vector3 _originalPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisabilitaSnap()
    {   //è usato
        _snapPoint.SetActive(false);
        isUsed = true;
    }

    public void AbilitaSnap()
    {
        //non è più usato, quindi posso riusarlo
        _snapPoint.SetActive(true);
        isUsed = false;
    }

    public void Pieno()
    {   //ci sta un oggetto
        isPlaced = true;
    }

    public void Vuoto()
    {
        isPlaced = false;
    }
}
