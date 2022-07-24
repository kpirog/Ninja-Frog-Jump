using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace FrogNinja.UI
{
    public class LoseWindow : BaseWindow
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highScoreText;
        [SerializeField] private ScoreManager scoreManager;
        public override void ShowWindow()
        {
            EventManager.RestartGame += Button_RestartGame;
            scoreText.text = $"Your score: {scoreManager.CurrentScore}";
            highScoreText.text = $"High score: {scoreManager.HighScore}";
            base.ShowWindow();
        }
        public override void HideWindow()
        {
            base.HideWindow();
        }
        public void Button_RestartGame()
        {
            HideWindow();
        }
        public void Button_MainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}