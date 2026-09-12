using UnityEngine;

public class SwingingMao : MonoBehaviour
{
    [SerializeField] private float startAngle = 30f;
    [SerializeField] private float dropTresholdAngle = 50f;
    [SerializeField] private float pushForce = 100;
    [SerializeField] private GameObject itemToDrop;

    [Header("Physics")]
    [SerializeField] private float gravityStrength = 50f;
    [SerializeField] private float damping = 0.3f;

    private float currentAngle;
    private float angularVelocity;

    private Quaternion initialRotation;
    private bool itemDropped;

    private void Awake()
    {
        initialRotation = transform.localRotation;
        currentAngle = startAngle;
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;

        float gravityAcceleration =
            -Mathf.Sin(currentAngle * Mathf.Deg2Rad) * gravityStrength;

        angularVelocity += gravityAcceleration * deltaTime;

        angularVelocity *= Mathf.Exp(-damping * deltaTime);

        currentAngle += angularVelocity * deltaTime;

        transform.localRotation =
            initialRotation * Quaternion.Euler(0f, 0f, currentAngle);

        if (!itemDropped && Mathf.Abs(currentAngle) >= dropTresholdAngle)
        {
            itemDropped = true;
            itemToDrop.gameObject.SetActive(true);
        }
    }

    public void Push()
    {
        angularVelocity -= Time.deltaTime * pushForce;
    }
}
