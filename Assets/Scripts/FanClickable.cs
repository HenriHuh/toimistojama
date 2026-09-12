using UnityEngine;

public class FanClickable : ClickableBase
{
    private bool fanOn = false;

    private void Update()
    {
        if (fanOn) GameManager.Instance.SwingingMao.Push();
    }

    protected override void Click()
    {
        fanOn = !fanOn;
    }
}
