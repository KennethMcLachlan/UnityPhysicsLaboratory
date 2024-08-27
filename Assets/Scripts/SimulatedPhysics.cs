using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulatedPhysics : MonoBehaviour
{
    //Create a reference for the new simulated scene
    private Scene _simulatedScene;

    //Create a regerence to the physics scene of the simulated scene
    private PhysicsScene _physicsScene;

    //Create a reference to the lab parent
    [SerializeField] private Transform _labParent;

    void Start()
    {
        //Set the lab parent
        _labParent = gameObject.transform.parent.root;

        //Call the new Create Simulated Physics Scene Method
        CreateSimulatedPhysicsScene();
    }

    //Create a new method for Creating the Simulated Physics Scene
    void CreateSimulatedPhysicsScene()
    {
        //Set the new Created Scene to the simulated scene reference
        _simulatedScene = SceneManager.CreateScene("SimulatedPhysics", new CreateSceneParameters(LocalPhysicsMode.Physics3D));

        //Set the new Physics scene from the simulated scene
        _physicsScene = _simulatedScene.GetPhysicsScene();

        //For each object tagged Obstacle in the lab parent
        foreach (Transform obstacle in _labParent)
        {
            if (obstacle.CompareTag("Obstacle"))
            {
                //Create a reference for the simulate obastacles and instantiate the new obstacles
                var simulatedObstacle = Instantiate(obstacle.gameObject, obstacle.position, obstacle.rotation);

                //Get the mesh renderer of each obstacle and disable it
                if (obstacle.GetComponent<Renderer>() != null)
                {
                    obstacle.GetComponent<Renderer>().enabled = false;
                }

                SceneManager.MoveGameObjectToScene(simulatedObstacle, _simulatedScene);
            }
        }
    }

    //Reference for the line renderer
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _maxPhysicsIterations;

    public void SimulateTrajectory(AirMailPackage airMailPackagePrefab, Vector3 pos, Vector3 velocity)
    {
        //Reference for a simulate object (_airMailPackage)
        var simulatedObj = Instantiate(airMailPackagePrefab, pos, Quaternion.identity);

        //Simulate object renderer is disabled
        simulatedObj.GetComponent<Renderer>().enabled = false;

        //Move the simulated object to the simulated physics scene
        SceneManager.MoveGameObjectToScene(simulatedObj.gameObject, _simulatedScene);

        //Apply Velocity to the simulated object using the Init function
        simulatedObj.Init(velocity);

        //Set the amount of points in the line renderer component
        _line.positionCount = _maxPhysicsIterations;

        //In a for loop, set the positions of the Line Renderer based on a max physics interactions value
        for (int i = 0; i < _maxPhysicsIterations; i++)
        {
            //Simulate the physics scene
            _physicsScene.Simulate(Time.fixedDeltaTime * 4);

            //Set the positions of each poent on the Line Renderer using the simulated object position
            _line.SetPosition(i, simulatedObj.transform.position);
        }

        //Destroy the simulated objects
        Destroy(simulatedObj.gameObject);
    }


}
