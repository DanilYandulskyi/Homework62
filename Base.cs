using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(BaseScaner))]
public class Base : MonoBehaviour
{
    [SerializeField] private List<Resource> _resources = new List<Resource>();
    [SerializeField] private List<Unit> _units = new List<Unit>();
    [SerializeField] private List<Resource> _collectedResources = new List<Resource>();

    private BaseScaner _baseScaner;

    public IReadOnlyList<Resource> Resources => _resources;
    public event Action<List<Resource>> ResourceAdded;

    private void Awake()
    {
        _baseScaner = GetComponent<BaseScaner>();

        foreach (Unit unit in _units)
        {
            unit.CollectedResource += CollectResource;
        }
    }

    private void OnDestroy()
    {
        foreach (Unit unit in _units)
        {
            unit.CollectedResource -= CollectResource;
        }
    }

    private void Update()
    {
        if (_resources.Count > 0)
        {
            for (int i = 0; i < _units.Count; i++)
            {
                if (_units[i].IsStanding)
                {
                    _units[i].StartMovingToResource(_resources[0]);
                    _resources.Remove(_resources[0]);
                    break;
                }
            }
        }

        else
        {
            List<Resource> resources = (List<Resource>)_baseScaner.ScanBase();

            if (resources.Count > 0)
            {
                foreach (Resource resource in resources)
                {
                    _resources.Add(resource);
                }
            }
        }
    }   

    private void CollectResource(Resource resource)
    {
        _collectedResources.Add(resource);
        ResourceAdded?.Invoke(_collectedResources);
    }

    public void AddResource(Resource resource)
    {
        _resources.Add(resource);
    }
}
