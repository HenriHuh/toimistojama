using Enums;
using UnityEngine;

public class TransitionClickable : ClickableBase
{
    public SceneType NextScene;

    protected override void Click()
    {
        GameManager.Instance.ChangeScene(NextScene);
    }
}
