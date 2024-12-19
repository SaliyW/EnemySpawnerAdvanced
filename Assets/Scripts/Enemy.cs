using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Target _target;
    private float _speed;
    private Vector3 _targetEnlarger = new(0.1f, 0.1f, 0.1f);

    public Vector3 TargetEnlarger => _targetEnlarger;

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
}