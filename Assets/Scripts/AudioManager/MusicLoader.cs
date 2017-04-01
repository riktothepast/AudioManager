using UnityEngine;

namespace AudioManager
{
    public class MusicLoader : MonoBehaviour
    {
        [SerializeField]
        private AudioClip song;
        public bool PlayOnStart;

        void Start()
        {
            if (PlayOnStart)
            {
                PlayMusic();
            }
        }

        public void PlayMusic()
        {
            if (song)
                AudioManager.Instance.PlayMusic(song);
            else
                AudioManager.Instance.StopMusic();
        }
    }
}