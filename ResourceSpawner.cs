using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private List<Resource> _resources = new List<Resource>();
    [SerializeField] private List<Resource> _spawnedResources = new List<Resource>();
    [SerializeField] private float _interval;

    public IReadOnlyList<Resource> SpawnedResources => _spawnedResources;

    private void Awake()
    {
        StartCoroutine(Spawning());
    }

    public void TakeOffResources()
    {
        _spawnedResources.Clear();
    }

    private IEnumerator Spawning()
    {
        while (enabled)
        {
            Spawn();
            yield return new WaitForSeconds(_interval);
        }
    }

    private void Spawn()
    {
        int minValue = -5;
        int maxValue = 5;

        _spawnedResources.Add(Instantiate(_resources[Random.Range(0, _resources.Count)],
        new Vector3(Random.Range(minValue, maxValue), 0, Random.Range(minValue, maxValue)), Quaternion.identity));
    }
}
