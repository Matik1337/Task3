using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _points;
    [SerializeField] private Coin _coin;

    private float _spawnPeriod;
    void Start()
    {
        _points = GetComponentsInChildren<SpawnPoint>();
        _spawnPeriod = 5f;

        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        foreach (var point in _points)
        {
            Instantiate(_coin, point.transform);
            
            yield return new WaitForSeconds(_spawnPeriod);
        }
    }
}
