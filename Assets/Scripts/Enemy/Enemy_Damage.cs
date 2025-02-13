using UnityEngine;
using UnityEngine.UI;

public class Enemy_Damage : MonoBehaviour
{
    public float MaxHP = 100f;
    public float CorHP;
    public float Enemy_EXP;
    public Slider healthBar;
    private Animator animator;
    private GameObject player;
    public AudioClip audioDeath;
    private AudioSource hitAudioSource;
    private KillEnemy killEnemy;
    public Enemy_Quest_progress questProgress;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        questProgress = gameObject.GetComponent<Enemy_Quest_progress>();
        killEnemy = player.GetComponentInParent<KillEnemy>();
        animator = GetComponent<Animator>();
        hitAudioSource = gameObject.AddComponent<AudioSource>();
        hitAudioSource.clip = audioDeath;
        CorHP = MaxHP;
        healthBar.maxValue = CorHP;
        healthBar.value = CorHP;
        Enemy_EXP = MaxHP / 10f;
    }
    private void FixedUpdate()
    {
        healthBar.value = CorHP;
    }
    public void TakeDamage(int damageAmount)
    {
        CorHP -= damageAmount;
        if (CorHP <= 0)
        {
            hitAudioSource.Play();
            animator.SetTrigger("Death");
            player.GetComponent<Player_Lvl>().Experience(Enemy_EXP);
            killEnemy.IncreaseKillCount();
            questProgress.QuestProgress();
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            Destroy(gameObject, 1.5f);

        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }
}
