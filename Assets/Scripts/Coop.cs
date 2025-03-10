using UnityEngine;

public class Coop : Collectible
{
    public int eggAmount = 1;

    protected override void onCollect()
    {
        if (!collected)
        {
            collected = true;
        }
    }
}
