using UnityEngine;

public class OdometeryPod : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector = Vector3.zero;

    private OdometerySettingsSO odometerySettingsSO;

    private float ticks;
    public int Ticks
    {
        get
        {
            return Mathf.RoundToInt(ticks);
        }
    }
    [SerializeField] private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        Vector3 movement = new Vector3(transform.position.x * movementVector.x, transform.position.y * movementVector.y, transform.position.z * movementVector.z) - 
            new Vector3(lastPosition.x * movementVector.x, lastPosition.y * movementVector.y, lastPosition.z * movementVector.z);

        Debug.Log("movement.magnitude: " + movement.magnitude);
        ticks += movement.magnitude * 1000.0f / (odometerySettingsSO.deadWheelDiameter * Mathf.PI) * odometerySettingsSO.odometeryTicksPerRotation;

        lastPosition = transform.position;
    }

    public void Init(OdometerySettingsSO odometerySettingsSO)
    {
        this.odometerySettingsSO = odometerySettingsSO;
    }
}
