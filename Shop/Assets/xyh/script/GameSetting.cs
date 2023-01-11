using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public enum LayerType
{
    main,
    shoes,
    ximei1,
    ximei2,
    ximei3,
    cupgreen,
    cupgray,
    xinren,
    back,
    detail,
}


public class GameSetting : MonoBehaviour
{
    public static GameSetting Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    public LayerType current_layer;

    // Start is called before the first frame update
    void Start()
    {
        //UIHandler.Instance.DebugText("game setting Start");
        MusicPlayer.Instance.PlayBg(true);

        EnterLayer(current_layer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHandleSwithLayer(LayerType type)
    {
        EnterLayer(type);
    }

    private void EnterLayer(LayerType layer)
    {
        current_layer = layer;

        // directly enter detail
        if(layer == LayerType.main)
        {        
            SpriteLayerManager.Instance.ShowLayer(layer);
        }
        else
        {
            MusicPlayer.Instance.PlayBg(false);

            EnterGoodsDetailPage();
        }

        //SpriteLayerManager.Instance.ShowLayer(layer);
        //SkyboxManager.Instance.ShowLayer(layer);
        //CameraViewPreset.Instance.ShowLayer(layer);  
    }

    public void EnterGoodsDetailPage()
    {
        string name = GoodsInfoManager.Instance.GetGoodsName(current_layer);
        string id = GoodsInfoManager.Instance.GetGoodsId(current_layer);

        JSHandler.Instance.EnterGoodsDetailPage(name, id);
    }
}
