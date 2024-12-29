using UnityEngine;

public class OdometerySetup : MonoBehaviour
{
    [SerializeField] private OdometerySettingsSO odometerySettingsSO;
 
    [Header("Odometer Pods")]
    [SerializeField] private Transform leftOdometer;
    [SerializeField] private Transform rightOdometer;
    [SerializeField] private Transform backOdometer;



    private void Start()
    {
        
    }

}
