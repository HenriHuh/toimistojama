using UnityEngine;

public class FanClickable : ClickableBase
{
    [SerializeField] private Transform rupelli;
    [SerializeField] private float rotationSpeed;
    private bool fanOn = false;

    private void Update()
    {
        if (fanOn)
        {
            GameManager.Instance.SwingingMao.Push();
            rupelli.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    protected override void Click()
    {
        fanOn = !fanOn;
    }
}
