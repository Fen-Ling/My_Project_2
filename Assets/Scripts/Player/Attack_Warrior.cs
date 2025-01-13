using UnityEngine;

public class Attack_Warrior : MonoBehaviour
{
    public GameObject Weapon_Slot;
    private Collider swordCollider;
    public AudioClip audioSword;
    private AudioSource hitAudioSource;
    [Range(0f, 1f)]
    public float volume = 1f;

    void Start()
    {
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioSword;
        hitAudioSource.volume = volume;

        if (Weapon_Slot != null)
        {
            swordCollider = Weapon_Slot.GetComponentInChildren<Collider>();
        }
    }
    public void OnAnimation() //добавить событие в начало анимации
    {
        if (swordCollider != null)
        {
            swordCollider.enabled = true; // Включаем коллайдер
        }

        hitAudioSource.Play();
    }

    public void OnAnimationEnd()    //добавить событие в конец анимации
    {
        if (swordCollider != null)
        {
            swordCollider.enabled = false; // Выключаем коллайдер
        }
    }
}