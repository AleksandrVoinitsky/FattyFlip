using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;

public class SkyBoxRandomizer : MonoBehaviour
{
    public Material[] SkyBoxMaterials;
    void Start()
    {
        RenderSettings.skybox = SkyBoxMaterials[Random.Range(0, SkyBoxMaterials.Length)];
    }

    
}
