using UnityEngine;

public class Attack_Player_Weapon : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        // Наносим урон, если объект – враг
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enimy_Damage>().TakeDamage(damage);
            
        }
    }
}