using UnityEngine;

namespace FrogNinja.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] private MainMenuWindow mainMenu;
        [SerializeField] private HUDWindow hud;
        [SerializeField] private LoseWindow loseWindow;

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
            HideAndSwitchWindow(mainMenu);
        }
        public void ShowHUD()
        {
            HideAndSwitchWindow(hud);
        }
        public void ShowLoseWindow()
        {
            HideAndSwitchWindow(loseWindow);
        }
        public void HideAndSwitchWindow(BaseWindow windowToSwitch)
        {
            if (currentlyOpenWindow != null)
            {
                currentlyOpenWindow.HideWindow();
            }

            currentlyOpenWindow = windowToSwitch;

            currentlyOpenWindow.ShowWindow();
        }
    }
}