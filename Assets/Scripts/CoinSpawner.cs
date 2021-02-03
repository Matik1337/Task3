using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _points;
    [SerializeField] private GameObject _coin;
    void Start()
    {
        _points = GetComponentsInChildren<SpawnPoint>();

        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        foreach (var point in _points)
        {
            Instantiate(_coin, point.transform);
            yield return new WaitForSeconds(5);
        }
    }
}
