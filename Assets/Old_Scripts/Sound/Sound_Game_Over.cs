using UnityEngine;
namespace Golf
{
    public class Sound_Game_Over : MonoBehaviour
    {
        public AudioClip GameOverSound;
        private AudioSource hitAudioSource;
        void Start()
        {
            hitAudioSource = gameObject.AddComponent<AudioSource>();
        }

        public void PlayGameOverSound()
        {
            hitAudioSource.clip = GameOverSound;
            hitAudioSource.Play();
        }
    }
}