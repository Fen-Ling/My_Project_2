using UnityEngine;
using UnityEngine.UI;

public class Player_HP : MonoBehaviour
{
    public Slider healthBar;
    private Animator animator;
    public float MaxHP;
    private float healHP;
    private float HP;

    public void Start()
    {
        // MaxHP = 
        animator = GetComponent<Animator>();
        HP = MaxHP;
        healthBar.maxValue = HP;
        healthBar.value = HP;
        healHP = MaxHP / 1000f;
    }

    private void FixedUpdate()
    {
        healthBar.value = HP;
        Heal(healHP);
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