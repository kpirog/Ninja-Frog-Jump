using UnityEngine;
using System;

public static class EventManager 
{
    public static event Action EnterGameplay;

    public static void EnterGameplayButton()
    {
        EnterGameplay?.Invoke();
    }
}
