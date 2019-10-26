using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBallMaker : MonoBehaviour
{
    public CheeseBall cheeseBall;
    public void MakeCheeseBall()
    {
        var newBall = GameObject.Instantiate(cheeseBall);
        var rigidBody = newBall.gameObject.AddComponent<Rigidbody>();
        newBall.transform.position = transform.position;
        rigidBody.AddForce((transform.forward * 3f) + (Vector3.up * 3f), ForceMode.VelocityChange);
    }

}
