using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{

    [SerializeField] Color col;
    public GameObject colorSphere;

    private void Awake()
    {
        colorSphere.GetComponent<Renderer>().material.SetColor("_Color", col);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
