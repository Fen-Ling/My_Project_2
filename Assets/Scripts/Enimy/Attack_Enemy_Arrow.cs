using UnityEngine;

public class Attack_Enemy_Arrow : MonoBehaviour
{
    public int damage = 10;
    public float lifetime = 3f;
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
