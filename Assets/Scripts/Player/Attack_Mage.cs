using UnityEngine;

public class Attack_Mage : MonoBehaviour
{
    public GameObject Prefab_Magic;
    public Transform spawnPoint;
    public AudioClip audioMagic;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;
    private GameObject enemy;

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
            Vector3 launchDirection;

            // Если враг найден, направляем снаряд к врагу
            if (enemy != null)
            {
                Vector3 targetPosition = enemy.transform.position;
                targetPosition.y += 0.3f;
                launchDirection = (targetPosition - spawnPoint.position).normalized;
            }
            else
            {
                // Если врага нет, направляем снаряд вперед
                launchDirection = spawnPoint.forward;
            }

            // Добавляем силу к снаряду
            rb.AddForce(launchDirection * 20f, ForceMode.Impulse);
        }
    }
    public void OnAttackAnimationComplete()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                enemy = hit.collider.gameObject; // Сохраняем врага
                 Debug.Log("Enemy");
            }
        }
        Fire(); // Делаем выстрел после завершения анимации, добавить событие в анимацию
        hitAudioSource.Play();
    }
}

