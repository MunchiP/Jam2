using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogo : MonoBehaviour
{

    [SerializeField] private string[] dialogueLines; // Lineas de dialogo a guardar
    [SerializeField] private GameObject dialoguePanel; // Referencia al panel
    [SerializeField] private TMP_Text dialogueText; // Referencia al texto

    private bool didDialogueStart;
    private int lineIndex;

    [SerializeField] private string finalSound = "KidScream";
    [SerializeField] private AudioSource audioSource;

    void Update()
    {
        Debug.Log("Script de dialogo");
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
            if (!didDialogueStart) // Verificación de que el dialogo no ha comenzado
            {
                StartDialogue();
            }
            // else if (dialogueText.text == dialogueLines[lineIndex])
            // {
            //     NextDiaogueLine();
            // }
        // }
    }

    private void StartDialogue()
    {
        Debug.Log("Comenzó StartDialogue");
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0; // cada vez que se inicia el dialogo se comienza en la linea 0 del index, osea - againt -
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (string linea in dialogueLines)
        {
            foreach (char item in linea)
            {
                dialogueText.text += item;
                yield return new WaitForSeconds(0.05f);
            }
            dialogueText.text += "\n" + "\n";
            yield return new WaitForSeconds(0.05f);
        }
  yield return StartCoroutine(PlaySoundChangeScene());
    }

    // void NextDiaogueLine()
    // {
    //     lineIndex++;
    //     if (lineIndex < dialogueLines.Length)
    //     {
    //         StartCoroutine(ShowLine());
    //     }  
    //     else
    //     {
    //         didDialogueStart = false;
    //         StartCoroutine(PlaySoundChangeScene());
    //     }
    // }

    private IEnumerator PlaySoundChangeScene()
    {
        AudioManager.Sound sound = AudioManager.Instance.GetSound(finalSound);

        if (sound != null && sound.clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(sound.clip);
            yield return new WaitForSeconds(sound.clip.length);
            Debug.Log("Reproduciendo sonido: " + finalSound);
        }

        SceneManager.LoadScene("Juego");
    }
}
