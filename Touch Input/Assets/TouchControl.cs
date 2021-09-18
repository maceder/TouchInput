using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    [SerializeField] private float range;
    private float _moveX;
    private Vector3 _pos;
    private Camera _cam;
    private Touch touch;
    private void Awake()
    {
        _cam = Camera.main;
    }
    private void Update()
    {
        Swerve();
        Move();
    }
    private void Move()
    {
        var x = Mathf.Clamp(_moveX, -.5f, .5f) * range;
        gameObject.transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    private void Swerve()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _pos = _cam.ScreenToViewportPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 get = _cam.ScreenToViewportPoint(touch.position);
                _moveX = get.x - _pos.x;
            }
        }

    }
}
