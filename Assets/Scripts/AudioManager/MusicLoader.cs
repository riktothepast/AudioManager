using UnityEngine;

namespace Audio
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
                Manager.Instance.PlayMusic(song);
            else
                Manager.Instance.StopMusic();
        }
    }
}