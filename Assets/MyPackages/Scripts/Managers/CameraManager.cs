using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

namespace MyLibrary.Scripts.Managers{
    
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _defaultGameVCam;
        [SerializeField] private Transform _target;
    
        private CameraState _currentCamera;
        private List<CinemachineVirtualCamera> _virtualCameraList=new List<CinemachineVirtualCamera>();
        public enum CameraState
        {
            DefaultCamera
        }
        private void Start()
        {
            AddListVcameras();
            if(_target!=null)
            SetTargetFollow();
            _currentCamera = CameraState.DefaultCamera;
            SetCurrentCamera(CameraState.DefaultCamera);
    
        }
    
        private void SetTargetFollow()
        {
            _virtualCameraList.ForEach(c =>
            {
                c.Follow = _target;
                c.LookAt = _target;
            });
        }
    
        private void AddListVcameras()
        {
            _virtualCameraList.Add(_defaultGameVCam);
        }
        public void SetCurrentCamera(CameraState camState)
        {
            if (_currentCamera == camState) return;
            _virtualCameraList.ForEach(c => c.Priority = 0);
                switch (camState)
                {
                    case CameraState.DefaultCamera:
                    _defaultGameVCam.Priority = 10;
                    _currentCamera = camState;
                        break;
                }
    
        }
    }
    
}
