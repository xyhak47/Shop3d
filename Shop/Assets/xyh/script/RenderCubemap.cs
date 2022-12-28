using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RenderCubemap : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera camera;

    private float[] angles_x = { 90, -90 };
    private float[] angles_y = {0, 90, 180, 270};


    void Start()
    {
        camera = GetComponent<Camera>();
        if(camera == null)
        {
            camera = Camera.main;
        }



        // StartRender();
        // _SaveCamTexture();

        CameraCapture(camera);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            StartRender();
            Debug.Log("StartRender");
        }
    }

    public void StartRender()
    {
        foreach(var  x in angles_x)
        {
            camera.transform.eulerAngles = new Vector3(
                x, 
                camera.transform.eulerAngles.y, 
                0);

            _SaveCamTexture();

        }

        foreach (var y in angles_y)
        {
            camera.transform.eulerAngles = new Vector3(
                0,
                y,
                0);

            _SaveCamTexture();
        }
    }

    public RenderTexture rt;
    private void _SaveCamTexture()
    {
        rt = camera.targetTexture;
        if (rt != null)
        {
            _SaveRenderTexture(rt);
            rt = null;
        }
        else
        {
            
            // rt = new RenderTexture(Screen.width, Screen.height, 16, RenderTextureFormat.ARGB32);
            rt = RenderTexture.GetTemporary(Screen.width, Screen.height, 16, RenderTextureFormat.ARGB32);

            camera.targetTexture = rt;
            camera.Render();
            _SaveRenderTexture(rt);
            //Destroy(camera);
            //rt.Release();
            //RenderTexture.ReleaseTemporary(rt);
            //Destroy(rt);
            //rt = null;
        }

    }

    private void _SaveRenderTexture(RenderTexture rt)
    {
        RenderTexture active = RenderTexture.active;
        RenderTexture.active = rt;
        Texture2D png = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
        png.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        png.Apply();
        RenderTexture.active = active;
        byte[] bytes = png.EncodeToPNG();
        string path = string.Format("Assets/xyh/test/rt_{0}_{1}_{2}.png", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        FileStream fs = File.Open(path, FileMode.Create);
        BinaryWriter writer = new BinaryWriter(fs);
        writer.Write(bytes);
        writer.Flush();
        writer.Close();
        fs.Close();
        Destroy(png);
        png = null;
        Debug.Log("±£´æ³É¹¦£¡" + path);
    }

    void CameraCapture(Camera m_Camera)
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 16);
        m_Camera.targetTexture = rt;
        m_Camera.Render();
        RenderTexture.active = rt;
        Texture2D t = new Texture2D(Screen.width, Screen.height);
        t.ReadPixels(new Rect(0, 0, t.width, t.height), 0, 0);
        t.Apply();

        string path = string.Format("Assets/xyh/test/rt_{0}_{1}_{2}.png", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        System.IO.File.WriteAllBytes(path, t.EncodeToJPG());
        m_Camera.targetTexture = null;
    }
}
