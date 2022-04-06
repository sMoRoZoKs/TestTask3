using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Weapoon : MonoBehaviour
{
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private Bullet bulletExample;
    [SerializeField] private Transform clip;
    [SerializeField] private float minPlayerSize = 0.1f;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject aim;
    private Bullet _bullet;
    private Settings _settings;
    private Action _winEvent;
    private Action _lostEvent;
    private NavMeshAgent _agent;
    private float _agentScaleForOneStep;

    public void Init(Action winEvent, Action lostEvent, Settings settings, NavMeshAgent agent)
    {
        _agent = agent;
        _winEvent = winEvent;
        _lostEvent = lostEvent;
        SetSettings(settings);
    }
    public void CreateBullet()
    {
        float startBulletSize = _settings.startBulletSize;
        _bullet = Instantiate(bulletExample, bulletPosition);
        _bullet.transform.localScale = new Vector3(startBulletSize,startBulletSize,startBulletSize);
    }
    private void SetSettings(Settings settings)
    {
        if(settings == null)
        {
            Debug.LogError("non settings");
            return;
        } 
        _settings = settings;
        minPlayerSize = settings.minPlayerSize;
    }
    public void IncreaseSizeBullet(float size)
    {
        if(_bullet == null)
        {
            Debug.LogError("bullet not created");
            return;
        }
        aim.SetActive(true);
        if (clip.transform.localScale.y < minPlayerSize) return;
        Vector3 scale = new Vector3(size, size, size);
        _bullet.transform.localScale += scale;
        clip.gameObject.transform.localScale -= scale;
        
        _agentScaleForOneStep = _agent.radius / clip.gameObject.transform.localScale.y * size;
        _agent.radius -= _agentScaleForOneStep;
        aim.transform.localScale -= new Vector3(size, size, size); 
        if (clip.transform.localScale.y < minPlayerSize)
        {
            _lostEvent?.Invoke();
        }
    }
    public void Shot()
    {
        aim.SetActive(false);
        _bullet.Shot(_winEvent, _lostEvent, _settings);
        _bullet = null;
    }
}
