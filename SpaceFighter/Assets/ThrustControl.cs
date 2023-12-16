using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.VersionControl;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ThrustControl : MonoBehaviour
{
   // public ParticleSystem particleSystem;
    public GameObject player;
    public GameObject camera;
    public CapsuleCollider collider;

    private Rigidbody rigidbody;

    private bool Emmiting  = false;
    private bool rotatingA = false;
    private bool rotatingB = false;
    private bool Dampening = false;

    public Vector3 force;
    public Vector3 bulletForce;
    public bool ai = false;

    public float maxSpeed = 5.0f;

    public GameObject bulletPrefab;

    void Start()
    {
        rigidbody = player.GetComponent<Rigidbody>();
        rigidbody.maxLinearVelocity = maxSpeed;
    }

    void Update()
    {
        if (ai)
        {

        }
        else
        {
            camera.transform.position = player.transform.position;
            camera.transform.position += new Vector3(0, 0, -10);

            //keyDown
            if (Input.GetKeyDown(KeyCode.W))
            {
                Emmiting = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Dampening = true;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                rotatingA = true;

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                rotatingB = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject bullet = Instantiate(bulletPrefab, player.transform.position, player.transform.rotation);
                bullet.GetComponent<DestroyBullet>().ship = gameObject;

                bullet.GetComponent<Rigidbody>().rotation = player.transform.rotation;
                bullet.GetComponent<Rigidbody>().AddRelativeForce(maxSpeed * bulletForce, ForceMode.Acceleration);
            }


            //keyUp
            if (Input.GetKeyUp(KeyCode.W))
            {
                Emmiting = false;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                Dampening = false;
            }


            if (Input.GetKeyUp(KeyCode.A))
            {
                rotatingA = false;

            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                rotatingB = false;
            }




            if (Emmiting)
            {
                rigidbody.AddRelativeForce(force, ForceMode.Acceleration);
            }
            else if (Dampening)
            {
                rigidbody.velocity *= 0.75f;
            }

            if (rotatingA)
            {
                rigidbody.angularVelocity = new Vector3(0, 0, (float)Math.PI);
            }
            else if (rotatingB)
            {
                rigidbody.angularVelocity = new Vector3(0, 0, -(float)Math.PI);
            }
            else
            {
                rigidbody.angularVelocity = new Vector3(0, 0, 0);
            }
        }

    }

}
