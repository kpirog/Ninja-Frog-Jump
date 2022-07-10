using UnityEngine;

namespace FrogNinja.CameraControls
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;

        private Vector3 tempPosition;

        private void Start()
        {
            tempPosition = transform.position;
        }

        private void Update()
        {
            if (playerController.transform.position.y > tempPosition.y)
            {
                tempPosition.y = playerController.transform.position.y;
                transform.position = tempPosition;
            }
        }
    }
}
