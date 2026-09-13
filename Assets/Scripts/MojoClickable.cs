using UnityEngine;

public class MojoClickable : ClickableBase
{
    [SerializeField] private GameObject hardDrive;

    private bool completed = false;

    private string[] wisdoms = new string[] 
    {
        "We are souls...",
        //"Toes never lie... I think.",
        //"Things happen when things happen, but only when happening.",
        //"The integral of Sin(x) is -Cos(x).",
    };

    protected override void Click()
    {

        string wisdom = wisdoms[Random.Range(0, wisdoms.Length)];
        UIController.Instance.ShowDialogue(wisdom);

        if (!completed)
        {
            hardDrive.gameObject.SetActive(true);
            completed = true;
        }
    }
}
