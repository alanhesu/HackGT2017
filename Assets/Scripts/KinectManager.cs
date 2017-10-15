using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Windows.Kinect;

using System.Linq;

public class KinectManager : MonoBehaviour {

    private KinectSensor _sensor;
    private BodyFrameReader _bodyFrameReader;
    private Body[] _bodies = null;

    private ulong personID;
    public bool IsAvailable;

    public Vector3 handLeft;
    public Vector3 handRight;
    public float leaningPosition;
    public HandState leftHandStatus;
    public HandState rightHandStatus;

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
        personID = 1;

        if (_sensor != null)
        {
            IsAvailable = _sensor.IsAvailable;

            _bodyFrameReader = _sensor.BodyFrameSource.OpenReader();

            if (!_sensor.IsOpen)
            {
                _sensor.Open();
                Debug.Log("Open");
            }

            _bodies = new Body[_sensor.BodyFrameSource.BodyCount];
        }
    }
	
	// Update is called once per frame
	void Update () {
        IsAvailable = _sensor.IsAvailable;
        CameraSpacePoint postion;
        bool found = false;

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

                        leaningPosition = body.Lean.X;

                        leftHandStatus = body.HandLeftState;
                        rightHandStatus = body.HandRightState;

                        found = true;
                    }

                }
                if (!found)
                {
                    personID = Calibrate();
                }

                frame.Dispose();
                frame = null;
            }        
        }

    }

    //Calibrate which person to track
    ulong Calibrate ()
    {
        float distance;
        ulong id = 0;
        CameraSpacePoint position;
        float min = 99999999;
        foreach (var pers in _bodies.Where(b => b.IsTracked)) {
            position = pers.Joints[JointType.Head].Position;
            distance = Mathf.Sqrt((position.X * position.X) + (position.Y * position.Y) + (position.Z * position.Z));
            if (min > distance)
            {
                min = distance;
                id = pers.TrackingId;
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
