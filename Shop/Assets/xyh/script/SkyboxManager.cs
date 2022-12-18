using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    [System.Serializable]
    public enum Type
    {
         main
    }

    [System.Serializable]
    public struct Skybox
    {
        public Material material;
        public Type type;
    }

    public List<Skybox> List_Skybox;


    // Start is called before the first frame update
    void Start()
    {
        Skybox main = List_Skybox.Find(skybox => skybox.type == Type.main);
        RenderSettings.skybox = main.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
