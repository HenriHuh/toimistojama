using UnityEngine;

public class SeppoSmith : ClickableBase
{
    [SerializeField] private GameObject cpu;

    private bool completed = false;

    protected override void Click()
    {
        if (UIController.Instance.Selected == Enums.CollectibleType.Drink)
        {
            UIController.Instance.ShowDialogue("Thank you! I feel inspired and connected with the universe! I'll craft a CPU!");
            UIController.Instance.RemoveItem(Enums.CollectibleType.Drink);
            completed = true;
        }
        else if (!completed)
        {
            UIController.Instance.ShowDialogue("Totally fucking shitty situation... Saatanan heatenings and no drink!");
        }
    }
}
