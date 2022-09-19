using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Path _path;
    private Transform pointInPath;
    private TrainCharacteristics _trainCharacteristics;
    public void Start()
    {
        transform.position = _path.GetStartPosition().transform.position;
        pointInPath = _path.GetNextPathPoint();
        _trainCharacteristics = TrainCharacteristics.instance;
    }
    public void Update()
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
    public float GetCurrentSpeed()
    {
        return _speed;
    }

    public void SetCurrentSpeed(float targetSpeed)
    {
        StopAllCoroutines();
        if (targetSpeed>0)
        {
            StartCoroutine(AccelerateTrain(targetSpeed));
        }
        else
        {
            StartCoroutine(BrakeTrain(targetSpeed));
        }
    }
    private IEnumerator AccelerateTrain(float targetSpeed)
    {
        if (targetSpeed>0)
        {
            while (_speed < _maxSpeed)
            {
                _speed += targetSpeed / 10;
                yield return new WaitForSeconds(2f);
            }
        }
    }
    private IEnumerator BrakeTrain(float targetSpeed)
    {
        if (targetSpeed < 0.1)
        {
            while (_speed > 0.1)
            {
                _speed -= _speed / 10;
                yield return new WaitForSeconds(0.5f);
            }
            _speed = 0;
            _trainCharacteristics.StopDamage();
        }
    }
}
