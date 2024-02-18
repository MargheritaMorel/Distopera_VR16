using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;


public class DialogueManagerScript : MonoBehaviour
{
    [SerializeField] private EventReference WriteText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;

    void Start(){
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            AudioManager.instance.PlayOneShot(WriteText, this.transform.position);
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue(){
        Debug.Log("End of conversation.");
    }



}
