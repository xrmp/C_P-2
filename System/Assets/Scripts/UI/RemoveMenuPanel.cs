using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RemoveMenuPanel : MonoBehaviour, IGameEventListener
{
    [Header("References")]
    public TMP_Dropdown resourceDropdown;
    public TMP_InputField amountInput;
    public Button removeButton;

    private ResourceManager resourceManager;

    public void Initialize(ResourceManager manager, GameEventSO uiStateChangedEvent)
    {
        resourceManager = manager;
        uiStateChangedEvent.RegisterObserver(this);

        // Заполнение dropdown
        resourceDropdown.ClearOptions();
        foreach (ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
        {
            resourceDropdown.options.Add(new TMP_Dropdown.OptionData(resourceType.ToString()));
        }
        resourceDropdown.RefreshShownValue();

        // Настройка кнопки
        removeButton.onClick.AddListener(OnRemoveClicked);

        // Сброс значений по умолчанию
        ResetToDefault();
    }

    public void OnEventTriggered()
    {
        // При изменении состояния UI сбросить значения
        if (gameObject.activeInHierarchy)
        {
            ResetToDefault();
        }
    }

    private void OnRemoveClicked()
    {
        if (int.TryParse(amountInput.text, out int amount) && amount > 0)
        {
            ResourceType selectedType = (ResourceType)resourceDropdown.value;
            resourceManager.RemoveResource(selectedType, amount);
            ResetToDefault();
        }
    }

    private void ResetToDefault()
    {
        resourceDropdown.value = 0;
        amountInput.text = "0";
    }
}