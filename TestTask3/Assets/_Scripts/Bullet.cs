using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool _inited = false;
    private Action _winEvent;
    private Settings _settings;
    private float _hp;
    private void FixedUpdate()
    {
        if (_inited)
        {
            transform.position += transform.forward * Time.deltaTime * _settings.bulletSpeed;
        }
    }
    public void Shot(Action winEvent, Settings settings)
    {
        _hp = transform.localScale.y;
        transform.SetParent(null);
        _settings = settings;
        _winEvent = winEvent;
        _inited = true;
    }
    private void OnTriggerStay(Collider other)
    {
        Obstacles obstacles = other.GetComponent<Obstacles>();
        if (obstacles && _settings)
        {
            if (obstacles.Infected) return;
            if (_hp > _settings.obstaclesPower) obstacles?.Infection();
            _hp -= _settings.obstaclesPower;
            if (_hp <= 0) Destroy(gameObject);
        }
    }
}
