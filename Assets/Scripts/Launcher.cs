using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //Reference to the simulated physics script
    [SerializeField] private SimulatedPhysics _simulatedPhysics;

    //Create a reference to the package prefab
    [SerializeField] private AirMailPackage _airMailPackagePrefab;
    //Create a refrence to the amount of force to apply
    [SerializeField] private float _force = 10f;

    [SerializeField] private LabComplete _labComplete;

    private void FixedUpdate()
    {
        //call the simulated trajectory method from the SimulatedPhysics script
        //Pass in the prefab to instantiate, the position, and the direction multiply by the force
        _simulatedPhysics.SimulateTrajectory(_airMailPackagePrefab, transform.position, transform.forward * _force);

    }
    private void Update()
    {

        //Get the input from the player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate the package prefab and apply the force
            var spawned = Instantiate(_airMailPackagePrefab, transform.position, transform.rotation);

            //Tell the package where to intantiate
            spawned.transform.parent = gameObject.transform.root;

            spawned.Init(transform.forward * _force);

            _labComplete.CheckCriteria();
            //Call the Init function from the package

        }
    }
}
