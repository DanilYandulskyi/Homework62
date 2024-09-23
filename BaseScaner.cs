using UnityEngine;
using System.Collections.Generic;

public class BaseScaner : MonoBehaviour
{
    [SerializeField] private ResourceSpawner _resourceSpawner;

    public IReadOnlyList<Resource> ScanBase()
    {
        List<Resource> resources = new List<Resource>();

        if (_resourceSpawner.SpawnedResources.Count > 0)
        {
            foreach (Resource resource in _resourceSpawner.SpawnedResources)
            {
                resources.Add(resource);
            }

            _resourceSpawner.TakeOffResources();
        }

        return resources;
    }
}
