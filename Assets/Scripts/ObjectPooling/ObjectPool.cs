using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Object Pooling Design Pattern
/// </summary>
public class ObjectPool : MonoBehaviour
{
    public GameObject _objectToPool;
    public int _startSize;

    [SerializeField] List<PooledObject> _objectPool = new List<PooledObject>();
    [SerializeField] List<PooledObject> _usedPool = new List<PooledObject>();

    PooledObject _tempObject;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        for (int i = 0; i < _startSize; i++)
        {
            AddNewObject();
        }
    }

    void AddNewObject()
    {
        _tempObject = Instantiate(_objectToPool, transform).GetComponent<PooledObject>();
        _tempObject.gameObject.SetActive(false);
        _tempObject.SetObjectPool(this);
        _objectPool.Add(_tempObject);
    }

    public PooledObject GetPooledObject()
    {
        PooledObject _tempObject;
        if (_objectPool.Count > 0)
        {
            _tempObject = _objectPool[0];
            _usedPool.Add(_tempObject);
        }
        else
        {
            AddNewObject();
            _tempObject = GetPooledObject();
        }

        _tempObject.gameObject.SetActive(true);
        _tempObject.ResetObject();

        return _tempObject;
    }

    public void RestoreObject(PooledObject obj)
    {
        obj.gameObject.SetActive(false);
        _usedPool.Remove(obj);
        _objectPool.Add(obj);
    }

    public void DestroyPooledObject(PooledObject obj, float time = 0)
    {
        if (time == 0)
        {
            obj.Destroy();
        }
        else
        {
            obj.Destroy(time);
        }
    }
}
