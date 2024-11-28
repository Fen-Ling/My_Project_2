using UnityEngine;
using UnityEngine.InputSystem;

public class II_Anima_Controller : MonoBehaviour
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
            m_anim.SetBool("UpRun", true);
        }
        else 
        {
            m_anim.SetBool("UpRun", false);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_anim.SetBool("DownRun", true);
        }
        else 
        {
            m_anim.SetBool("DownRun", false);
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_anim.SetTrigger("Attack");
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            m_anim.SetTrigger("Attack2");
        }
    }
}
