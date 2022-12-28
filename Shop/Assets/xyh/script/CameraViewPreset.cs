using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewPreset : MonoBehaviour
{
    public static CameraViewPreset Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    private Vector3 pre_camera_rotation = new Vector3(0, 180, 0);


    public bool lock_camera = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLayer(LayerType layer)
    {
        if (layer == LayerType.main)
        {
            Camera.main.transform.eulerAngles = pre_camera_rotation;

            lock_camera = false;

        }
        else if (layer == LayerType.shoes)
        {
            // store pre
            pre_camera_rotation = Camera.main.transform.eulerAngles;

            Camera.main.transform.eulerAngles = new Vector3(5, 300, 0);

            lock_camera = true;
        }
        else if (layer == LayerType.cupgreen)
        {
            // store pre
            pre_camera_rotation = Camera.main.transform.eulerAngles;

            Camera.main.transform.eulerAngles = new Vector3(5, 334, 0);

            lock_camera = true;
        }
        else if (layer == LayerType.cupgray)
        {
            // store pre
            pre_camera_rotation = Camera.main.transform.eulerAngles;

            Camera.main.transform.eulerAngles = new Vector3(5, 396, 0);

            lock_camera = true;
        }
        else if (layer == LayerType.ximei1)
        {
            // store pre
            pre_camera_rotation = Camera.main.transform.eulerAngles;

            Camera.main.transform.eulerAngles = new Vector3(5, 270, 0);

            lock_camera = true;
        }
        else if (layer == LayerType.ximei2)
        {
            // store pre
            pre_camera_rotation = Camera.main.transform.eulerAngles;

            Camera.main.transform.eulerAngles = new Vector3(5, 280, 0);

            lock_camera = true;
        }
        else if (layer == LayerType.ximei3)
        {
            // store pre
            pre_camera_rotation = Camera.main.transform.eulerAngles;

            Camera.main.transform.eulerAngles = new Vector3(5, 192, 0);

            lock_camera = true;
        }
        else if (layer == LayerType.xinren)
        {
            // store pre
            pre_camera_rotation = Camera.main.transform.eulerAngles;

            Camera.main.transform.eulerAngles = new Vector3(5, 315, 0);

            lock_camera = true;
        }

        MobileTouch.Instance.ResetCamera();
    }
}
