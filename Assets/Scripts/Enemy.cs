using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Target _target;
    private float _speed;
    private Color _color;
    private Vector3 _velocity;
    private Vector3 _targetEnlarger = Vector3.one * 0.1f;

    public Vector3 TargetEnlarger => _targetEnlarger;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = _velocity;
        GetComponent<Renderer>().material.color = _color;
    }

    private void Update()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;

        transform.Translate(_speed * Time.deltaTime * direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }
}