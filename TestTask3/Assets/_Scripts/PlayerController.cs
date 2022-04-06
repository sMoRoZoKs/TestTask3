using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private GameObject wonMenu;
    [SerializeField] private GameObject lostMenu;
    [SerializeField] private GameObject aim;
    [SerializeField] private Weapoon weapoon;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Door door;
    private void Awake()
    {
        weapoon.Init(() => EndGame(true),() =>  EndGame(false), settings, agent);
        agent?.SetDestination(door.transform.position);
    }
    private void FixedUpdate()
    {
        Look();
        CheckDistanceToDoor();
    }
    private void CheckDistanceToDoor()
    {
        if (Vector3.Distance(door.transform.position, transform.position) < 5)
        {
            door.Open();
            EndGame(true);
        }
    }
    private void Look()
    {
        Vector3 coordinates = GameServices.instance.coordinateController.LastTapCoordinate;
        transform.LookAt(new Vector3(coordinates.x, transform.position.y, coordinates.z));
    }
    private void EndGame(bool isWon)
    {
        agent.isStopped = true;
        aim?.SetActive(false);
        if(isWon) wonMenu.SetActive(true);
        else lostMenu.SetActive(true);
    }

}
