using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 _offset;

    private void Awake()
    {
        camera = GameManager.Instance.MainCamera;
    }

    public void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        _slider.value = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + _offset;
    }
}
