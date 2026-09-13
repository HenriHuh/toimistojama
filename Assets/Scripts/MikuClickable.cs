using UnityEngine;

public class MikuClickable : ClickableBase
{
    private bool completed = false;

    protected override void Click()
    {
        if (completed) return;

        GameManager.Instance.AddCollectible(Enums.CollectibleType.ThermalPaste);
        completed = true;

    }
}
