using UnityEngine;

[CreateAssetMenu(fileName = "Odometery Settings", menuName = "Odometery/Odometery Settings", order = 1)]
public class OdometerySettingsSO : ScriptableObject
{

    /// <summary>
    /// Distance in Milimeters, from the center of the robot to the center of the odemetery wheels on the side
    /// </summary>
    [Tooltip("Distance in Milimeters, front the center of the robot to the center of the odemetery wheels on the side")]
    public float sideWheelsOffsetDistance;
    /// <summary>
    /// Distance in Milimeters, from the center of the robot to the center of the odemetery wheel on the back
    /// </summary>
    [Tooltip("Distance in Milimeters, from the center of the robot to the center of the odemetery wheel on the back")]
    public float backWheelOffsetDistance;
    /// <summary>
    /// The Diamter of the Odometery Wheels in Milimeters
    /// </summary>
    [Tooltip("The Diamter of the Odometery Wheels in Milimeters")]
    public float deadWheelDiameter;
    /// <summary>
    /// The number of Ticks the Odometery wheel tracks per rotation
    /// </summary>
    [Tooltip("The number of Ticks the Odometery wheel tracks per rotation")]
    public float odometeryTicksPerRotation;

    public float DistancePerTick
    {
        get
        {
            return deadWheelDiameter * Mathf.PI / odometeryTicksPerRotation;
        }
    }



}
