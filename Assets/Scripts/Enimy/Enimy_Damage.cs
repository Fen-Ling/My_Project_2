using UnityEngine;
using UnityEngine.UI;

public class Enimy_Damage : MonoBehaviour
{
    public float MaxHP = 100f;
    public float healing;
    public float CorHP;
    public float Enimy_EXP;
    public Slider healthBar;
    private Animator animator;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        CorHP = MaxHP;
        healing = MaxHP / 1000;
        healthBar.maxValue = CorHP;
        healthBar.value = CorHP;
        Enimy_EXP = MaxHP /10;
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
            player.GetComponent<Player_Lvl>().Experience(Enimy_EXP);
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(gameObject, 1f);

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
