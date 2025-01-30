using UnityEngine;
namespace Golf
{
    public class Sound_World : MonoBehaviour
    {
        public AudioClip worldSound;
        private AudioSource worldAudioSource;
        [Range(0f, 1f)]
        public float volume = 1f;

        void Start()
        {
            worldAudioSource = gameObject.AddComponent<AudioSource>();
            worldAudioSource.clip = worldSound;
            worldAudioSource.loop = true;
            worldAudioSource.volume = volume;
            worldAudioSource.Play();
        }
        public void SetVolume(float newVolume)
        {
            volume = newVolume;
            worldAudioSource.volume = volume;
        }
    }
}