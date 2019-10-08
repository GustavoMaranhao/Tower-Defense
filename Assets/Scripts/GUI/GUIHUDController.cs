public class GUIHUDController : MonoBehavior
{
    private int currentGoldAmount;
    private PlayerController playerOwner;

    void Start()
    {
        GlobalEvents.EnemyDeath += UpdateHUDResources;
    }

    void Destroy()
    {
        GlobalEvents.EnemyDeath -= UpdateHUDResources;
    }

    void UpdateHUDResources(object sender, System.EventArgs e)
    {
        EnemyDeathArgs args = (EnemyDeathArgs) e;

        if (args.killedByTag != playerOwner) return;

        currentGoldAmount = args.goldReward;
    }
}