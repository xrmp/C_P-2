using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [System.Serializable]
    public class ResourceData
    {
        public ResourceType type;
        public int amount;
    }

    public List<ResourceData> resources = new List<ResourceData>();

    // События
    public GameEventSO onResourceChanged;
    public GameEventSO onReset;
    public GameEventSO onUIStateChanged;

    private void Awake()
    {
        // Инициализация ресурсов
        foreach (ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
        {
            resources.Add(new ResourceData { type = resourceType, amount = 0 });
        }
    }

    public int GetResourceAmount(ResourceType type)
    {
        return resources.Find(r => r.type == type).amount;
    }

    public void AddResource(ResourceType type, int amount)
    {
        var resource = resources.Find(r => r.type == type);
        resource.amount += amount;
        onResourceChanged?.Notify();
    }

    public void RemoveResource(ResourceType type, int amount)
    {
        var resource = resources.Find(r => r.type == type);
        resource.amount = Mathf.Max(0, resource.amount - amount);
        onResourceChanged?.Notify();
    }

    public void ResetResources()
    {
        foreach (var resource in resources)
        {
            resource.amount = 0;
        }
        onReset?.Notify();
        onResourceChanged?.Notify();
    }
}