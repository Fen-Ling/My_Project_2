using UnityEngine;

public class Attack_Archer : MonoBehaviour
{
    public GameObject Arrow_Prefab;
    public AudioClip audioArrow;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;
    public Transform spawnPoint;

    private void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioArrow;
        hitAudioSource.volume = volume;
    }

    private void Fire()
    {
        if (spawnPoint == null)
        {
            return;
        }
        GameObject arrow = Instantiate(Arrow_Prefab, spawnPoint.position, spawnPoint.rotation);

        const int size = 1;

        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = Mathf.Pow(size, 2);
            rb.AddForce(spawnPoint.forward * 20f, ForceMode.Impulse);
        }
    }
    public void OnAttackAnimationComplete()
    {
        Fire();
        hitAudioSource.Play();
    }
}

