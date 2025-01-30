using UnityEngine;
namespace Golf
{
    public class Sound_Stick : MonoBehaviour
    {
        public AudioClip stickHitSound;
        private AudioSource hitAudioSource;
        [Range(0f, 1f)]
        public float volume = 1f;
        void Start()
        {
            hitAudioSource = gameObject.AddComponent<AudioSource>();
            hitAudioSource.clip = stickHitSound;
            hitAudioSource.volume = volume;
        }
        public void PlayHitSound()
        {
            hitAudioSource.clip = stickHitSound;
            hitAudioSource.Play();
        }
        public void SetVolume(float newVolume)
        {
            volume = newVolume;
            hitAudioSource.volume = volume;
        }
    }
}