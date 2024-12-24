using UnityEngine;
using UnityEngine.UI;

public class Enimy_Damage : MonoBehaviour
{
    public float MaxHP = 100f;
    public float healing;
    public float CorHP;
    public Slider healthBar;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        CorHP = MaxHP;
        healing = MaxHP/1000;
        healthBar.maxValue = CorHP;
        healthBar.value = CorHP;
    }
    private void FixedUpdate()
    {
        healthBar.value = CorHP;
        Heal(healing);

    }
    public void TakeDamage(int damageAmount)
    {
        CorHP -= damageAmount;
        if (CorHP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(gameObject, 3f);

        }
        else
        {
            animator.SetTrigger("Damage");

        }
    }

    public void Heal(float HealAmount)
    {
        CorHP += HealAmount;
        CorHP = Mathf.Clamp(CorHP, 0, MaxHP); // Ограничиваем здоровье в пределах 0 и MaxHP
    }
}
