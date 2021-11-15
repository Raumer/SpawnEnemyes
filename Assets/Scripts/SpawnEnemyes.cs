using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyes : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoints;
    //[SerializeField] private int _actions;
    private Transform[] _points;

    void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(DelaySpawn());
    }

    private IEnumerator DelaySpawn()
    {
        foreach (var point in _points)
        { 
            GameObject Enemy = Instantiate(_template, point.position, Quaternion.identity);

            yield return new WaitForSeconds(2);
        }
    }
}
