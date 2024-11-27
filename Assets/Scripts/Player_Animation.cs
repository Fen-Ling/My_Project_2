using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Animation : MonoBehaviour
{
    private Animator m_anim;
    public InputActionAsset inputActions;
    private InputAction m_moveAction;

    void Start()
    {
        m_moveAction = inputActions.FindAction("Player/Move");
        m_moveAction.Enable();
        m_anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_anim.SetBool("Forward", true);
        }
        else 
        {
            m_anim.SetBool("Forward", false);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_anim.SetBool("Backward", true);
        }
        else 
        {
            m_anim.SetBool("Backward", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_anim.SetBool("Left", true);
        }
        else 
        {
            m_anim.SetBool("Left", false);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_anim.SetBool("Right", true);
        }
        else 
        {
            m_anim.SetBool("Right", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_anim.SetTrigger("Sprint");
        }
    }
}
