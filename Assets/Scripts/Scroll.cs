using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float xScrollSpeed = 0.1f;
    public float yScrollSpeed = 0.1f;

    private MeshRenderer meshRenderer;
    private float xScroll;
    private float yScroll;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        TextureScroll();
    }

    private void TextureScroll()
    {
        xScroll = Time.time * xScrollSpeed;
        yScroll = Time.time * yScrollSpeed;
        Vector2 offset = new Vector2(yScroll, xScroll);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
