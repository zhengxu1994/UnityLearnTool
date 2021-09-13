﻿using UnityEngine;
using System.Collections;

namespace MoreMountains.Tools
{
    /// <summary>
    /// Add this class to an object (usually a sprite) and it'll face the camera at all times
    /// </summary>
    [AddComponentMenu("More Mountains/Tools/Camera/MMBillboard")]
    public class MMBillboard : MonoBehaviour
	{
		/// the camera we're facing
		public Camera MainCamera { get; set; }
		/// whether or not this object should automatically grab a camera on start
		public bool GrabMainCameraOnStart = true;
        /// whether or not to nest this object below a parent container
        public bool NestObject = true;

		protected GameObject _parentContainer;
        private Transform _transform;

		/// <summary>
		/// On awake we grab a camera if needed, and nest our object
		/// </summary>
		protected virtual void Awake()
		{
            _transform = transform;

			if (GrabMainCameraOnStart == true)
			{
				GrabMainCamera ();
			}
		}

        private void Start()
        {
            if (NestObject)
            {
                NestThisObject();
            }                
        }

        /// <summary>
        /// Nests this object below a parent container
        /// </summary>
        protected virtual void NestThisObject()
		{
			_parentContainer = new GameObject();
			_parentContainer.name = "Parent"+transform.gameObject.name;
			_parentContainer.transform.position = transform.position;
			transform.parent = _parentContainer.transform;
		}

		/// <summary>
		/// Grabs the main camera.
		/// </summary>
		protected virtual void GrabMainCamera()
		{
			MainCamera = Camera.main;
		}

		/// <summary>
		/// On update, we change our parent container's rotation to face the camera
		/// </summary>
		protected virtual void Update()
		{
            if (NestObject)
            {
                _parentContainer.transform.LookAt(_parentContainer.transform.position + MainCamera.transform.rotation * Vector3.back, MainCamera.transform.rotation * Vector3.up);
            }                
            else
            {
                _transform.LookAt(_transform.position + MainCamera.transform.rotation * Vector3.back, MainCamera.transform.rotation * Vector3.up);
            }
        }
	}
}
