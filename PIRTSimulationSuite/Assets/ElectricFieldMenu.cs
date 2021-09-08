using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFieldMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject chargePrefab;

    public GameObject parent;

    public GameObject eFieldSim;
    public void CreateCharge()
    {
        Instantiate(chargePrefab, parent.transform);
    }

    public void DisableSimulation()
    {
        eFieldSim.SetActive(false);
    }

    public void EnableSimulation()
    {
        eFieldSim.SetActive(true);

    }
}
