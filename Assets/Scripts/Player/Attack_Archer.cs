using UnityEngine;

public class Attack_Archer : MonoBehaviour
{
    public GameObject Arrow_Prefab;
    public AudioClip audioArrow;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;
    public Transform spawnPoint;
    private GameObject enemy;

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
        arrow.transform.localScale *= size;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 launchDirection;
            rb.mass = Mathf.Pow(size, 2);
            if (enemy != null)
            {
                Vector3 targetPosition = enemy.transform.position;
                targetPosition.y += 0.3f; // Поднимаем на 1 единицу

                // Вычисляем направление к врагу
                launchDirection = (targetPosition - spawnPoint.position).normalized;
            }
            else
            {
                // Если врага нет, стрела летит вперед
                launchDirection = spawnPoint.forward;
            }
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
        Fire();
        hitAudioSource.Play();
    }
}

