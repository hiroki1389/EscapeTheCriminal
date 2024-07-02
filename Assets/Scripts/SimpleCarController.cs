using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// created by Takanaga.
// edited by various members.
// attached to Car_root object.
[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

namespace VarjoExample
{
    public class SimpleCarController : MonoBehaviour
    {
        [SerializeField] private bool mainSceneFlag = false;
        [SerializeField] private GameObject startStop;
        [SerializeField] private GameObject endStop;

        private Rigidbody playerRigidbody;
        private GameObject handle;
        private GameObject carHandle;
        private GameObject CarModel;
        private GameObject player;
        private Rigidbody rigidbody;

        private LogitechSteeringWheel handleAxis;
        private float velocityX;
        private float velocityZ;
        private float trend;

        private const int MAX_VALUE = 32767;
        private const float MAX_MOTOR_TORQUE = 1600.0f;
        private const float MAX_STEERING_ANGLE = 430.0f;
        private float motor;
        private float steering;
        public float MAX_SPEED = 200.0f; // TutorialScriptでRもWも行う
        private float accel;
        private float brake;
        

        [SerializeField] private List<AxleInfo> axleInfos; 

        private void start() { 
        player = GameObject.Find("Car_root");
        }
        
        private void FixedUpdate()
        {
            playerRigidbody = GameObject.Find("Car_root").GetComponent<Rigidbody>();
            handle = GameObject.Find("1stPersonCamera");
            carHandle = GameObject.Find("CarHandle");
            CarModel = GameObject.Find("CarModel");

            velocityX = playerRigidbody.velocity.x;
            velocityZ = playerRigidbody.velocity.z;
            handleAxis = handle.GetComponent<LogitechSteeringWheel>();

            motor = MAX_MOTOR_TORQUE * ((MAX_VALUE - handleAxis.Accelerator) - (MAX_VALUE - handleAxis.Deceleration)) / (2*MAX_VALUE);
            steering = MAX_STEERING_ANGLE * handleAxis.Handlaxisrec / MAX_VALUE;

            float power = -1*steering/MAX_STEERING_ANGLE;
            float speed = velocityX/MAX_SPEED;

            if(steering > 70.0f) steering = 70.0f;
            if(steering < -70.0f) steering = -70.0f;
            
            if(velocityX > 0.0f) accel = 0.05f * (MAX_SPEED - velocityX) / MAX_SPEED * (MAX_VALUE - handleAxis.Accelerator) / MAX_VALUE;
            else accel = 0;

            if(velocityX > 0.0f) brake = -1.0f * velocityX / MAX_SPEED * (MAX_VALUE - handleAxis.Deceleration) / MAX_VALUE;
            else brake = 0;

            playerRigidbody.velocity += new Vector3(accel + brake, 0.0f, -playerRigidbody.velocity.z + 20.0f * power * speed + -1 * 0.02f * steering);
            
            // TutorialSceneにはstartStopとendStopがないため
            if(mainSceneFlag)
            {
                if(playerRigidbody.transform.position.x < startStop.transform.position.x || playerRigidbody.transform.position.x > endStop.transform.position.x)
                {
                    carHandle.transform.rotation = 
                    Quaternion.Euler(-MAX_STEERING_ANGLE * handleAxis.Handlaxisrec/MAX_VALUE, 0.0f, 34*MAX_STEERING_ANGLE*(float)System.Math.Abs(handleAxis.Handlaxisrec)/(MAX_VALUE*360));
                    trend = -MAX_STEERING_ANGLE * handleAxis.Handlaxisrec/(MAX_VALUE*30.0f);
                    if(-4.3f < trend && trend < 4.3f) CarModel.transform.rotation = Quaternion.Euler(trend, 0.0f, 0.0f);
                }
            }
            else
            {
                carHandle.transform.rotation = 
                Quaternion.Euler(-MAX_STEERING_ANGLE * handleAxis.Handlaxisrec/MAX_VALUE, 0.0f, 34*MAX_STEERING_ANGLE*(float)System.Math.Abs(handleAxis.Handlaxisrec)/(MAX_VALUE*360));
                trend = -MAX_STEERING_ANGLE * handleAxis.Handlaxisrec/(MAX_VALUE*30.0f);
                if(-4.3f < trend && trend < 4.3f) CarModel.transform.rotation = Quaternion.Euler(trend, 0.0f, 0.0f);
            }

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }

                if (axleInfo.motor)
                {
                    if(velocityX < 0)
                    {
                        axleInfo.leftWheel.motorTorque = motor + 100.0f;
                        axleInfo.rightWheel.motorTorque = motor + 100.0f;
                    }
                    else if(velocityX > MAX_SPEED)
                    {
                        axleInfo.leftWheel.motorTorque = 0;
                        axleInfo.rightWheel.motorTorque = 0;
                    }
                    else
                    {
                        axleInfo.leftWheel.motorTorque = motor - 300.0f;
                        axleInfo.rightWheel.motorTorque = motor - 300.0f;
                    }
                    if(velocityX < -20.0f) playerRigidbody.velocity -= new Vector3(playerRigidbody.velocity.x+20.0f, 0.0f, 0.0f);
                }
                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }
        }
        
        // 対応する視覚的なホイールを見つけます
        // Transform を正しく適用します
        private void ApplyLocalPositionToVisuals(WheelCollider collider)
        {
            if (collider.transform.childCount == 0) return;
        
            Transform visualWheel = collider.transform.GetChild(0);
        
            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);
        
            visualWheel.transform.position = position;
            visualWheel.transform.rotation = rotation;
        }
    }
}