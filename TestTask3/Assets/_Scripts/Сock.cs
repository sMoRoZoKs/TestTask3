using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сock : MonoBehaviour
{
    [SerializeField] private Weapoon weapoon;
    private bool _isButtonDown = false;
    public void ButtonDown()
    {
        _isButtonDown = true;
        weapoon.CreateBullet();
    }
    public void ButtonUp()
    {
        _isButtonDown = false;
        weapoon.Shot();
    }
    private void FixedUpdate()
    {
        if(!_isButtonDown) return;
        weapoon.IncreaseSizeBullet(Time.deltaTime * 0.5f);
    }
}
