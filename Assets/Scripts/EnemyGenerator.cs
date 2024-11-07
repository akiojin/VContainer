using UnityEngine;
using VContainer;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    public Enemy Generate(IObjectResolver resolver, string ID)
    {
        Debug.Log($"Generate ID: {ID}");

        // 今回は Instantiate を呼び出しているが、
        // ObjectPool などで、インスタンスを生成して返すことも可能。
        // 例) var enemy = ObjectPool.Get(ID).GetCompnent<Enemy>();
        var enemy = Instantiate(EnemyPrefab).GetComponent<Enemy>();

        // 動的生成されたインスタンスに対して DI 注入
        resolver.Inject(enemy);

        return enemy;
    }
}
