using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var target = Camera.main.transform.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}
