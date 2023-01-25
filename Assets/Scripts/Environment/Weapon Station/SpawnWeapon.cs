using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    [SerializeField] List<GameObject> _notEquipWeapon = new();
    [SerializeField] Transform _weaponHolder;
    [field: SerializeField] public int _spawnninWeaponID { private set; get; }
    void Start()
    {
        //_weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder").transform;
        OnSpawnWeapon();
    }
   
    [ContextMenu("SpawnWeapon")]
    void OnSpawnWeapon()
    {
        CheckNotEquipWeapon();
        SpawningWeapon();
    }

    void CheckNotEquipWeapon()
    {
        foreach (Transform _weapon in GameObject.FindGameObjectWithTag("WeaponHolder").transform)
        {
            if (_weapon.GetComponent<WeaponEquip>().weaponEquip == false)
            {
                _notEquipWeapon.Add(_weapon.gameObject);
            }
        }
    }

    void SpawningWeapon()
    {
        int _rand = Random.Range(0, _notEquipWeapon.Count);
        _spawnninWeaponID = _notEquipWeapon[_rand].GetComponent<GetGUIWeaponSlotInf>().WeaponSlotId;
        
        GameObject _weaponSpawnObj = Instantiate(_notEquipWeapon[_rand]);
        _notEquipWeapon.Remove(_notEquipWeapon[_rand]);
        if (_weaponSpawnObj.GetComponent<ARWeaponShot>() != null)
        {
            _weaponSpawnObj.GetComponent<ARWeaponShot>().enabled = false;
        }
        else if (_weaponSpawnObj.GetComponent<ShotGunShot>() != null)
        {
            _weaponSpawnObj.GetComponent<ShotGunShot>().enabled = false;
        }
        else if (_weaponSpawnObj.GetComponent<ChargaredGunShot>() != null)
        {
            _weaponSpawnObj.GetComponent<ChargaredGunShot>().enabled = false;
        }
        else if (_weaponSpawnObj.GetComponent<GrenadeGunShot>() != null)
        {
            _weaponSpawnObj.GetComponent<GrenadeGunShot>().enabled = false;
        }
        _weaponSpawnObj.GetComponent<Animation>().enabled = false;
        _weaponSpawnObj.transform.SetParent(transform);
        _weaponSpawnObj.transform.localPosition = new Vector3(0, 1, 0);
        _weaponSpawnObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        _weaponSpawnObj.AddComponent<RotateWeaponSpawner>();
        _weaponSpawnObj.SetActive(true);
    }

}
