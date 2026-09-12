using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ClickableBase : MonoBehaviour
{
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
    }

    protected abstract void Click();
}
