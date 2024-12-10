using UnityEngine;
using UnityEngine.UI;

public class Enimy_Damage : MonoBehaviour
{
    public int MaxHP = 100;
    public int healing = 1;
    private int CorHP;
    public Slider healthBar;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        CorHP = MaxHP;
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
            // gameObject.SetActive(false);
            Destroy(gameObject, 3f);

        }
        else
        {
            animator.SetTrigger("Damage");

        }
    }

    public void Heal(int HealAmount)
    {
        CorHP += HealAmount;
        CorHP = Mathf.Clamp(CorHP, 0, MaxHP); // Ограничиваем здоровье в пределах 0 и MaxHP
    }
}
