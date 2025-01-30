using UnityEngine;
using UnityEngine.UI;

public class Attack_Mage : MonoBehaviour
{
    public GameObject[] Prefab_Magic;
    public Transform spawnPoint;
    public AudioClip audioMagic;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;
    private GameObject enemy;
    private int magicIndex = 0;

    private void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioMagic;
        hitAudioSource.volume = volume;
    }

    private void Fire(GameObject magicPrefab)
    {
        if (spawnPoint == null || magicPrefab == null)
        {
            return;
        }
        var newProjectile = Instantiate(magicPrefab);
        newProjectile.transform.position = spawnPoint.position;
        newProjectile.transform.rotation = spawnPoint.rotation;
        const int size = 1;
        newProjectile.transform.localScale *= size;

        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = Mathf.Pow(size, 2);
            Vector3 launchDirection;

            if (enemy != null)
            {
                Vector3 targetPosition = enemy.transform.position;
                targetPosition.y += 0.3f;
                launchDirection = (targetPosition - spawnPoint.position).normalized;
            }
            else
            {
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
        AttackWithMagic(magicIndex);
    }

    public void AttackWithMagic(int magicIndex)
    {
        if (magicIndex < 0 || magicIndex >= Prefab_Magic.Length)
        {
            Debug.LogError("Invalid magic index!");
            return;
        }

        this.magicIndex = magicIndex;
        Fire(Prefab_Magic[magicIndex]);
        if (hitAudioSource.clip != null)
        {
            hitAudioSource.Play();
        }
    }

    public void SetMagicIndex (int index)
    {
        if (index < 0 || index >= Prefab_Magic.Length)
        {
            Debug.LogError("Invalid magic index!");
            return;
        }

        magicIndex = index;
        Debug.Log("Magic index set to: " + magicIndex);
    }
}

