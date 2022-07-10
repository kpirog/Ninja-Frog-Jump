namespace FrogNinja.States
{
    public class LoseState : BaseState
    {
        public LoseState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }
        
        public override void EnterState()
        {

        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {

        }
        private void GoToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }
        private void GoToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }
    }
}
