using UnityEngine;

public abstract class BaseWindow : MonoBehaviour
{
    public virtual void ShowWindow()
    {
        gameObject.SetActive(true);
    }
    public virtual void HideWindow()
    {
        gameObject.SetActive(false);
    }
}
