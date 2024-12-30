using UnityEngine;

public class OdometeryTracker : MonoBehaviour
{

    [SerializeField] private OdometerySetup odometerySetup;


    private OdometeryAlgorithum odometeryAlgorithum;

    private void Awake()
    {
        odometeryAlgorithum = new OdometeryAlgorithum(odometerySetup.leftOdometer, odometerySetup.rightOdometer, odometerySetup.backOdometer, odometerySetup.odometerySettingsSO);
    }

    private void Update()
    {
        odometeryAlgorithum.Update();
    }


}
