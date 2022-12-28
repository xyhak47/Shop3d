using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public static SkyboxManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    public struct Skybox
    {
        public Material material;
        public LayerType layertype;
    }

    public List<Skybox> List_Skybox;


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
        Skybox current_skybox = List_Skybox.Find(s => s.layertype == layer);
        RenderSettings.skybox = current_skybox.material;
    }
}
