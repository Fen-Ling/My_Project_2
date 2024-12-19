using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Animation : MonoBehaviour
{
    private Animator m_anim;
    public InputActionAsset inputActions;
    public Joystick joystick;
    private InputAction m_moveAction;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_moveAction = inputActions.FindAction("Player/Move");
    }

    void Update()
    {
        Vector2 moveInput = Vector2.zero;

        if (joystick != null)
        {
            moveInput = joystick.Direction;
        }

        if (moveInput == Vector2.zero)
        {
            moveInput = m_moveAction.ReadValue<Vector2>();
        }


        m_anim.SetBool("Forward", moveInput.y > 0);
        m_anim.SetBool("Backward", moveInput.y < 0);
        m_anim.SetBool("Left", moveInput.x < 0);
        m_anim.SetBool("Right", moveInput.x > 0);

        if (Keyboard.current.leftShiftKey.isPressed)
        {
            m_anim.SetTrigger("Sprint");
        }

        bool isAttackPressed = Mouse.current.leftButton.wasPressedThisFrame;
        m_anim.SetBool("Attack", isAttackPressed);


    }
}