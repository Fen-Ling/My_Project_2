using UnityEngine;

public class Enemy_Archer : MonoBehaviour
{
    public GameObject Arrow_Prefab;
    public Transform spawnPoint;
   
    private void Fire()
    {
        if (spawnPoint == null)
    {
        Debug.LogError("Spawn point is not assigned.");
        return;
    }
        var newProjectile = Instantiate(Arrow_Prefab);
        newProjectile.transform.position = spawnPoint.position;
        newProjectile.transform.rotation = spawnPoint.rotation;
        const int size = 1;
        newProjectile.transform.localScale *= size;

        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = Mathf.Pow(size, 1);
            rb.AddForce(spawnPoint.forward * 20f, ForceMode.Impulse);
        }

    }
    public void OnAttackAnimationComplete()
    {
        Fire();
    }
}