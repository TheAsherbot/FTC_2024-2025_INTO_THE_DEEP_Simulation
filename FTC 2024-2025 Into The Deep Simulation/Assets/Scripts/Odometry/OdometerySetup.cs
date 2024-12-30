using UnityEngine;

public class OdometerySetup : MonoBehaviour
{
    public OdometerySettingsSO odometerySettingsSO;
 
    [Header("Odometer Pods")]
    public OdometeryPod leftOdometer;
    public OdometeryPod rightOdometer;
    public OdometeryPod backOdometer;



    private void Start()
    {
        leftOdometer.transform.localPosition = new Vector3(0, 0, -odometerySettingsSO.sideWheelsOffsetDistance / 1000);
        rightOdometer.transform.localPosition = new Vector3(0, 0, odometerySettingsSO.sideWheelsOffsetDistance / 1000);
        backOdometer.transform.localPosition = new Vector3(-odometerySettingsSO.backWheelOffsetDistance / 1000, 0, 0);

        leftOdometer.Init(odometerySettingsSO);
        rightOdometer.Init(odometerySettingsSO);
        backOdometer.Init(odometerySettingsSO);
    }

}
