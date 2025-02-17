using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueUIManager;
    public InputActionAsset inputActions;
    private InputAction m_questAction;
    private bool isPlayerInRange = false;
    
    private void Awake()
    {
        dialogueUIManager = GameObject.FindGameObjectWithTag("QuestManager");
        m_questAction = inputActions.FindAction("UI/NPSTalk");
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueUIManager.GetComponent<QuestManager>().ShowTalkPrompt();

            Player_Animation playerAnimation = other.GetComponent<Player_Animation>();
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerAnimation != null)
            {
                playerAnimation.SetPlayerInRange(true);
                playerController.SetPlayerInRange(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueUIManager.GetComponent<QuestManager>().HideTalkPrompt();

            Player_Animation playerAnimation = other.GetComponent<Player_Animation>();
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerAnimation != null)
            {
                playerAnimation.SetPlayerInRange(false);
                playerController.SetPlayerInRange(false);
            }
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
        dialogueUIManager.GetComponent<QuestManager>().ShowQuestUI(); // Показываем UI с описанием квеста
    }
}