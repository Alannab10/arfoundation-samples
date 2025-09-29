using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARObjectPlacer : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject prefabToSpawn;
    public PlayerInput inputs; 

    void Awake()
    {
    }

    void FixedUpdate()
    {
        if (inputs.actions["Press"].WasPressedThisFrame())
        {
            Debug.Log("IsPressed");
            Ray ray = Camera.main.ScreenPointToRay(inputs.actions["Position"].ReadValue<Vector2>());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Instantiate(prefabToSpawn, hit.collider.transform.position, Quaternion.identity);
            }
        }
    }
}