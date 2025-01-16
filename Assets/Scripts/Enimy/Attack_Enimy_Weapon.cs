using UnityEngine;

public class Attack_Enimy_Weapon : MonoBehaviour
{
    public int damage = 10;
    public AudioClip audioAttack;
    private AudioSource hitAudioSource;
    private void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioAttack;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Наносим урон, если объект – враг
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player_HP>().TakeDamage(damage);
            hitAudioSource.Play();
        }
    }
}