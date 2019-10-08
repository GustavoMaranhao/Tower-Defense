using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : UnitsBase
{
    public int unitHealth;
    public int goldReward;

    private bool bExecutedDeath = false;

    // Overriding the parent base start
    override protected void Start()
    {
        base.Start();
    }

    // Overriding the parent base start
    override protected void Update()
    {
        base.Update();

        if ((unitHealth <= 0) && !bExecuteDeath)
        {
            bExecuteDeath = true;
            UnitDeath();
        }
    }

    private void UnitDeath()
    {
        GlobalEvents.OnEnemyDeath(goldReward);
        gameObject.Destroy();
    }
}
