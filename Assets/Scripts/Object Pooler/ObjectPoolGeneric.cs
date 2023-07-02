using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolGeneric<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] Stack<T> _pooledObjects = new Stack<T>();
    public T PrefabToPool;
    public int NumToPool;
    private int _numberOfActiveObjects = 0;
    public Stack<T> PooledObjects { get => _pooledObjects; set => _pooledObjects = value; }


    private void OnDestroy()
    {
        _pooledObjects.Clear();
        _numberOfActiveObjects = 0;
    }
    public void Awake()
    {
        for (int i = 0; i < NumToPool; i++)
        {
            T newPooledObject = Instantiate(PrefabToPool, transform);
            _pooledObjects.Push(newPooledObject);
            newPooledObject.gameObject.SetActive(false);
        }
    }

    public T GetPooledObject()
    {
        if(_pooledObjects.Count > 0 && _pooledObjects.Peek().gameObject.activeSelf == false )
        {
            T poppedObject = _pooledObjects.Pop();
            poppedObject.gameObject.SetActive(true);
            return poppedObject;
        }

        T newPooledObject = Instantiate(PrefabToPool, transform);
        newPooledObject.gameObject.SetActive(true);
        _numberOfActiveObjects++;
        return newPooledObject;

    }

    public void PushPooledInstance(T instance)
    {
        _pooledObjects.Push(instance);
        instance.gameObject.SetActive(false);
    }

}
