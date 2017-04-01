using UnityEngine;

namespace Audio
{
    public class SoundLoader : MonoBehaviour
    {
        [SerializeField]
        private AudioClip sound;

        public bool PlayOnStart;

        void Start()
        {
            if (PlayOnStart)
            {
                PlaySound();
            }
        }

        public void PlaySound()
        {
            Manager.Instance.PlaySound(sound);
        }

    }
}