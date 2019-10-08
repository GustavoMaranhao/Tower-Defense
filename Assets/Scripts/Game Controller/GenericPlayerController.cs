using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlayerController : MonoBehavior
{
    protected int playerGoldPool;
    protected string playerIdentifier;

    void Start()
    {
        GlobalEvents.OnEnemyDeath += EnemyKilled;
    }

    void Destroy()
    {
        GlobalEvents.OnEnemyDeath -= EnemyKilled;
    }

    private void EnemyKilled(object sender, System.EventArgs e)
    {
        EnemyDeathArgs args = (EnemyDeathArgs) e;

        if (args.killedByTag == playerIdentifier)
        {
            playerGoldPool += args.goldReward;
        }
    }
}