using UnityEngine;

public class Attack_Player_Weapon : MonoBehaviour
{
    public int damage = 10;
    public AudioClip audioSwowd;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;

    private void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioSwowd;
        hitAudioSource.volume = volume;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Наносим урон, если объект – враг
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy_Damage>().TakeDamage(damage);
            hitAudioSource.Play();
        }
    }
}