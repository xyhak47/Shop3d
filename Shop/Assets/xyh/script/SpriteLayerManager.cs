using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerManager : MonoBehaviour
{
    public static SpriteLayerManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }


    [System.Serializable]
    public class SpriteLayer
    {
        public GameObject layer;
        public LayerType type;
    }

    public List<SpriteLayer> List_SpriteLayer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHandleSpriteClick(string name)
    {
        Debug.Log("OnHandleSpriteClick : name = " + name);
        if(name == "back")
        {
            GameSetting.Instance.OnHandleSwithLayer(LayerType.main);
        }
        else if(name == "shoes")
        {
            GameSetting.Instance.OnHandleSwithLayer(LayerType.shoes);
        }
        else if (name == "ximei1")
        {
            GameSetting.Instance.OnHandleSwithLayer(LayerType.ximei1);
        }
        else if (name == "ximei2")
        {
            GameSetting.Instance.OnHandleSwithLayer(LayerType.ximei2);
        }
        else if (name == "ximei3")
        {
            GameSetting.Instance.OnHandleSwithLayer(LayerType.ximei3);
        }
        else if (name == "cupgreen")
        {
            GameSetting.Instance.OnHandleSwithLayer(LayerType.cupgreen);
        }
        else if (name == "cupgray")
        {
            GameSetting.Instance.OnHandleSwithLayer(LayerType.cupgray);
        }
        else if (name == "xinren")
        {
            GameSetting.Instance.OnHandleSwithLayer(LayerType.xinren);
        }
        else if (name == "detail")
        {
            GameSetting.Instance.EnterGoodsDetailPage();
        }
    }

    public void ShowLayer(LayerType layer)
    {
        List_SpriteLayer.ForEach(l => l.layer.SetActive(l.type == layer));

        SpriteLayer backlayer = List_SpriteLayer.Find(l => l.type == LayerType.back);
        backlayer.layer.SetActive(layer != LayerType.main);
    }
}
