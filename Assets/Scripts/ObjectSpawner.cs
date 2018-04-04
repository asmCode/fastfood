using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject m_spawnPrefab;

    public void DoAction()
    {
        var cook = Cook.Get();
        if (!cook.Inventory.IsRightHandFree)
            return;

        var spawnedObject = Instantiate(m_spawnPrefab, transform.position, transform.rotation);
        cook.GrabRightHand(spawnedObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
