using UnityEngine;

public class Attack_Mage : MonoBehaviour
{
    public GameObject Prefab_Magic;
    public Transform spawnPoint;
    
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
    }
}

