using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSafety : MonoBehaviour
{
    private SignalingControl _signalingControl;
    private bool _isSignalPlaying;
    private void Start()
    {
        _signalingControl = gameObject.GetComponentInChildren<SignalingControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("asd");
        if (other.gameObject.name == "Player")
        {
            _isSignalPlaying = true;
            _signalingControl.SwichSignalState(_isSignalPlaying);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("dsa");
        if (other.gameObject.name == "Player")
        {
            _isSignalPlaying = false;
            _signalingControl.SwichSignalState(_isSignalPlaying);        
        }
    }
}
