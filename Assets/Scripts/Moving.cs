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
        if (pointInPath == null)
            return;
    }

    public void Update()
    {
        if (pointInPath == null)
         return; 

        transform.position = Vector3.MoveTowards(transform.position, pointInPath.transform.position, Time.deltaTime * _speed);

        var distance = (transform.position - pointInPath.transform.position).sqrMagnitude;
        
        if (distance < _maxDistance * _maxDistance)
        {
            pointInPath = _path.GetNextPathPoint();
        }

    }
}
