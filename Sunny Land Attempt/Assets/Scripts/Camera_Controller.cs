using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField]
    Transform targetTransform;

    [SerializeField]
    float minY, maxY;

    Vector2 lastPos;

    [SerializeField]
    Transform downGround, middleGround;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void Update()
    {
        CamLimit();
        GroundMovement();
    }

    void CamLimit()
    {
        transform.position = new Vector3(targetTransform.position.x, Mathf.Clamp(targetTransform.position.y, minY, maxY), transform.position.z);
    }

    void GroundMovement()
    {
        Vector2 between = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        downGround.position += new Vector3(between.x, between.y, 0f);
        middleGround.position += new Vector3(between.x, between.y, 0f)*.5f;
        
        lastPos = transform.position;

    }


}
