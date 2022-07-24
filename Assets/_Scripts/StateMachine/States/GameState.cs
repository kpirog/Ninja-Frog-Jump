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
            myStateMachine.player.gameObject.SetActive(true);
            Debug.Log("GameState entered");
            EventManager.EnemyHitPlayer += EventManager_EnemyHitPlayer;
            UIManager.Instance.ShowHUD();
            EventManager.PlayerDied += GoToLose;
        }

        private void EventManager_EnemyHitPlayer()
        {
            EventManager.OnPlayerDied();
        }

        public override void ExitState()
        {
            EventManager.PlayerDied -= GoToLose;
            EventManager.PlayerDied -= EventManager_EnemyHitPlayer;
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
