using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsInfoManager : MonoBehaviour
{
    public static GoodsInfoManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    public Dictionary<LayerType, string> goodsinfo = new Dictionary<LayerType, string>();

    // Start is called before the first frame update
    void Start()
    {
        goodsinfo.Add(LayerType.ximei1, "SunPrune,10001");
        goodsinfo.Add(LayerType.ximei2, "SunPrune,10001");
        goodsinfo.Add(LayerType.ximei3, "SunPrune,10001");

        goodsinfo.Add(LayerType.shoes, "UGG,10001");

        goodsinfo.Add(LayerType.xinren, "Almond,10001");

        goodsinfo.Add(LayerType.cupgray, "Zhizhou,10001");
        goodsinfo.Add(LayerType.cupgreen, "Zhizhou,10001");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetGoodsName(LayerType type)
    {
        string info = goodsinfo[type];
        return info.Split(",")[0];
    }

    public string GetGoodsId(LayerType type)
    {
        string info = goodsinfo[type];
        return info.Split(",")[1];
    }
}
