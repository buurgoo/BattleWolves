using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CallWolfToScene : SceneChange
{
    [SerializeField] private WolfHomeController wolf;
    private float xPos;
    private bool waiting = false;

    private void Awake()
    {
        xPos = transform.position.x;
    }

    public override void ChangeScene()
    {
        wolf.CallToTarget(xPos);
        waiting = true;
    }

    private void Update()
    {
        if (waiting)
        {
            if (Math.Abs(wolf.transform.position.x - xPos) < 0.1f) { base.ChangeScene(); }
        }
    }
}