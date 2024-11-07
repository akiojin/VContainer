using UnityEngine;
using VContainer;

public class Enemy : MonoBehaviour
{
    [Inject]
    Timer timer;

    [SerializeField]
    float Duration = 10f;

    float lifetime;

    void Update()
    {
        if ((lifetime += Time.deltaTime) >= Duration) {
            Destroy(gameObject);
        }

        if (timer.Timeout) {
            Destroy(gameObject);
        }
    }
}
