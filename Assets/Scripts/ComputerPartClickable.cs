using Enums;
using UnityEngine;

public class ComputerPartClickable : ClickableBase
{
    [SerializeField] private int requiredCompletion = 1;
    [SerializeField] private GameObject enableOnSuccess;
    [field:SerializeField] public Computer.SlotType SlotType { get; private set; }
    [SerializeField] private string guideText;
    private int completed = 0;

    protected override void Click()
    {
        CollectibleType type = UIController.Instance.Selected;
        if (GameManager.Instance.Computer.TryInsert(SlotType, type))
        {
            UIController.Instance.RemoveItem(type);
            completed++;
            if (enableOnSuccess != null) enableOnSuccess.gameObject.SetActive(true);
        }
        else if (completed < requiredCompletion && !string.IsNullOrEmpty(guideText))
        {
            UIController.Instance.ShowDialogue(guideText);
        }
    }
}
