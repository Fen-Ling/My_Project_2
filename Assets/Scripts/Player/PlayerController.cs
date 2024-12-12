using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed;
    public InputActionAsset inputActions;
    private CharacterController m_characterController;
    private Animator animator;
    public float MaxHP = 200f;
    public float healHP = 0.5f;
    private float HP;
    public Slider healthBar;
    private InputAction m_lookAction;
    private InputAction m_attackAction;
    private Vector3 m_Rotation;
    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        m_lookAction = inputActions.FindAction("Player/Look");
        m_attackAction = inputActions.FindAction("Player/Attack");

        m_lookAction.Enable();
        m_attackAction.Enable();

        HP = MaxHP;
        healthBar.maxValue = HP;
        healthBar.value = HP;
    }

    public void Update()
    {
        healthBar.value = HP;
        Vector2 look = m_lookAction.ReadValue<Vector2>();
        Look(look);
    }
    private void FixedUpdate()
    {
        Heal(healHP);
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;

        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, 0, 0);
        transform.localEulerAngles = m_Rotation;
    }

    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            Destroy(gameObject, 5f);

        }
        else
        {
            animator.SetTrigger("Damage");

        }
    }

    public void Heal(float HealAmount)
    {
        HP += HealAmount; // Увеличиваем текущее здоровье
        HP = Mathf.Clamp(HP, 0, MaxHP);
    }
}