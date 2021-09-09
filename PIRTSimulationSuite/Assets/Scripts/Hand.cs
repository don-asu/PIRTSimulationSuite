using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    //Animation 
    public float animationSpeed = 10f ;
    Animator animator;
    SkinnedMeshRenderer mesh;
    private float gripTarget;
    private float gripCurrent;
    private float triggerTarget;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";

    //physics movement

    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;
    void Start()
    {
        //Animation
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        //physics movement
        body = GetComponent<Rigidbody>();
        followTarget = followObject.transform;
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        // teleport hands 
        body.position = followTarget.position;
        body.rotation = followTarget.rotation;

    }


    void Update()
    {
        AnimateHand();
        PhysicsMove();
        
    }

    private void PhysicsMove()
    {
        var positionWithOffset = followTarget.position + positionOffset;
        //position
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = distance * followSpeed * (positionWithOffset- transform.position).normalized;

        //rotation
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        body.angularVelocity = angle * Mathf.Deg2Rad * rotateSpeed * axis;

    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }        
        
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }

    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
