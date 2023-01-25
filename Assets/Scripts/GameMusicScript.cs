using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicScript : MonoBehaviour
{

    [SerializeField] AudioSource _musicSource;
    [SerializeField] List<AudioClip> _musicClips = new();
    void Update()
    {
        if (_musicSource.isPlaying == true)
        {
            return;
        }
        else
        {
            int _rand = Random.Range(0, _musicClips.Count);
            _musicSource.clip = _musicClips[_rand];
            _musicSource.Play();
        }
    }
}
