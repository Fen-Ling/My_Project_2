using UnityEngine;

public class Attack_Mage : MonoBehaviour
{
    public GameObject Prefab_Magic;
    public Transform spawnPoint;
    public AudioClip audioMagic;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;
    
    private void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioMagic;
        hitAudioSource.volume = volume;
    }
    private void Fire()
    {
        if (spawnPoint == null)
    {
        return;
    }
        var newProjectile = Instantiate(Prefab_Magic);
        newProjectile.transform.position = spawnPoint.position;
        newProjectile.transform.rotation = spawnPoint.rotation;
        const int size = 1;
        newProjectile.transform.localScale *= size;

        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = Mathf.Pow(size, 2);
            rb.AddForce(spawnPoint.forward * 20f, ForceMode.Impulse);
        }
    }
    public void OnAttackAnimationComplete()
    {
        Fire(); // Делаем выстрел после завершения анимации, добавить событие в анимацию
        hitAudioSource.Play();
    }
}

