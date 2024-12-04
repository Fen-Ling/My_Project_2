using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Attack_Archer : MonoBehaviour
{
    public float burstSpeed;
    public GameObject projectile;
    public Transform spawnPoint;
    public Animator animator;

    private SimpleControls m_Controls;
    private bool m_Charging;

    public void Awake()
    {
        m_Controls = new SimpleControls();

        m_Controls.gameplay.fire.performed +=
            ctx =>
        {
            if (ctx.interaction is SlowTapInteraction)
            {
                StartCoroutine(BurstFire((int)(ctx.duration * burstSpeed)));
            }
            else
            {
                // Начинаем анимацию атаки
                animator.SetTrigger("Attack"); // Предполагается, что у вас есть триггер "Attack" в Animator
            }
            m_Charging = false;
        };
        m_Controls.gameplay.fire.started +=
            ctx =>
        {
            if (ctx.interaction is SlowTapInteraction)
                m_Charging = true;
        };
        m_Controls.gameplay.fire.canceled +=
            ctx =>
        {
            m_Charging = false;
        };
    }

    public void OnEnable()
    {
        m_Controls.Enable();
    }

    public void OnDisable()
    {
        m_Controls.Disable();
    }
    public void OnGUI()
    {
        if (m_Charging)
            GUI.Label(new Rect(100, 100, 200, 100), "Charging...");
    }

    private IEnumerator BurstFire(int burstAmount)
    {
        for (var i = 0; i < burstAmount; ++i)
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void Fire()
    {
        if (spawnPoint == null)
    {
        Debug.LogError("Spawn point is not assigned.");
        return; // Прерываем выполнение, если spawnPoint не назначен
    }
        GameObject arrow = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
              
        const int size = 1;
        

        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = Mathf.Pow(size, 1);
            rb.AddForce(spawnPoint.forward * 20f, ForceMode.Impulse);
        }

        MeshRenderer meshRenderer = arrow.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
        }

    }
    public void OnAttackAnimationComplete()
    {
        Fire(); // Делаем выстрел после завершения анимации
    }
}

