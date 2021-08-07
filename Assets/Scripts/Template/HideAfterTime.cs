using UnityEngine;

public class HideAfterTime : MonoBehaviour
{
    public void Hide(float delay)
    {
        Invoke("CallHide", delay);       
    }

    void CallHide()
    {
        gameObject.SetActive(false);
    }
}
