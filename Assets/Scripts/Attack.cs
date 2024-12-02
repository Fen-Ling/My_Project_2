using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        // Наносим урон, если объект – враг
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enimy_AI>().TakeDamage(damage);
        }
    }
}