using UnityEngine;
using System;

public static class EventManager 
{
    public static event Action EnterGameplay;
    public static event Action<Vector3> PlayerPositionUpdate;
    public static event Action<int> CurrentScoreUpdated;
    public static event Action PlayerFallenOff;

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
    public static void OnPlayerFallenOff()
    {
        PlayerFallenOff?.Invoke();
    }
}
