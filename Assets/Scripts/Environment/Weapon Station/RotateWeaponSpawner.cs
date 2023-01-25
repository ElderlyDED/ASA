using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeaponSpawner : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 50f * Time.deltaTime, 0f); 
    }
}
