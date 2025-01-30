using UnityEngine;
using UnityEngine.UI;

public class Player_HP : MonoBehaviour
{
    public Image healthBar;
    private Animator animator;
    public GameOver_UI gameOver_State;
    public float MaxHP = 200f;
    private float healHP;
    public float HP;

    public void Start()
    {
        MaxHP = PlayerDataManager.playerData.MaxHP;
        animator = GetComponent<Animator>();
        HP = MaxHP;
        UpdateHealthBar();
        healHP = MaxHP / 1000f;
    }

    private void FixedUpdate()
    {
        Heal(healHP);
        UpdateHealthBar();
    }
    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            gameOver_State.gameObject.SetActive(true);
            Destroy(gameObject, 2f);
            
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

    private void UpdateHealthBar()
    {
        float fillAmount = HP / MaxHP;
        healthBar.fillAmount = fillAmount;
    }
}
