using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public string whoHitMe = "";
    private string currentOwner = "";
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (whoHitMe != "")
        {
            var main = particle.main; ;
            if (currentOwner == "")
            {
                main.startColor = gameObject.transform.GetComponent<Renderer>().material.GetColor("_Color");
                currentOwner = whoHitMe;
                GameManager.instance.AddScore(currentOwner);
                particle.Play();
            }
            else
            {
                if (currentOwner != whoHitMe)
                {
                    main.startColor = gameObject.transform.GetComponent<Renderer>().material.GetColor("_Color");
                    GameManager.instance.AddScore(whoHitMe);
                    GameManager.instance.SubtractScore(currentOwner);
                    currentOwner = whoHitMe;
                    particle.Play();
                }
            }
        }
    }
}
