using UnityEngine;

public class Player_Arrow : MonoBehaviour
{
    public int damage = 10; // Урон, который будет нанесен врагу
    public float lifetime = 3f; // Время жизни снаряда
    public AudioClip audioArrow;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;


    private void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioArrow;
        hitAudioSource.volume = volume;

        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy_Damage>().TakeDamage(damage);
            hitAudioSource.Play();
            Destroy(gameObject);
        }

    }
}