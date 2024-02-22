using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestoTemporaneo : MonoBehaviour
{
    public float TimeAmount;
    public float currentTime;
    [SerializeField] private Canvas _testoAscomparsa;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = TimeAmount;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            if (_testoAscomparsa.isActiveAndEnabled)
            {
               
                _testoAscomparsa.gameObject.SetActive(false);
            }
            else
            {
                _testoAscomparsa.gameObject.SetActive(true);
            }
            currentTime = TimeAmount;
        }
    }
}
