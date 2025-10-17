using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    [Header("References")]
    public Transform resourceItemsParent;
    public GameObject resourceItemPrefab;
    public Button resetButton;

    private ResourceManager resourceManager;
    private List<ResourceItemUI> resourceItems = new List<ResourceItemUI>();

    public void Initialize(ResourceManager manager, GameEventSO resourceChangedEvent, GameEventSO resetEvent)
    {
        resourceManager = manager;

        // Создать элементы ресурсов
        foreach (ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
        {
            GameObject itemGO = Instantiate(resourceItemPrefab, resourceItemsParent);
            ResourceItemUI itemUI = itemGO.GetComponent<ResourceItemUI>();
            itemUI.resourceType = resourceType;
            itemUI.Initialize(manager, resourceChangedEvent);
            resourceItems.Add(itemUI);
        }

        // Настройка кнопки Reset
        resetButton.onClick.AddListener(OnResetClicked);
    }

    private void OnResetClicked()
    {
        resourceManager?.ResetResources();
    }
}