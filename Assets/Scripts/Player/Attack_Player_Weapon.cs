using UnityEngine;

public class Player_Sword : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        // Наносим урон, если объект – враг
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy_Damage>().TakeDamage(damage);
            
        }
    }
}