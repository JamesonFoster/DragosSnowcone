using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public DialogGraph lines;


    public DialogSegment activeSegment;
    public float textSpeed;

    private int index;


    //public PlayerController pc;

    public bool textActive = false;
    public UnityEvent EndDialogueEvent;

    public string[] dialogText;
    public GameObject questGiver;

    //public NPC npc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (EndDialogueEvent == null)
        {
            EndDialogueEvent = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && textActive == true)
        {
            Debug.Log("should skip line");
            LineSkip();
        }

    }

    public void startDialogue()
    {
        Time.timeScale = 0f;
        Debug.Log("Start Text");
        foreach (DialogSegment node in lines.nodes)
        {
            if (!node.GetInputPort("input").IsConnected)
            {
                UpdateDialog(node);
            }
        }
        TextBoxManager.Instance.portrait.sprite = activeSegment.portrait;
        textActive = true;

        TextBoxManager.Instance.textComponent.text = string.Empty;
        index = 0;

        
    }


    public void LineSkip()
    {

        NextNode();
    }


    public void NextLine()
    {
        index++;
        TextBoxManager.Instance.textComponent.text = string.Empty;
        
    }

    public void NextNode()
    {
        
            if (activeSegment.GetPort("output").IsConnected)
            {
                UpdateDialog(activeSegment.GetPort("output").Connection.node as DialogSegment);
                TextBoxManager.Instance.textComponent.text = string.Empty;
                
            }
            else
            {
                EndDialogue();
            }

        
    }

    

    public void EndDialogue()
    {
        Debug.Log("End here");
        foreach (Transform child in TextBoxManager.Instance.buttonParent)
        {
            Destroy(child.gameObject);
        }
        textActive = false;
        TextBoxManager.Instance.nameTextObj.SetActive(false);
        TextBoxManager.Instance.Objportrait.SetActive(false);
        TextBoxManager.Instance.textComponent.text = string.Empty;
        TextBoxManager.Instance.DialogPanel.SetActive(false);
        TextBoxManager.Instance.NoTalk = false;
        Time.timeScale = 1f;
        EndDialogueEvent.Invoke();
    }

    private void UpdateDialog(DialogSegment newSegment)
    {
        index = 0;
        activeSegment = newSegment;
        
        
        TextBoxManager.Instance.portrait.sprite = activeSegment.portrait;
        foreach (Transform child in TextBoxManager.Instance.buttonParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetDialogGraph(DialogGraph graph)
    {
        lines = graph;
    }
}
