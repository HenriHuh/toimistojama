using Enums;
using UnityEngine;

public class ComputerPartClickable : ClickableBase
{
    [SerializeField] private int requiredCompletion;
    [SerializeField] private GameObject enableOnSuccess;
    [field:SerializeField] public Computer.SlotType SlotType { get; private set; }
    [SerializeField] private string guideText;
    private bool completed = false;

    protected override void Click()
    {
        CollectibleType type = UIController.Instance.Selected;
        if (GameManager.Instance.Computer.TryInsert(SlotType, type))
        {
            UIController.Instance.RemoveItem(type);
            completed = true;
            if (enableOnSuccess != null) enableOnSuccess.gameObject.SetActive(true);
        }
        else if (!completed && !string.IsNullOrEmpty(guideText))
        {
            UIController.Instance.ShowDialogue(guideText);
        }
    }
}
