using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PanoramaGenerator : ScriptableWizard
{
    [Header("Tools/360 ȫ�����")]
    public Camera panoramaCamera;
    string[] skyBoxImage = new string[] { "_back", "_right", "_front", "_left", "_up", "_bottom" };
    Vector3[] skyDirection = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, -90, 0), new Vector3(0, 180, 0), new Vector3(0, 90, 0), new Vector3(-90, 180, 0), new Vector3(90, 180, 0) };
    [Header("��ȡͼƬ�ߴ磬���Ϊ 2��N�η�")]
    public int ScreenSize = 2048;
    [Header("SkyBox")]
    public Cubemap cubemap;

    void OnWizardUpdate()
    {
        helpString = "Select transform to render from";
        isValid = (panoramaCamera != null);
    }

    void OnWizardCreate()
    {
        panoramaCamera.backgroundColor = Color.black;
        panoramaCamera.clearFlags = CameraClearFlags.Skybox;
        panoramaCamera.fieldOfView = 90;
        panoramaCamera.aspect = 1.0f;
        panoramaCamera.transform.rotation = Quaternion.identity;

        for (var orientation = 0; orientation < skyDirection.Length; orientation++)
        {
            renderSkyImage(orientation, panoramaCamera.gameObject);
        }
        if (cubemap)
        {
            panoramaCamera.RenderToCubemap(cubemap);
        }

    }

    [MenuItem("360 ȫ��/ ��Ⱦ6��ͼ", false, 4)]
    static void RenderSkyBox()
    {
        ScriptableWizard.DisplayWizard<PanoramaGenerator>("Render SkyBox", "��Ⱦ!");
    }

    void renderSkyImage(int orientation, GameObject go)
    {
        try
        {
            go.transform.eulerAngles = skyDirection[orientation];
            var screenSize = ScreenSize;
            RenderTexture rt = new RenderTexture(screenSize, screenSize, 24);
            go.GetComponent<Camera>().targetTexture = rt;
            var screenShot = new Texture2D(screenSize, screenSize, TextureFormat.RGBA32, false);
            go.GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, screenSize, screenSize), 0, 0);
            RenderTexture.active = null;
            var bytes = screenShot.EncodeToPNG();
            var directory = "Assets/xyh/Skyboxes";
            if (!System.IO.Directory.Exists(directory))
                System.IO.Directory.CreateDirectory(directory);
            System.IO.File.WriteAllBytes(System.IO.Path.Combine(directory, skyBoxImage[orientation] + ".png"), bytes);
            DestroyImmediate(rt);
        }
        catch (System.Exception ex)
        {
        }
    }

}