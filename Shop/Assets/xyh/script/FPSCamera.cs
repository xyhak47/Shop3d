using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public static FPSCamera Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    public float moveSpeed = 10;
    public float rotateSpeed = 10;

    Vector3 prevMousePos;
    Vector3 mouseDelta;
    Vector3 viewVector;
    Vector3 viewUp;


    // Start is called before the first frame update
    void Start()
    {
        prevMousePos = Vector3.zero;
        mouseDelta = Vector3.zero;
        viewVector = transform.forward;
        viewUp = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraViewPreset.Instance.lock_camera) return;


#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            moveSpeed += Input.mouseScrollDelta.y * moveSpeed / 4;
        }

        if (Input.GetMouseButtonDown(1))
        {
            prevMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            mouseDelta = Input.mousePosition - prevMousePos;
            prevMousePos = Input.mousePosition;

            if (Mathf.Abs(mouseDelta.x) >= Mathf.Abs(mouseDelta.y))
            {
                viewVector = Quaternion.AngleAxis(mouseDelta.x * rotateSpeed * Time.deltaTime, transform.up) * viewVector;
            }
            else
            {
                viewVector = Quaternion.AngleAxis(-mouseDelta.y * rotateSpeed * Time.deltaTime, transform.right) * viewVector;
            }

            transform.LookAt(transform.position + viewVector, viewUp);

        }

        /*        if (Input.GetKey("q"))
                {
                    viewUp = Quaternion.AngleAxis(10 * rotateSpeed * Time.deltaTime, transform.forward) * viewUp;
                }
                if (Input.GetKey("e"))
                {
                    viewUp = Quaternion.AngleAxis(-10 * rotateSpeed * Time.deltaTime, transform.forward) * viewUp;
                }*/



        /*        if (Input.GetKey("w"))
                {
                    transform.position += (transform.forward * moveSpeed * Time.deltaTime);
                }
                if (Input.GetKey("s"))
                {
                    transform.position += (-transform.forward * moveSpeed * Time.deltaTime);
                }
                if (Input.GetKey("a"))
                {
                    transform.position += (-transform.right * moveSpeed * Time.deltaTime);
                }
                if (Input.GetKey("d"))
                {
                    transform.position += (transform.right * moveSpeed * Time.deltaTime);
                }
                if (Input.GetKey("r"))
                {
                    transform.position += (transform.up * moveSpeed * Time.deltaTime);
                }
                if (Input.GetKey("f"))
                {
                    transform.position += (-transform.up * moveSpeed * Time.deltaTime);
                }*/
#endif
    }

    public void UpdateCamera()
    {
    }
}
