using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmoCrate : MonoBehaviour
{
    [SerializeField] int _ammoAmount;
    [SerializeField] List<GameObject> _ammoPoints = new();
    [SerializeField] GameObject _ammoCrate;

    void Start()
    {
        _ammoPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointAmmo"));
    }
    public void OnSpawnAmmoCrate()
    {
        
        for (int i = 0; i < _ammoPoints.Count; i++)
        {
            if (_ammoPoints[i].transform.childCount != 0)
            {
                Destroy(_ammoPoints[i].transform.GetChild(0).gameObject);
            }
        }
        List<GameObject> _ammoSpawnPoints = new();
        _ammoPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointAmmo"));
        for (int i = 0; i < _ammoAmount; i++)
        {
            int _rand = Random.Range(0, _ammoPoints.Count);
            _ammoSpawnPoints.Add(_ammoPoints[_rand]);
        }

        foreach (GameObject _obj in _ammoSpawnPoints)
        {
            GameObject _crate = Instantiate(_ammoCrate);
            _crate.transform.position = _obj.transform.position;
            _crate.transform.SetParent(_obj.transform);
        }
    }
}
