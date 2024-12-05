using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;

public class Enimy_Damage : MonoBehaviour
{
    private int HP = 100;
    public Slider healthBar;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        healthBar.value = HP;
    }
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else
        {
            animator.SetTrigger("Damage");

        }
    }
}
