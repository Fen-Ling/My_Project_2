using UnityEngine;
using UnityEngine.UI;

public class Enimy_Sctipt : MonoBehaviour
{
    private int HP = 100;
    public Animator a_animator;
    public Slider a_healthBar;

    void Update()
    {
        a_healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            a_animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            a_healthBar.gameObject.SetActive(false);
            gameObject.SetActive(false);

        }
        else
        {
            a_animator.SetTrigger("Damage");
            
        }
    }
}
