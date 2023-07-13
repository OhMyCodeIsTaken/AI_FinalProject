using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 _offset;

    private void Awake()
    {
        _camera = GameManager.Instance.MainCamera;
    }

    public void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        _slider.value = (float)currentHealth / (float)maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _camera.transform.rotation;
        transform.position = target.position + _offset;
    }
}
