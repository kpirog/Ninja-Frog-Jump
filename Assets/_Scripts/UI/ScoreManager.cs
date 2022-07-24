using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int positionDifferenceScoreMultplier = 100;

    private const string HIGH_SCORE_KEY = "high_score";

    private int currentScore, highScore;
    private float maxPositionY;
    private bool firstUpdate = false;

    public int CurrentScore => currentScore;
    public int HighScore => highScore;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);

        EventManager.EnterGameplay += EventManager_EnterGameplay;
        EventManager.PlayerPositionUpdate += EventManager_PlayerPositionUpdate;
        EventManager.PlayerDied += EventManager_PlayerFallenOff;
    }

    private void EventManager_EnterGameplay()
    {
        firstUpdate = true;
        currentScore = 0;
    }
    private void SaveHighScore()
    {
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, currentScore);
            highScore = currentScore;
        }
    }
    private void OnDestroy()
    {
        EventManager.EnterGameplay -= EventManager_EnterGameplay;
        EventManager.PlayerPositionUpdate -= EventManager_PlayerPositionUpdate;
        EventManager.PlayerDied -= EventManager_PlayerFallenOff;
    }
    private void EventManager_PlayerPositionUpdate(Vector3 obj)
    {
        if (firstUpdate)
        {
            maxPositionY = obj.y;
            currentScore = 0;
            firstUpdate = false;
            return;
        }

        if (obj.y > maxPositionY)
        {
            float difference = obj.y - maxPositionY;
            currentScore += (int)(difference * positionDifferenceScoreMultplier);

            maxPositionY = obj.y;

            EventManager.OnUpdateScore(currentScore);
        }
    }
    private void EventManager_PlayerFallenOff()
    {
        SaveHighScore();
    }
}
