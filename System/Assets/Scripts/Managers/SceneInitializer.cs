using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [Header("Game Events")]
    public GameEventSO onResourceChanged;
    public GameEventSO onReset;
    public GameEventSO onUIStateChanged;

    [Header("Managers")]
    public ResourceManager resourceManager;
    public UIManager uiManager;

    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject addMenuPanel;
    public GameObject removeMenuPanel;

    private void Start()
    {
        // Инициализация ResourceManager
        resourceManager.onResourceChanged = onResourceChanged;
        resourceManager.onReset = onReset;
        resourceManager.onUIStateChanged = onUIStateChanged;

        // Инициализация UI Manager
        uiManager.onUIStateChanged = onUIStateChanged;

        // Инициализация панелей
        if (mainMenuPanel != null)
        {
            var mainMenu = mainMenuPanel.GetComponent<MainMenuPanel>();
            if (mainMenu != null)
                mainMenu.Initialize(resourceManager, onResourceChanged, onReset);
        }

        if (addMenuPanel != null)
        {
            var addMenu = addMenuPanel.GetComponent<AddMenuPanel>();
            if (addMenu != null)
                addMenu.Initialize(resourceManager, onUIStateChanged);
        }

        if (removeMenuPanel != null)
        {
            var removeMenu = removeMenuPanel.GetComponent<RemoveMenuPanel>();
            if (removeMenu != null)
                removeMenu.Initialize(resourceManager, onUIStateChanged);
        }
    }
}