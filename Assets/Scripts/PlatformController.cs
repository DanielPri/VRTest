using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<Transform> targets;
    public float speed = 1f;
    bool isMoving = false;
    int targetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleImput();

        if (isMoving)
        {
            HandleMovement();
        }
    }

    private void HandleImput()
    {
        if (Input.GetButtonDown("Fire1")) {
            isMoving = !isMoving;
        }
    }

    void HandleMovement() {
        //calculate the distance from our target
        float distance = Vector3.Distance(transform.position, targets[targetIndex].position);

        //check if arrived
        if (distance > 0)
        {
             float step = speed * Time.deltaTime;
             transform.position = Vector3.MoveTowards(transform.position, targets[targetIndex].position, step);
        }
        else {
            targetIndex++;

            if (targetIndex == targets.Count) {
                targetIndex = 0;
            }
        }
        
    }
}
