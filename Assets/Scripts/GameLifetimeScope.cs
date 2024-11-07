using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    EnemyGenerator EnemyGenerator;

    protected override void Configure(IContainerBuilder builder)
    {
        // Enemy に依存注入する Timer クラス
        builder.RegisterComponentOnNewGameObject<Timer>(Lifetime.Singleton);
        // 実際に敵を生成するクラス
        builder.RegisterComponentInNewPrefab(EnemyGenerator, Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<EnemySpawnTrigger>();
        builder.RegisterFactory<string, Enemy>(container => (ID) => {
            return container.Resolve<EnemyGenerator>().Generate(container, ID);
        }, Lifetime.Scoped);
    }
}
