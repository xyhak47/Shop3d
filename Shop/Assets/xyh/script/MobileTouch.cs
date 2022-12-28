using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileTouch : MonoBehaviour
{
    public static MobileTouch Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    private float rotateSpeed = 5;


    private int isforward;
                          
    private Vector2 oposition1 = new Vector2();
    private Vector2 oposition2 = new Vector2();

    Vector2 m_screenPos = new Vector2();


    Vector3 viewVector;
    Vector3 viewUp;

    bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        float leng1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        float leng2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (leng1 < leng2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
        Input.multiTouchEnabled = true;
        viewVector = transform.forward;
        viewUp = transform.up;
    }

    public void ResetCamera()
    {
        viewVector = transform.forward;
        viewUp = transform.up;
    }

    void Update()
    {
        //if (CameraViewPreset.Instance.lock_camera) return;


        if (Input.touchCount <= 0)
            return;
        if (Input.touchCount == 1) 
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                m_screenPos = Input.touches[0].position;
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Vector2 touch_delta = Input.touches[0].deltaPosition;
                if (touch_delta.magnitude <= 2.5f)
                {
                    return;
                }

                //log.text = "touch_delta.x = " + touch_delta.x + "  touch_delta.y = " + touch_delta.y;
                viewVector = Quaternion.AngleAxis(touch_delta.x * rotateSpeed * Time.deltaTime, transform.up) * viewVector;
                viewVector = Quaternion.AngleAxis(-touch_delta.y * rotateSpeed * Time.deltaTime, transform.right) * viewVector;

                //if (Mathf.Abs(touch_delta.x) >= Mathf.Abs(touch_delta.y))
                //{
                //    viewVector = Quaternion.AngleAxis(touch_delta.x * rotateSpeed * Time.deltaTime, transform.up) * viewVector;
                //}
                //else
                //{
                //    viewVector = Quaternion.AngleAxis(-touch_delta.y * rotateSpeed * Time.deltaTime, transform.right) * viewVector;
                //}


                transform.LookAt(transform.position + viewVector, viewUp);
                //UIHandler.Instance.text.text = "camera z = " + transform.eulerAngles.z;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

                //transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime, Input.touches[0].deltaPosition.y * Time.deltaTime, 0));
            }
        } 
    }
}

