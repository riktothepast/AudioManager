# AudioManager

A simple audio manager for your unity 2D projects, features:

  - Persistance across scenes
  - Music (looped) and sound playback (one shot)
  - Caching of sound effects

# How to use it
- Add the AudioManager prefab to your scene.

#### Playing music
from within your code you can call any of the two music playback methods and one to stop the current music playing.
```csharp
Audio.Manager.Instance.PlayMusic(AudioClip musicClip);
Audio.Manager.Instance.PlayMusic(AudioClip musicClip, float volume, bool shouldRestart);
Audio.Manager.Instance.StopMusic();
```

#### Playing sounds
Sound effects are cached in order to keep them available if you re use them a lot.
You have 2 methods to call to reproduce sound effects:
```csharp
Audio.Manager.Instance.PlaySound(AudioClip soundClip);
Audio.Manager.Instance.PlaySound(AudioClip musicClip, float volume);
```

# Changelog

#### Version 1.0.0
- Singleton audio manager
- Sound loading scripts
- Unity package
