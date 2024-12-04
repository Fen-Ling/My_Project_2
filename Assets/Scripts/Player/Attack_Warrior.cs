using UnityEngine;

public class Attack_Warrior : MonoBehaviour
{
    public GameObject Weapon_Slot; 

    private Collider swordCollider; 

    void Start()
    {
        if (Weapon_Slot != null)
        {
            swordCollider = Weapon_Slot.GetComponentInChildren<Collider>();
        }
    }
    public void OnAnimation()
    {
        if (swordCollider != null)
        {
            swordCollider.enabled = true; // Включаем коллайдер
        }
    }

    public void OnAnimationEnd()
    {
        if (swordCollider != null)
        {
            swordCollider.enabled = false; // Выключаем коллайдер
        }
    }
}