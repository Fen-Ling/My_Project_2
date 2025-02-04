using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialogue : MonoBehaviour
{
    public string dialogueText;
    public QuestManager dialogueUIManager;
    public InputActionAsset inputActions;
    private InputAction m_questAction;

    private bool isPlayerInRange = false;

    private void Awake()
    {
        m_questAction = inputActions.FindAction("UI/NPSTalk");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueUIManager.ShowTalkPrompt(); // Показываем приглашение к разговору
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueUIManager.HideTalkPrompt(); // Скрываем приглашение к разговору
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInRange && m_questAction.IsPressed())
        {
            ShowDialogue();
        }
    }

    private void ShowDialogue()
    {
        dialogueUIManager.ShowQuestUI(dialogueText); // Показываем UI с описанием квеста
    }
}