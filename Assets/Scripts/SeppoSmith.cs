using UnityEngine;

public class SeppoSmith : ClickableBase
{
    [SerializeField] private GameObject cpu;

    private bool completed = false;

    protected override void Click()
    {
        if (UIController.Instance.Selected == Enums.CollectibleType.Drink)
        {
            UIController.Instance.ShowDialogue("Refreshing! I feel connected with the universe! I'll craft a CPU for you!");
            UIController.Instance.RemoveItem(Enums.CollectibleType.Drink);
            SoundManager.instance.PlaySound(SoundManager.instance.seppa);
            cpu.gameObject.SetActive(true);
            completed = true;
        }
        else if (!completed)
        {
            UIController.Instance.ShowDialogue("Totally fucking shitty situation... Saatanan heatenings and no drink!");
        }
    }
}
