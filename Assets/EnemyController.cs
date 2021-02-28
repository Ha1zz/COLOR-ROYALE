using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameManager cubeManager;
    public int speed = 5;

    private Vector3 targetLocation;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        targetLocation = SetTargetLocation();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardTarget(targetLocation);
        if (Vector3.Distance(transform.position, targetLocation) > 4.0f)
        {
            //RotateTowardTarget(targetLocation);
            MoveToTarget(targetLocation);
        }
        else
        {
            targetLocation = SetTargetLocation();
        }
    }

    void RotateTowardTarget(Vector3 target)
    {
        Vector3 targetDirection = target - transform.position;
        float singleStep = 50.0f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        //Debug.DrawRay(transform.position, newDirection, Color.red);
    }

    Vector3 SetTargetLocation()
    {
        int seed = Random.Range(0, GameManager.instance.numberOfObjects - 1);
        Vector3 temp = GameManager.instance.cubeArray[seed].transform.position;
        temp.y = transform.position.y;
        return temp;
    }

    void MoveToTarget(Vector3 target)
    {
        animator.SetInteger("Walk",1);
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
