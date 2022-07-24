using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
