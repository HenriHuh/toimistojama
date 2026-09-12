using UnityEngine;
using Enums;

public class CollectibleClickable : ClickableBase
{
    [field: SerializeField] public CollectibleType Type { get; private set; }
    [SerializeField] private bool disableOnClick = true;

    protected override void Click()
    {
        GameManager.Instance.AddCollectible(Type);

        if (disableOnClick) gameObject.SetActive(false);
        else enabled = false;
    }
}
