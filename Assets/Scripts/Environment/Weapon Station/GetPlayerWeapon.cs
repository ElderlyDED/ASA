using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerWeapon : MonoBehaviour
{
    [SerializeField] SpawnWeapon _spawnWeaponScript;
    [SerializeField] Transform _weaponHolder;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;
    void Start()
    {
        _weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder").transform;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Transform _weaponObj in _weaponHolder)
            {
                if (_weaponObj.GetComponent<GetGUIWeaponSlotInf>().WeaponSlotId == _spawnWeaponScript._spawnninWeaponID) 
                {
                    _weaponObj.GetComponent<WeaponEquip>().weaponEquip = true; 
                }

            }
            _audioSource.PlayOneShot(_audioClip);
            Destroy(transform.GetChild(1).gameObject);
            StartCoroutine(DestroyObj());
        }
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }
}
