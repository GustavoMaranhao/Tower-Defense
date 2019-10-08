using System;
using UnityEngine;

public static class GlobalEvents
{
	public static event EventHandler OnEnemyDeath = delegate { };
    public static void EnemyDeath(object sender, EnemyDeathArgs args)
    {
        OnEnemyDeath(sender, args);
    }

    public static event EventHandler OnWaveEnded = delegate { };
    public static void WaveEnded(object sender, EventArgs args)
    {
        OnWaveEnded(sender, args);
    }
}

public class EnemyDeathArgs : EventArgs
{
    public int goldReward;
    public string killedByTag;

    public EnemyDeathArgs(int goldReward, string killedByTag)
    {
        this.goldReward = goldReward;
        this.killedByTag = killedByTag;
    }
}