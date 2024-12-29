using UnityEngine;

[CreateAssetMenu(fileName = "Odometery Settings", menuName = "Odometery/Odometery Settings", order = 1)]
public class OdometerySettingsSO : ScriptableObject
{

    /// <summary>
    /// Distance in Milimeters, front the center of the robot to the center of the odemetery wheels on the side
    /// </summary>
    public float sideWheelsOffsetDistance;
    /// <summary>
    /// Distance in Milimeters, front the center of the robot to the center of the odemetery wheels on the side
    /// </summary>
    public float backWheelOffsetDistance;
    /// <summary>
    /// The Diamter of the Odometery Wheels in Milimeters
    /// </summary>
    public float deadWheelDiameter;
    /// <summary>
    /// The number of Ticks the Odometery Wheel Compleats per rotation
    /// </summary>
    public float odometeryTicksPerRotation;



}
