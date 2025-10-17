using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Панели")]
    public GameObject mainMenuPanel;
    public GameObject addMenuPanel;
    public GameObject removeMenuPanel;

    [Header("Кнопки")]
    public Button mainMenuButton;
    public Button addMenuButton;
    public Button removeMenuButton;

    [Header("Events")]
    public GameEventSO onUIStateChanged;

    private void Start()
    {
        // Настройка кнопок
        mainMenuButton.onClick.AddListener(ShowMainMenu);
        addMenuButton.onClick.AddListener(ShowAddMenu);
        removeMenuButton.onClick.AddListener(ShowRemoveMenu);

        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        SetAllPanelsInactive();
        mainMenuPanel.SetActive(true);
        UpdateButtonStates(mainMenuButton);
        onUIStateChanged?.Notify();
    }

    public void ShowAddMenu()
    {
        SetAllPanelsInactive();
        addMenuPanel.SetActive(true);
        UpdateButtonStates(addMenuButton);
        onUIStateChanged?.Notify();
    }

    public void ShowRemoveMenu()
    {
        SetAllPanelsInactive();
        removeMenuPanel.SetActive(true);
        UpdateButtonStates(removeMenuButton);
        onUIStateChanged?.Notify();
    }

    private void SetAllPanelsInactive()
    {
        mainMenuPanel.SetActive(false);
        addMenuPanel.SetActive(false);
        removeMenuPanel.SetActive(false);
    }

    private void UpdateButtonStates(Button activeButton)
    {
        // Сброс всех кнопок
        mainMenuButton.interactable = true;
        addMenuButton.interactable = true;
        removeMenuButton.interactable = true;

        // Делаем активную кнопку неинтерактивной
        activeButton.interactable = false;
    }
}