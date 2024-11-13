using UnityEngine;
using VContainer;

public class EnemySpawner : MonoBehaviour
{
    [Inject]
    IObjectResolver Resolver;

    [SerializeField]
    Enemy EnemyPrefab;

    public Enemy Generate(string ID)
    {
        Debug.Log($"Generate ID: {ID}");

        // 今回は Instantiate を呼び出しているが、
        // ObjectPool などで、インスタンスを生成して返すことも可能。
        // 例) var enemy = ObjectPool.Get(ID).GetCompnent<Enemy>();
        var enemy = Instantiate(EnemyPrefab);

        // 動的生成されたインスタンスに対して依存注入
        Resolver.Inject(enemy);

        return enemy;
    }
}
