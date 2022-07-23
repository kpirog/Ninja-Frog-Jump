using FrogNinja.UI;
using UnityEngine;

namespace FrogNinja.States
{
    public class GameState : BaseState
    {
        public GameState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            Debug.Log("GameState entered");
            UIManager.Instance.ShowHUD();
            EventManager.PlayerFallenOff += GoToLose;
        }

        public override void ExitState()
        {
            EventManager.PlayerFallenOff -= GoToLose;
        }

        public override void UpdateState()
        {
            
        }

        private void GoToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }
        private void GoToLose()
        {
            myStateMachine.EnterState(new LoseState(myStateMachine));
        }
    }
}
