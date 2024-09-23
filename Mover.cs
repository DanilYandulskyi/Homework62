using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private float _initialSpeed;

    public float Speed => _speed;

    private void Awake()
    {
        _initialSpeed = _speed;
    }

    public void Move(Vector3 direction)
    {
        if (_speed == 0)
            _speed = _initialSpeed;

        Vector3 offset = direction.normalized * (_speed * Time.deltaTime);
        transform.Translate(offset);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void Stop()
    {
        _speed = 0;
    }
}
