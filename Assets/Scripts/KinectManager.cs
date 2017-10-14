﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Windows.Kinect;

using System.Linq;

public class KinectManager : MonoBehaviour {

    private KinectSensor _sensor;
    private BodyFrameReader _bodyFrameReader;
    private Body[] _bodies = null;

    public GameObject kinectAvailableText;
    public Text handXText;
    private ulong personID = 0;
    public bool IsAvailable;

    public Vector3 handLeft;
    public Vector3 handRight;

    public static KinectManager instance = null;

    public Body[] GetBodies()
    {
        return _bodies;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        _sensor = KinectSensor.GetDefault();

        if (_sensor != null)
        {
            IsAvailable = _sensor.IsAvailable;

            kinectAvailableText.SetActive(IsAvailable);

            _bodyFrameReader = _sensor.BodyFrameSource.OpenReader();

            if (!_sensor.IsOpen)
            {
                _sensor.Open();
            }

            _bodies = new Body[_sensor.BodyFrameSource.BodyCount];
        }
    }
	
	// Update is called once per frame
	void Update () {
        IsAvailable = _sensor.IsAvailable;
        CameraSpacePoint postion;

        if (_bodyFrameReader != null)
        {
            var frame = _bodyFrameReader.AcquireLatestFrame();

            if (frame != null)
            {
                frame.GetAndRefreshBodyData(_bodies);

                foreach (var body in _bodies.Where(b => b.IsTracked))
                {
                    IsAvailable = true;

                    if (body.TrackingId == personID)
                    {
                        postion = body.Joints[JointType.HandLeft].Position;
                        handLeft = new Vector3(postion.X, postion.Y, postion.Z);
                        postion = body.Joints[JointType.HandRight].Position;
                        handRight = new Vector3(postion.X, postion.Y, postion.Z);

                    } else {
                        personID = Calibrate();
                    }

                }
            }

            frame.Dispose();
            frame = null;
        }

    }

    //Calibrate which person to track
    ulong Calibrate ()
    {
        float[] distance = new float[_bodies.Length];
        int i = 0;
        CameraSpacePoint position;
        foreach (Body pers in _bodies) {
            position = pers.Joints[JointType.Head].Position;
            distance[i] = Mathf.Sqrt((position.X * position.X) + (position.Y * position.Y) + (position.Z * position.Z));
            i++;
        }

        float min = distance[i];
        ulong id = _bodies[i].TrackingId;
        for (i = 0; i < distance.Length; i++) {
            if (min > distance[i])
            {
                min = distance[i];
                id = _bodies[i].TrackingId;
            }
        }

        return id;
    }

    void OnApplicationQuit()
    {
        if (_bodyFrameReader != null)
        {
            _bodyFrameReader.IsPaused = true;
            _bodyFrameReader.Dispose();
            _bodyFrameReader = null;
        }

        if (_sensor != null)
        {
            if (_sensor.IsOpen)
            {
                _sensor.Close();
            }

            _sensor = null;
        }
    }
}
