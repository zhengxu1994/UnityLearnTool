﻿using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// This Decision will return true if any object on its TargetLayer layermask enters its line of sight. It will also set the Brain's Target to that object. You can choose to have it in ray mode, in which case its line of sight will be an actual line (a raycast), or have it be wider (in which case it'll use a spherecast). You can also specify an offset for the ray's origin, and an obstacle layer mask that will block it.
    /// </summary>
    [AddComponentMenu("TopDown Engine/Character/AI/Decisions/AIDecisionDetectTargetLine2D")]
    //[RequireComponent(typeof(Character))]
    //[RequireComponent(typeof(CharacterOrientation2D))]
    public class AIDecisionDetectTargetLine2D : AIDecision
    {
        /// the possible detection methods
        public enum DetectMethods { Ray, WideRay }
        /// the possible detection directions
        public enum DetectionDirections { Front, Back, Both }
        /// the detection method
        [Tooltip("the selected detection method : ray is a single ray, wide ray is more expensive but also more accurate")]
        public DetectMethods DetectMethod = DetectMethods.Ray;
        /// the detection direction
        [Tooltip("the detection direction : front, back, or both")]
        public DetectionDirections DetectionDirection = DetectionDirections.Front;
        /// the width of the ray to cast (if we're in WideRay mode only
        [Tooltip("the width of the ray to cast (if we're in WideRay mode only")]
        public float RayWidth = 1f;
        /// the distance up to which we'll cast our rays
        [Tooltip("the distance up to which we'll cast our rays")]
        public float DetectionDistance = 10f;
        /// the offset to apply to the ray(s)
        [Tooltip("the offset to apply to the ray(s)")]
        public Vector3 DetectionOriginOffset = new Vector3(0,0,0);
        /// the layer(s) on which we want to search a target on
        [Tooltip("the layer(s) on which we want to search a target on")]
        public LayerMask TargetLayer;
        /// the layer(s) on which obstacles are set. Obstacles will block the ray
        [Tooltip("the layer(s) on which obstacles are set. Obstacles will block the ray")]
        public LayerMask ObstaclesLayer = LayerManager.ObstaclesLayerMask;
        /// a transform to use as the rotation reference for detection raycasts. If you have a rotating model for example, you'll want to set it as your reference transform here.
        [Tooltip("a transform to use as the rotation reference for detection raycasts. If you have a rotating model for example, you'll want to set it as your reference transform here.")]
        public Transform ReferenceTransform;

        protected Vector2 _direction;
        protected Vector2 _facingDirection;
        protected float _distanceToTarget;
        protected Vector2 _raycastOrigin;
        protected Character _character;
        protected CharacterOrientation2D _orientation2D;
        protected bool _drawLeftGizmo = false;
        protected bool _drawRightGizmo = false;
        protected Color _gizmosColor = Color.yellow;
        protected Vector3 _gizmoCenter;
        protected Vector3 _gizmoSize;
        protected bool _init = false;
        protected Vector2 _boxcastSize = Vector2.zero;
        protected bool _isFacingRight = true;

        protected Vector2 _transformRight { get { return ReferenceTransform.right; } }
        protected Vector2 _transformLeft { get { return -ReferenceTransform.right; } }
        protected Vector2 _transformUp { get { return ReferenceTransform.up; } }
        protected Vector2 _transformDown { get { return -ReferenceTransform.up; } }

        /// <summary>
        /// On Init we grab our character
        /// </summary>
        public override void Initialization()
        {
            _character = this.gameObject.GetComponentInParent<Character>();
            _orientation2D = _character?.FindAbility<CharacterOrientation2D>();
            _gizmosColor.a = 0.25f;
            _init = true;
            if (ReferenceTransform == null)
            {
                ReferenceTransform = this.transform;
            }
        }

        /// <summary>
        /// On Decide we look for a target
        /// </summary>
        /// <returns></returns>
        public override bool Decide()
        {
            return DetectTarget();
        }

        /// <summary>
        /// Returns true if a target is found by the ray
        /// </summary>
        /// <returns></returns>
        protected virtual bool DetectTarget()
        {
            bool hit = false;
            _distanceToTarget = 0;
            Transform target = null;
            RaycastHit2D raycast;
            _drawLeftGizmo = false;
            _drawRightGizmo = false;

            _boxcastSize.x = DetectionDistance / 5f;
            _boxcastSize.y = RayWidth;

            if (_orientation2D == null)
            {
                _facingDirection = _transformRight;
                _isFacingRight = true;
            }
            else
            {
                _isFacingRight = _orientation2D.IsFacingRight;
                _facingDirection = _orientation2D.IsFacingRight ? _transformRight : _transformLeft;    
            }
            
            // we cast a ray to the left of the agent to check for a Player
            _raycastOrigin.x = transform.position.x + _facingDirection.x * DetectionOriginOffset.x / 2;
            _raycastOrigin.y = transform.position.y + DetectionOriginOffset.y;

            // we cast it to the left	
            if ((DetectionDirection == DetectionDirections.Both)
                || ((DetectionDirection == DetectionDirections.Front) && (!_isFacingRight))
                || ((DetectionDirection == DetectionDirections.Back) && (_isFacingRight)))
            {
                if (DetectMethod == DetectMethods.Ray)
                {
                    raycast = MMDebug.RayCast(_raycastOrigin, _transformLeft, DetectionDistance, TargetLayer, MMColors.Gold, true);
                }
                else
                {
                    raycast = Physics2D.BoxCast(_raycastOrigin + Vector2.right * _boxcastSize.x / 2f, _boxcastSize, 0f, _transformLeft, DetectionDistance, TargetLayer);
                    MMDebug.RayCast(_raycastOrigin + _transformUp * RayWidth/2f, _transformLeft, DetectionDistance, TargetLayer, MMColors.Gold, true);
                    MMDebug.RayCast(_raycastOrigin - _transformUp * RayWidth / 2f, _transformLeft, DetectionDistance, TargetLayer, MMColors.Gold, true);
                    MMDebug.RayCast(_raycastOrigin - _transformUp * RayWidth / 2f + _transformLeft * DetectionDistance, _transformUp, RayWidth, TargetLayer, MMColors.Gold, true);
                    _drawLeftGizmo = true;
                }
                
                // if we see a player
                if (raycast)
                {
                    hit = true;
                    _direction = Vector2.left;
                    _distanceToTarget = Vector2.Distance(_raycastOrigin, raycast.point);
                    target = raycast.collider.gameObject.transform;
                }
            }

            // we cast a ray to the right of the agent to check for a Player	
            if ((DetectionDirection == DetectionDirections.Both)
               || ((DetectionDirection == DetectionDirections.Front) && (_isFacingRight))
               || ((DetectionDirection == DetectionDirections.Back) && (!_isFacingRight)))
            {
                if (DetectMethod == DetectMethods.Ray)
                {
                    raycast = MMDebug.RayCast(_raycastOrigin, _transformRight, DetectionDistance, TargetLayer, MMColors.DarkOrange, true);
                }
                else
                {
                    raycast = Physics2D.BoxCast(_raycastOrigin - _transformRight * _boxcastSize.x / 2f, _boxcastSize, 0f, _transformRight, DetectionDistance, TargetLayer);
                    MMDebug.RayCast(_raycastOrigin + _transformUp * RayWidth / 2f, _transformRight, DetectionDistance, TargetLayer, MMColors.DarkOrange, true);
                    MMDebug.RayCast(_raycastOrigin - _transformUp * RayWidth / 2f, _transformRight, DetectionDistance, TargetLayer, MMColors.DarkOrange, true);
                    MMDebug.RayCast(_raycastOrigin - _transformUp * RayWidth / 2f + _transformRight * DetectionDistance, _transformUp, RayWidth, TargetLayer, MMColors.DarkOrange, true);
                    _drawLeftGizmo = true;
                }
                
                if (raycast)
                {
                    hit = true;
                    _direction = Vector2.right;
                    _distanceToTarget = Vector2.Distance(_raycastOrigin, raycast.point);
                    target = raycast.collider.gameObject.transform;
                }
            }

            if (hit)
            {
                // we make sure there isn't an obstacle in between
                float distance = Vector2.Distance((Vector2)target.transform.position, _raycastOrigin);
                RaycastHit2D raycastObstacle = MMDebug.RayCast(_raycastOrigin, ((Vector2)target.transform.position - _raycastOrigin).normalized, distance, ObstaclesLayer, Color.gray, true);
                
                if (raycastObstacle && _distanceToTarget > raycastObstacle.distance)
                {
                    _brain.Target = null;
                    return false;
                }
                else
                {
                    // if there's no obstacle, we store our target and return true
                    _brain.Target = target;
                    return true;
                }
            }
            _brain.Target = null;
            return false;           
        }
        
        /// <summary>
        /// Draws ray gizmos
        /// </summary>
        protected virtual void OnDrawGizmos()
        {
            if ((DetectMethod != DetectMethods.WideRay) || !_init)
            {
                return;
            }

            Gizmos.color = _gizmosColor;

            _raycastOrigin.x = transform.position.x + _facingDirection.x * DetectionOriginOffset.x / 2;
            _raycastOrigin.y = transform.position.y + DetectionOriginOffset.y;

            if ((DetectionDirection == DetectionDirections.Both)
                || ((DetectionDirection == DetectionDirections.Front) && (!_isFacingRight))
                || ((DetectionDirection == DetectionDirections.Back) && (_isFacingRight)))
            {
                _gizmoCenter = (Vector3)_raycastOrigin + Vector3.left * DetectionDistance / 2f;
                _gizmoSize.x = DetectionDistance;
                _gizmoSize.y = RayWidth;
                _gizmoSize.z = 1f;
                Gizmos.DrawCube(_gizmoCenter, _gizmoSize);
            }

            if ((DetectionDirection == DetectionDirections.Both)
               || ((DetectionDirection == DetectionDirections.Front) && (_isFacingRight))
               || ((DetectionDirection == DetectionDirections.Back) && (!_isFacingRight)))
            {
                _gizmoCenter = (Vector3)_raycastOrigin + Vector3.right * DetectionDistance / 2f;
                _gizmoSize.x = DetectionDistance;
                _gizmoSize.y = RayWidth;
                _gizmoSize.z = 1f;
                Gizmos.DrawCube(_gizmoCenter, _gizmoSize);
            }
        }
    }
}
