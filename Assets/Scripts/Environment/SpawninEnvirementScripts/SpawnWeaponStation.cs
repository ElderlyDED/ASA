using System.Collections.Generic;
using UnityEngine;

public class SpawnWeaponStation : MonoBehaviour
{
    [SerializeField] int _weaponStationAmount;
    [SerializeField] List<GameObject> _weaponStationPoints = new();
    [SerializeField] GameObject _weaponStation;
    [SerializeField] GameObject _gameUI;

    void Start()
    {
        _weaponStationPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointWeaponStation"));
        _gameUI = GameObject.FindGameObjectWithTag("GameUI");
    }

    [ContextMenu("gay")]
    public void OnSpawnWeaponStation()
    {
        List<GameObject> _empyPoints = new();
        foreach (GameObject _spawnPoint in _weaponStationPoints)
        {
            if (_spawnPoint.transform.childCount == 0)
            {
                _empyPoints.Add(_spawnPoint);
            }
        }
        int _rand = Random.Range(0, _empyPoints.Count);
        GameObject spawnStation = Instantiate(_weaponStation);
        spawnStation.transform.SetParent(_empyPoints[_rand].transform);
        spawnStation.transform.position = _empyPoints[_rand].transform.position;
        _gameUI.GetComponent<ShowInformationText>().OnShowInfText("New weapon");
    } 
    
}
