using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Animation : MonoBehaviour
{
    private Animator m_anim;
    public InputActionAsset inputActions;
    private InputAction m_moveAction;
    private bool isPlayerInRange = false;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_moveAction = inputActions.FindAction("Player/Move");
    }

    void Update()
    {
        Vector2 moveInput = m_moveAction.ReadValue<Vector2>();

        m_anim.SetBool("Forward", moveInput.y > 0);
        m_anim.SetBool("Backward", moveInput.y < 0);
        m_anim.SetBool("Left", moveInput.x < 0);
        m_anim.SetBool("Right", moveInput.x > 0);
        m_anim.SetBool("ForwardLeft", moveInput.y > 0 && moveInput.x < 0);
        m_anim.SetBool("ForwardRight", moveInput.y > 0 && moveInput.x > 0);
        m_anim.SetBool("BackwardLeft", moveInput.y < 0 && moveInput.x < 0);
        m_anim.SetBool("BackwardRight", moveInput.y < 0 && moveInput.x > 0);

        if (Keyboard.current.leftShiftKey.isPressed)
        {
            m_anim.SetTrigger("Sprint");
        }

        if (!isPlayerInRange)
        {
            bool isAttackPressed = Mouse.current.leftButton.wasPressedThisFrame;
            m_anim.SetBool("Attack", isAttackPressed);
        }
        else
        {
            m_anim.SetBool("Attack", false);
        }
    }

    public void SetPlayerInRange(bool value)
    {
        isPlayerInRange = value;
    }

}
