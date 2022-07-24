using UnityEngine;
using System;

public static class EventManager
{
    public static event Action EnterGameplay;
    public static event Action<Vector3> PlayerPositionUpdate;
    public static event Action<int> CurrentScoreUpdated;
    public static event Action PlayerDied;
    public static event Action RestartGame;

    public static event Action EnemyHitPlayer;
    public static event Action EnemyDied;

    public static void OnEnemyHitPlayer()
    {
        EnemyHitPlayer?.Invoke();
    }
    public static void OnEnemyDied()
    {
        EnemyDied?.Invoke();
    }

    public static void EnterGameplayButton()
    {
        EnterGameplay?.Invoke();
    }
    public static void OnUpdateScore(int score)
    {
        CurrentScoreUpdated?.Invoke(score);
    }
    public static void OnUpdatePlayerPosition(Vector3 position)
    {
        PlayerPositionUpdate?.Invoke(position);
    }
    public static void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }
    public static void OnRestartGame()
    {
        //Debug.Log("Restart");
        RestartGame?.Invoke();
    }
}
