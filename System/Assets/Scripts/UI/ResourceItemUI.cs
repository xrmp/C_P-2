using TMPro;
using UnityEngine;

public class ResourceItemUI : MonoBehaviour, IGameEventListener
{
    [Header("References")]
    public TextMeshProUGUI resourceNameText;
    public TextMeshProUGUI resourceAmountText;

    [Header("Settings")]
    public ResourceType resourceType;

    private ResourceManager resourceManager;

    public void Initialize(ResourceManager manager, GameEventSO resourceChangedEvent)
    {
        resourceManager = manager;
        resourceChangedEvent.RegisterObserver(this);
        UpdateDisplay();
    }

    public void OnEventTriggered()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (resourceManager != null)
        {
            resourceNameText.text = resourceType.ToString();
            resourceAmountText.text = resourceManager.GetResourceAmount(resourceType).ToString();
        }
    }

    private void OnDestroy()
    {
        // Здесь можно добавить отписку от событий
    }
}