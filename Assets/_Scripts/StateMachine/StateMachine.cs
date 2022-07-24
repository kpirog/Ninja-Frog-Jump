using UnityEngine;

namespace FrogNinja.States
{
    public class StateMachine : MonoBehaviour
    {
        private BaseState currentState;

        [HideInInspector] public PlayerController player;

        [HideInInspector] public Camera mainCamera;

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();
            mainCamera = Camera.main;
            EnterState(new MenuState(this));
        }
        public void EnterState(BaseState newState)
        {
            if (currentState != null)
                currentState.ExitState();

            currentState = newState;

            currentState.EnterState();
        }
        private void Update()
        {
            currentState.UpdateState();
        }
        private void OnDestroy()
        {
            currentState.ExitState();
        }
    }
}
