using UnityEngine;

public class Attack_Enemy_Arrow : MonoBehaviour
{
    public int damage = 10;
    public float lifetime = 3f;
    public AudioClip audioAttack;
    private AudioSource hitAudioSource;
    private void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioAttack;
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player_HP>().TakeDamage(damage);
            hitAudioSource.Play();
            Destroy(gameObject);
        }

    }
}
