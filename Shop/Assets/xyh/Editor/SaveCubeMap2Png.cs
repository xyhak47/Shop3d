using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;

public class SaveCubeMap2Png : ScriptableWizard
{
    public Cubemap cubemap = null;

    [MenuItem("Tools/SaveCubeMap2Png")]
    private static void MenuEntryCall()
    {
        ScriptableWizard.DisplayWizard<SaveCubeMap2Png>("SaveCubeMap2Png", "Save");
    }

    public static void FlipPixels(Texture2D texture, bool flipX, bool flipY)
    {
        Color32[] originalPixels = texture.GetPixels32();

        var flippedPixels = Enumerable.Range(0, texture.width * texture.height).Select(index =>
        {
            int x = index % texture.width;
            int y = index / texture.width;
            if (flipX)
                x = texture.width - 1 - x;

            if (flipY)
                y = texture.height - 1 - y;

            return originalPixels[y * texture.width + x];
        }
        );

        texture.SetPixels32(flippedPixels.ToArray());
        texture.Apply();
    }

    private void OnWizardCreate()
    {
        int width = cubemap.width;
        int height = cubemap.height;
        Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, false);

        for (int i = 0; i < 6; i++)
        {
            texture2D.SetPixels(cubemap.GetPixels((CubemapFace)i));

            //翻转像素，由于某种原因，导出的图片需要进行翻转
            FlipPixels(texture2D, false, true);
            //此处导出为png
            File.WriteAllBytes("Assets/xyh/material/skybox" + "/" + cubemap.name + "_" + ((CubemapFace)i).ToString() + ".png", texture2D.EncodeToPNG());
        }
        DestroyImmediate(texture2D);
    }
    private void OnWizardUpdate()
    {
        helpString = "Select cubemap to save to individual .png";
        if (Selection.activeObject is Cubemap && cubemap == null)
            cubemap = Selection.activeObject as Cubemap;
        isValid = (cubemap != null);
    }
}