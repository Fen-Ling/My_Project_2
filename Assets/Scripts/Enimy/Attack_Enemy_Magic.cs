using UnityEngine;

public class Attack_Enemy_Magic : MonoBehaviour
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
            other.GetComponent<Player_HP>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
