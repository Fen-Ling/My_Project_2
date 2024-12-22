using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed;
    public InputActionAsset inputActions;
    public Slider healthBar;
    private Animator animator;
    public float MaxHP = 200f;
    private float healHP;
    private float HP;

    private InputAction m_lookAction;
    private Vector3 m_Rotation;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        m_lookAction = inputActions.FindAction("Player/Look");
        m_lookAction.Enable();

        HP = MaxHP;
        healthBar.maxValue = HP;
        healthBar.value = HP;
        healHP = MaxHP / 1000;
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
        HP += HealAmount;
        HP = Mathf.Clamp(HP, 0, MaxHP);
    }
}