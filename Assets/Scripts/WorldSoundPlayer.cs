using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSoundPlayer : MonoBehaviour
{
    void Update()
    {
        foreach (Transform obj in transform)
        {
            AudioSource _as = obj.GetComponent<AudioSource>();
            if (_as.isPlaying == false)
            {
                _as.Play();
            }

        }
    }

}
