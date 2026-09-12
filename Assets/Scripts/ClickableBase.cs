using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ClickableBase : MonoBehaviour
{
    public Animator playAnimationOnClick;

    private void OnDisable()
    {
        if (playAnimationOnClick != null) playAnimationOnClick.enabled = false;
    }

    public void OnMouseEnter()
    {
        GameManager.Instance.ClickableEnter(this);
    }

    public void OnMouseExit()
    {
        GameManager.Instance.ClickableExit(this);
    }

    public void OnMouseDown()
    {
        Click();
        UIController.Instance.UnSelect();
        if(playAnimationOnClick != null)
        {
            playAnimationOnClick.enabled = true;
            playAnimationOnClick.Play(0);
        }
    }

    protected abstract void Click();
}
