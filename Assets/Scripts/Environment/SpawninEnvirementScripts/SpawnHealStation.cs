using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealStation : MonoBehaviour
{
    [SerializeField] int _healAmount;
    [SerializeField] List<GameObject> _healPoints = new();
    [SerializeField] GameObject _healStation;
    void Start()
    {
        _healPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointHeal"));
        for (int i = 0; i < _healAmount; i++)
        {
            int _rand = Random.Range(0, _healPoints.Count);
            GameObject _healStationObj = Instantiate(_healStation);
            _healStationObj.transform.position = _healPoints[_rand].transform.position;
            _healStationObj.transform.SetParent(_healPoints[_rand].transform);
            _healPoints.Remove(_healPoints[_rand]);
        }
    }
}
