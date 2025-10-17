using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddMenuPanel : MonoBehaviour, IGameEventListener
{
    [Header("References")]
    public TMP_Dropdown resourceDropdown;
    public TMP_InputField amountInput;
    public Button addButton;

    private ResourceManager resourceManager;

    public void Initialize(ResourceManager manager, GameEventSO uiStateChangedEvent)
    {
        resourceManager = manager;
        uiStateChangedEvent.RegisterObserver(this);

        // ���������� dropdown
        resourceDropdown.ClearOptions();
        foreach (ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
        {
            resourceDropdown.options.Add(new TMP_Dropdown.OptionData(resourceType.ToString()));
        }
        resourceDropdown.RefreshShownValue();

        // ��������� ������
        addButton.onClick.AddListener(OnAddClicked);

        // ����� �������� �� ���������
        ResetToDefault();
    }

    public void OnEventTriggered()
    {
        // ��� ��������� ��������� UI �������� ��������
        if (gameObject.activeInHierarchy)
        {
            ResetToDefault();
        }
    }

    private void OnAddClicked()
    {
        if (int.TryParse(amountInput.text, out int amount) && amount > 0)
        {
            ResourceType selectedType = (ResourceType)resourceDropdown.value;
            resourceManager.AddResource(selectedType, amount);
            ResetToDefault();
        }
    }

    private void ResetToDefault()
    {
        resourceDropdown.value = 0;
        amountInput.text = "0";
    }
}