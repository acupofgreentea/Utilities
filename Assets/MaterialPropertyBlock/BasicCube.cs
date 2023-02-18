using System;
using UnityEngine;

[ExecuteAlways]
public class BasicCube : MonoBehaviour
{
    [SerializeField] private Color color;

    private Renderer rend;

    private MaterialPropertyBlock materialPropertyBlock;

    public MaterialPropertyBlock MaterialPropertyBlock
    {
        get
        {
            if (materialPropertyBlock == null)
                materialPropertyBlock = new MaterialPropertyBlock();

            return materialPropertyBlock;
        }
    }

    private readonly int colorID = Shader.PropertyToID("_Color");

    
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnValidate()
    {
        ChangeColor();    
    }

    private void ChangeColor()
    {
        if (rend == null) rend = GetComponent<Renderer>();
        MaterialPropertyBlock.SetColor(colorID, color);
        rend.SetPropertyBlock(MaterialPropertyBlock);
    }
    
    private void OnEnable() => CubeContainer.AddToList(this);

    private void OnDisable() => CubeContainer.RemoveFromList(this);
}
