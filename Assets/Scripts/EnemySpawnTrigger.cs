using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using Random = UnityEngine.Random;

public class EnemySpawnTrigger : MonoBehaviour
{
    [SerializeField]
    Button EnemySpawnButton;

    /// <summary>
    /// RegisterFactory で登録されたファクトリメソッドを依存注入する
    /// </summary>
    [Inject]
    EnemySpawner EnemySpawner;

    [Inject]
    Timer timer;

    void Start()
        => EnemySpawnButton.onClick.AddListener(OnClicked);

    void Update()
    {
        if (timer.Timeout) {
            EnemySpawnButton.onClick.RemoveListener(OnClicked);
        }
    }

    void OnClicked()
    {
        var ID = Guid.NewGuid().ToString();
        var enemy = EnemySpawner.Generate(ID);

        enemy.transform.position = new(Random.Range(0f, 320f), Random.Range(0f, 180f), 0f);
    }
}
