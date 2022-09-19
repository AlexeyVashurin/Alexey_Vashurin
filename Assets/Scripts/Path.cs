using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private int _moveingTo = 0;
    [SerializeField] private Transform[] _pathElements;

    public void OnDrawGizmos()
    {
        if (_pathElements == null || _pathElements.Length < 2)
            return;

        for (int i = 1; i < _pathElements.Length; i++)
        {
            Gizmos.DrawLine(_pathElements[i-1].position, _pathElements[i].position);
        }
        Gizmos.DrawLine(_pathElements[0].position, _pathElements[_pathElements.Length-1].position);
    }
    public Transform GetNextPathPoint()
    {
        _moveingTo++;
        if (_pathElements == null || _pathElements.Length < 1)
            return null;
        
        if (_moveingTo >= _pathElements.Length)
            _moveingTo = 0;

        return _pathElements[_moveingTo];
    }
    public Transform GetStartPosition()
    {
        return _pathElements[0];
    }
}