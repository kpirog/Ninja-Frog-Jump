using UnityEngine;
using TMPro;

namespace FrogNinja.UI
{
    public class HUDWindow : BaseWindow
    {
        [SerializeField] private TMP_Text scoreCounter;

        public void Button_PauseGame()
        {

        }
        public override void ShowWindow()
        {
            base.ShowWindow();

            scoreCounter.text = "0";
        }
    }
}
