using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    SpriteRenderer tempRend;

    float height = 0;

    private void Awake()
    {
        tempRend = GetComponent<SpriteRenderer>();
        //GameObject thing = GetComponent<GameObject>();
        //RectTransform rt = (RectTransform) this.transform;
        height = tempRend.bounds.size.y;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        height = tempRend.bounds.size.y;
        tempRend.sortingOrder = (int)(Camera.main.WorldToScreenPoint(this.transform.position).y - height/2 ) * -1;

    }
}
