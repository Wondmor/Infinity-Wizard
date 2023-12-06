using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;
using Object = UnityEngine.Object;

public class Laser : Weapon
{
    private LineRenderer laser;
    private bool isShooting;
    private Vector2 direction;
    private Vector2 mousePos;
    public Camera mainCamera;
    protected override void Start()
    {
        laser = shootPoint.gameObject.GetComponent<LineRenderer>();
    }

    protected override void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - new Vector2(shootPoint.position.x, shootPoint.position.y))
            .normalized;
        shootPoint.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            laser.enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
            laser.enabled = false;
        }

        if (isShooting)
        {
            Fire();
        }
    }

    protected override void Fire()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(shootPoint.position, direction, projectileRange);
        laser.SetPosition(0, shootPoint.position);
        laser.SetPosition(1, hit2D.point);
        //Debug.DrawLine(shootPoint.position,hit2D.point);
    }
}