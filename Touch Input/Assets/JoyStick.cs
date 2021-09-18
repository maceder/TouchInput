using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private Transform knob;

    public float radius;
    public bool isFixed;
    public bool isStatic;
    private Vector2 direction;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isStatic)
            {
                knob.position = Input.mousePosition;
                center.position = Input.mousePosition;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
                isFixed = isStatic;              
        }
        else if (Input.GetMouseButton(0))
        {
            knob.position = Input.mousePosition;

            if(!isFixed)
                center.position = knob.position - Vector3.ClampMagnitude(knob.position - center.position, radius);      
            else
                knob.position = center.position + Vector3.ClampMagnitude(knob.position - center.position, radius);

            direction = (knob.position - center.position).normalized;
        }
        if (Input.GetMouseButtonUp(0))
        {
            knob.position = center.position;
            if (!isStatic)
                transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
