using UnityEngine;

public class Attack_Archer : MonoBehaviour
{
    public GameObject Arrow_Prefab;
    public Transform spawnPoint;

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
        Fire(); // Делаем выстрел после завершения анимации, добавить событие в анимацию
    }
}

