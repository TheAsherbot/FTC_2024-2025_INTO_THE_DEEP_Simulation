using UnityEngine;

public class OdometeryAlgorithum
{
    private OdometerySettingsSO odometerySettingsSO;

    private OdometeryPod leftOdometer;
    private OdometeryPod rightOdometer;
    private OdometeryPod backOdometer;

    private int lastLeftTick;
    private int lastRightTick;
    private int lastBackTick;


    private float x;
    private float z;
    private float rotation;
    private float rotationInRadians;


    public OdometeryAlgorithum(OdometeryPod leftOdometer, OdometeryPod rightOdometer, OdometeryPod backOdometer, OdometerySettingsSO odometerySettingsSO)
    {
        this.leftOdometer = leftOdometer;
        this.rightOdometer = rightOdometer;
        this.backOdometer = backOdometer;

        this.odometerySettingsSO = odometerySettingsSO;
    }

    public void ResetPosition()
    {
        lastLeftTick = leftOdometer.Ticks;
        lastRightTick = rightOdometer.Ticks;
        lastBackTick = backOdometer.Ticks;

        x = 0;
        z = 0;
        rotation = 0;
    }


    public void SetPosition(float x, float z, float rotation)
    {
        this.x = x;
        this.z = z;
        this.rotation = rotation;
    }


    public void Update()
    {
        // Units = mm
        float xDelta = 0;
        float zDelta = 0;
        int rightEncoderValue = rightOdometer.Ticks;
        int leftEncoderValue = leftOdometer.Ticks;
        int backEncoderValue = backOdometer.Ticks;

        float leftDelta = (rightEncoderValue - lastLeftTick) * odometerySettingsSO.DistancePerTick;
        float rightDelta = (leftEncoderValue - lastRightTick) * odometerySettingsSO.DistancePerTick;
        float backDelta = (backEncoderValue - lastBackTick) * odometerySettingsSO.DistancePerTick;

        lastLeftTick = rightEncoderValue;
        lastRightTick = leftEncoderValue;
        lastBackTick = backEncoderValue;

        float rotationDelta = ((leftDelta - rightDelta) / (odometerySettingsSO.sideWheelsOffsetDistance * 2));

        if (rotationDelta == 0)
        {
            xDelta = backDelta;
            zDelta = rightDelta;
        }
        else
        {
            // xDelta = 2 * Mathf.Sin(rotationDelta / 2 * (backDelta / rotationDelta + odometerySettingsSO.backWheelOffsetDistance));
            // zDelta = rightDelta / rotationDelta + odometerySettingsSO.sideWheelsOffsetDistance;
        }


        // Rotating the Movement from Robot-Centric to Field-Centric;
        float averageOrientation = Mathf.Rad2Deg * (rotationInRadians + (rotationDelta / 2));
        x += xDelta;// (xDelta * Mathf.Sin(averageOrientation));
        z += zDelta;// (zDelta * Mathf.Cos(averageOrientation));

        rotationInRadians += rotationDelta;

        rotation = -Mathf.Rad2Deg * rotationInRadians;

        Debug.Log("x: " + x.ToString("0000.0"));
        Debug.Log("z: " + z.ToString("0000.0"));
        Debug.Log("rotation: " + rotation.ToString("####.##"));
    }

}
