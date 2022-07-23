using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private MainMenuWindow mainMenu;

    private BaseWindow currentlyOpenWindow;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ShowMainMenu()
    {
        if (currentlyOpenWindow != null)
        {
            currentlyOpenWindow.HideWindow();
        }

        currentlyOpenWindow = mainMenu;

        currentlyOpenWindow.ShowWindow();
    }
}
