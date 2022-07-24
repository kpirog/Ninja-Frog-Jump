using FrogNinja.UI;
using UnityEngine;

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
            EventManager.RestartGame += GoToGame;
            UIManager.Instance.ShowLoseWindow();
        }

        public override void ExitState()
        {
            LevelGenerator.Instance.RestartLevel();
            myStateMachine.player.transform.position = LevelGenerator.Instance.SpawnPosition;
            myStateMachine.mainCamera.transform.position = new Vector3(0f, 0f, -10f);
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
