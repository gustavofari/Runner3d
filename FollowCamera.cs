using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 offSet;

    void Awake() {

        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate(){

        FollowPlayer();
    }

    void FollowPlayer() {

        transform.position = Target.TransformPoint(offSet);

    }

}
