using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteClick : MonoBehaviour
{
    private string name;

    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpriteClick()
    {
        SpriteLayerManager.Instance.OnHandleSpriteClick(name);
    }

}
