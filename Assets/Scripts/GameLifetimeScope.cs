using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    EnemySpawner EnemySpawner;

    protected override void Configure(IContainerBuilder builder)
    {
        // Enemy に依存注入する Timer クラス
        builder.RegisterComponentOnNewGameObject<Timer>(Lifetime.Singleton);
        // 実際に敵を生成するクラス
        builder.RegisterComponentInNewPrefab(EnemySpawner, Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<EnemySpawnTrigger>();

        // ヒエラルキーに配置済みの Enemy クラスに依存注入
        foreach (var enemy in FindObjectsByType<Enemy>(FindObjectsSortMode.None)) {
            builder.RegisterBuildCallback(resolver => {
                resolver.Inject(enemy);
            });
        }
    }
}
