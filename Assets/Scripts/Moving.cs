using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Path _path;
    private Transform pointInPath;


    public void Start()
    {
        transform.position = _path.GetStartPosition().transform.position;
        pointInPath = _path.GetNextPathPoint();
    }

    public void FixedUpdate()
    {
        if (pointInPath == null)
            return;

        TrainMoving();
        TrainRotation();
        CheckLastPathPoint();
    }

    void TrainMoving()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointInPath.transform.position, Time.deltaTime * _speed);
    }

    void TrainRotation()
    {
        Vector3 direction = pointInPath.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);   
    }

    void CheckLastPathPoint()
    {
        var distance = (transform.position - pointInPath.transform.position).sqrMagnitude;
        if (distance < _maxDistance * _maxDistance)
            pointInPath = _path.GetNextPathPoint();
        
    }
}
