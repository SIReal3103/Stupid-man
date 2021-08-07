using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private void Start()
    {
        Invoke("Hide", 1.2f);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
