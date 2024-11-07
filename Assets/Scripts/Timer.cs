using UnityEngine;

public class Timer : MonoBehaviour
{
    float TimeoutSeconds = 10f;

    public bool Timeout => !enabled;

    void Update()
    {
        if ((TimeoutSeconds -= Time.deltaTime) <= 0) {
            Debug.Log("Timeout");
            enabled = false;
        }
    }
}
