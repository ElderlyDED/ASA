using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundPlayer : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            foreach(Transform obj in transform)
            {
                AudioSource _as = obj.GetComponent<AudioSource>();
                if (_as.isPlaying == false)
                {
                    _as.Play();
                }
                
            }
        }
    }
}
