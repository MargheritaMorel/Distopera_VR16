using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject loadingScreen;
    [SerializeField] CanvasGroup canvasGroupLoading;


    public SceneLoader.Scene currentScene;
    // [SerializeField] private SceneLoader.Scene Menu;
    // [SerializeField] private SceneLoader.Scene Game;
    // [SerializeField] private SceneLoader.Scene Loading;

    public GameObject menu;
    public GameObject tablet;
    public GameObject etichette;

    public GameObject player;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    //This function is called when the object becomes enabled and active to load the scene
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvasGroupLoading.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadScene("Theatre"));
        }


        // //Carica la scena del menu  all'avvio del gioco
        // if (currentScene.ToString() == "Menu")
        // {
        //     SceneLoader.Load(Loading);
        //     player.GetComponent<FirstPersonCharacterController>().enabled = false;
        // }

        // //Carica la scena del gioco durante la visualizzazione della schermata di caricamento
        // if (currentScene.ToString() == "Loading")
        // {
        //     SceneLoader.Load(Game);
        //     player.GetComponent<FirstPersonCharacterController>().enabled = false;
        // }
        


        //Disabilita il movimento del player quando il menu è attivo
        // if(menu.activeSelf == true)
        // {
        //     player.GetComponent<FirstPersonCharacterController>().enabled = false;
        // }
        // else
        // {
        //     player.GetComponent<FirstPersonCharacterController>().enabled = true;
        // }

        // //Disabilita il movimento del player quando il tablet è attivo
        // if(tablet.activeSelf == true)
        // {
        //     player.GetComponent<FirstPersonCharacterController>().enabled = false;
        // }
        // else
        // {
        //     player.GetComponent<FirstPersonCharacterController>().enabled = true;
        // }

        // //Disabilita il movimento del player quando le etichette sono attive
        // if (etichette.activeSelf == true)
        // {
        //     player.GetComponent<FirstPersonCharacterController>().enabled = false;
        // }
        // else
        // {
        //     player.GetComponent<FirstPersonCharacterController>().enabled = true;
        // }

        
    }

    IEnumerator LoadScene(string sceneName)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            yield return null;
        }

        StartCoroutine(LoadingScreenFadeOut(2f));
    }

    IEnumerator LoadingScreenFadeOut(float duration)
    {
        float timePassed = 0f;
        float startAlpha = canvasGroupLoading.alpha;

        while(timePassed < duration)
        {
            timePassed += Time.deltaTime;
            canvasGroupLoading.alpha = Mathf.Lerp(startAlpha, 0, timePassed / duration);
            yield return null;
        }

        loadingScreen.SetActive(false);
        canvasGroupLoading.alpha = 1f;
    }
}