using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings", fileName = "Settings")]
public class Settings : ScriptableObject
{
    public float startPlayerSize = 1;
    public float minPlayerSize = 0.1f;
    public float startBulletSize = 0.1f;
    public float bulletSpeed = 1;
    public float obstaclesPower = 0.1f;
    public int countObstacles = 20;
}
