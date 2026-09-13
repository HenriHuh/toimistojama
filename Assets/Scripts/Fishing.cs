using UnityEngine;

public class Fishing : ClickableBase
{
    [SerializeField] private Transform es;
    [SerializeField] private Transform hietakissa;
    [SerializeField] private float fallSpeed;
    [SerializeField] private Vector3 targetPosition;
    private Vector3 startPosition;
    private bool completed = false;
    private Vector3 currentPosition;

    private void Start()
    {
        currentPosition = es.transform.position;
        startPosition = es.transform.position;
    }

    private void Update()
    {
        if (completed) return;

        currentPosition = Vector3.MoveTowards(
            currentPosition, startPosition, fallSpeed * Time.deltaTime);
        es.transform.position = Vector3.Lerp(es.transform.position, currentPosition, Time.deltaTime * 10);

        if (Vector3.Distance(es.transform.position, targetPosition) < 0.4f)
        {
            hietakissa.gameObject.SetActive(true);
            es.gameObject.SetActive(false);
            GameManager.Instance.AddCollectible(Enums.CollectibleType.PowerSource);
            completed = true;
        }

    }

    protected override void Click()
    {
        if (completed) return;

        currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, 1f);

    }
}
