using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HoverableButton : MonoBehaviour
{
    [SerializeField] UnityEvent OnHoverEnter;

    private void OnMouseEnter()
    {
        //OnHoverEnter?.Invoke();
        Debug.Log("yes");
        GameManager.Instance.UIManager.EnablePriceVisibility();
    }

    private void OnMouseExit()
    {
        Debug.Log("yes1");
        GameManager.Instance.UIManager.DisablePriceVisibility();
    }
}
