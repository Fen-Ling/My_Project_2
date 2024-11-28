using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Animation : MonoBehaviour
{
    private Animator m_anim;
    private InputAction m_moveAction;

    void Start()
    {
        m_moveAction = new InputAction("Move", InputActionType.Value, "<Gamepad>/leftStick");
        m_moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        m_moveAction.Enable();

        m_anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveInput = m_moveAction.ReadValue<Vector2>();

        // // Установка анимационных параметров движения
        // m_anim.SetBool("Moving", moveInput.magnitude > 0);

        // Установка направления движения
        m_anim.SetBool("Forward", moveInput.y > 0);
        m_anim.SetBool("Backward", moveInput.y < 0);
        m_anim.SetBool("Left", moveInput.x < 0);
        m_anim.SetBool("Right", moveInput.x > 0);

        // Параметры анимации спринта
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            m_anim.SetTrigger("Sprint");
        }

        // Параметр атаки
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            m_anim.SetTrigger("Attack");
        }
    }
}