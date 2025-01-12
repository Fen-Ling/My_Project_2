using UnityEngine;

namespace Golf
{
    public class Sound_Stoun : MonoBehaviour
    {
        public AudioClip stoneHitSound;
        private AudioSource hitAudioSource;
        [Range(0f, 1f)]
        public float volume = 1f;
        void Start()
        {
            hitAudioSource = gameObject.AddComponent<AudioSource>();
            hitAudioSource.clip = stoneHitSound;
            hitAudioSource.volume = volume;
        }
        public void PlayStoneSound()
        {
            hitAudioSource.clip = stoneHitSound;
            hitAudioSource.Play();
        }
        public void SetVolume(float newVolume)
        {
            volume = newVolume;
            hitAudioSource.volume = volume;
        }
    }
}