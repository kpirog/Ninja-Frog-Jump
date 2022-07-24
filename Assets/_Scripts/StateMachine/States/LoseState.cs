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
            UIManager.Instance.ShowLoseWindow();
            EventManager.EnterGameplay += EventManager_EnterGameplay;
        }

        private void EventManager_EnterGameplay()
        {
            GoToGame();
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
            myStateMachine.player.transform.position = LevelGenerator.Instance.SpawnPosition;
            myStateMachine.mainCamera.transform.position = new Vector3(0f, 0f, -10f);
            myStateMachine.EnterState(new GameState(myStateMachine));
        }
    }
}
