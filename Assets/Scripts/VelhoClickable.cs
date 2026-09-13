using System.Collections;
using UnityEngine;

public class VelhoClickable : ClickableBase
{
    [SerializeField] private GameObject velho;
    [SerializeField] private GameObject hardDrive;
    private bool completed;

    protected override void Click()
    {
        if (completed) return;

        velho.gameObject.SetActive(true);
        hardDrive.gameObject.SetActive(true);
        completed = true;
    }

}
