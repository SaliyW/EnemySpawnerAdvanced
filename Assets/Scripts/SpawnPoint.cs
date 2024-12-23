using UnityEngine;
using UnityEngine.Pool;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Color _enemyColor;
    [SerializeField] private float _enemySpeed = 1;
    [SerializeField] private Target _target;
    [SerializeField] private int _poolDefaultCapacity = 10;
    [SerializeField] private int _poolMaxSize = 20;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
        createFunc: () => Instantiate(_enemyPrefab, transform.position, Quaternion.identity),
        actionOnGet: (obj) => ActionOnGet(obj),
        actionOnRelease: (obj) => obj.gameObject.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj),
        collectionCheck: true,
        defaultCapacity: _poolDefaultCapacity,
        maxSize: _poolMaxSize);
    }

    public void Spawn()
    {
        _pool.Get();
    }

    private void ActionOnGet(Enemy obj)
    {
        obj.transform.position = transform.position;
        obj.SetSpeed(_enemySpeed);
        obj.SetTarget(_target);
        obj.SetColor(_enemyColor);
        obj.SetVelocity(Vector3.zero);
        obj.gameObject.SetActive(true);
    }
}