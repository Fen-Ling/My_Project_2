using UnityEngine;

public class Magic_Ball : MonoBehaviour
{
    public int damage = 10; // Урон, который будет нанесен врагу
    public float lifetime = 3f; // Время жизни снаряда
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enimy_AI>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
