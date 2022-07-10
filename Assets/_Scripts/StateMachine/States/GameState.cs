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
        }

        public override void ExitState()
        {
            Debug.Log("GameState left");
        }

        public override void UpdateState()
        {
            Debug.Log("GameState update");
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
