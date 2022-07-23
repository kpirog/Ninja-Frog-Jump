using FrogNinja.States;
using FrogNinja.UI;
using UnityEngine;

public class MenuState : BaseState
{
    public MenuState(StateMachine stateMachine)
    {
        Initialize(stateMachine);
    }
    public override void EnterState()
    {
        Debug.Log("MenuState entered");

        EventManager.EnterGameplay += EventManager_EnterGameplay;
        UIManager.Instance.ShowMainMenu();
    }
    private void EventManager_EnterGameplay()
    {
        GoToGame();
    }
    public override void UpdateState()
    {
        
    }
    public override void ExitState()
    {
        EventManager.EnterGameplay -= EventManager_EnterGameplay;
    }
    private void GoToGame()
    {
        myStateMachine.EnterState(new GameState(myStateMachine));
    }
}
