using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private CharacterController charactercontroller;
    [SerializeField] private float movingspeed;
    private void OnValidate()
    {
        charactercontroller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hinput = Input.GetAxis("Horizontal");
        float vinput = Input.GetAxis("Vertical");
        Vector3 direction = transform.right * hinput + transform.forward * vinput;
        charactercontroller.SimpleMove(direction * movingspeed);
    }
}
