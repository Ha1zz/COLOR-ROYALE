using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringColor : MonoBehaviour
{
    public GameObject colorSphere;
    [SerializeField] LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line.startColor = colorSphere.transform.GetComponent<Renderer>().material.GetColor("_Color");
        line.endColor = colorSphere.transform.GetComponent<Renderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 p1 = colorSphere.transform.position;

        if (Physics.SphereCast(p1,colorSphere.transform.localScale.x,transform.forward,out hit,6) && hit.transform.tag == "Cube")
        {
            hit.transform.GetComponent<Renderer>().material.color = colorSphere.transform.GetComponent<Renderer>().material.GetColor("_Color");
            hit.transform.GetComponent<CubeScript>().whoHitMe = transform.tag;
                                    
        }
    }
}
