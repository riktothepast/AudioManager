using UnityEngine;
using System.Collections.Generic;

namespace Audio
{
    public class Manager : Singleton<Manager>
    {
        public AudioSource SoundSource
        {
            get
            {
                return soundSource;
            }
        }

        public AudioSource MusicSource
        {
            get
            {
                return musicSource;
            }
        }

        private AudioSource soundSource;
        private AudioSource musicSource;

        private Dictionary<string, AudioClip> soundClips = new Dictionary<string, AudioClip>();
        private AudioClip currentMusicClip = null;

        protected override void Awake()
        {
            soundSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();
            gameObject.AddComponent<AudioListener>();
            soundSource.loop = false;
            musicSource.loop = true;
            soundSource.playOnAwake = musicSource.playOnAwake = false;
            base.Awake();
        }

        public void PlayMusic(AudioClip musicClip, float volume, bool shouldRestartIfSameSongIsAlreadyPlaying)
        {
            if (currentMusicClip != null) //we only want to have one music clip in memory at a time
            {
                if (currentMusicClip == musicClip) //we're already playing this music, just restart it!
                {
                    if (shouldRestartIfSameSongIsAlreadyPlaying)
                    {
                        musicSource.Stop();
                        musicSource.loop = true;
                        musicSource.Play();
                    }
                    return;
                } else //unload the old music
                {
                    musicSource.Stop();
                    Resources.UnloadAsset(currentMusicClip);
                    currentMusicClip = null;
                }
            }

            currentMusicClip = musicClip;

            if (currentMusicClip == null)
            {
                Debug.Log("Error! Couldn't find music clip " + musicClip);
            } else
            {
                musicSource.clip = currentMusicClip;
                musicSource.loop = true;
                musicSource.Play();
            }
        }

        public void PlayMusic(AudioClip musicClip)
        {
            if (musicClip)
            {
                PlayMusic(musicClip, 1, false);
            }
        }

        public void StopMusic()
        {
            if (musicSource != null)
            {
                musicSource.Stop();
            }
        }

        public void PlaySound(AudioClip audioClip, float volume)
        {
            AudioClip soundClip;
            if (audioClip == null)
                return;
            if (soundClips.ContainsKey(audioClip.name))
            {
                soundClip = soundClips[audioClip.name];
            } else
            {
                soundClip = audioClip;

                if (soundClip == null)
                {
                    return; //can't play the sound because we can't find it!
                } else
                {
                    soundClips[audioClip.name] = soundClip;
                }
            }

            soundSource.PlayOneShot(soundClip);
        }

        public void PlaySound(AudioClip soundClip)
        {
            if (soundClip)
            {
                PlaySound(soundClip, 1.0f);
            }
        }

        public void PreloadSound(AudioClip resourceName)
        {
            if (soundClips.ContainsKey(resourceName.name))
            {
                return; //we already have it, no need to preload it again!
            } else
            {
                AudioClip soundClip = resourceName;

                if (soundClip == null)
                {
                    Debug.Log("Couldn't find sound at: " + resourceName);
                } else
                {
                    soundClips[resourceName.name] = soundClip;
                }
            }
        }

        /// <summary>
        /// Mutes current music, calling it when mute will unmute
        /// </summary>
        public void Mute()
        {
            musicSource.mute = !musicSource.mute;
        }
    }
}
