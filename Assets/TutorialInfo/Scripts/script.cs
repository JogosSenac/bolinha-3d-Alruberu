using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class MovimentoTextura: MonoBehaviour
{
    [SerializeField] private float speedY;
    [SerializeField] private float speedX;
    private MeshRenderer Rend;
    // Start is called before the first frame update
    void Start()
    {
        Rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Rend.material.mainTextureOffset = new Vector2 ( speedX * Time.timeSinceLevelLoad, speedY * Time.timeSinceLevelLoad);
    }
}
