using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// The 3D version of the WeaponAutoAim, meant to be used on objects equipped with a WeaponAim3D.
    /// It'll detect targets within the defined radius, pick the closest, and force the WeaponAim component to aim at them if a target is found
    /// </summary>
    [RequireComponent(typeof(WeaponAim3D))]
    [AddComponentMenu("TopDown Engine/Weapons/Weapon Auto Aim 3D")]
    public class WeaponAutoAim3D : WeaponAutoAim
    {
        protected Vector3 _aimDirection;
        protected Collider[] _hit;
        protected Vector3 _raycastDirection;
        protected Collider _potentialHit;

        /// <summary>
        /// On init we grab our orientation to be able to detect facing direction
        /// </summary>
        protected override void Initialization()
        {
            base.Initialization();
        }

        /// <summary>
        /// Scans for targets by performing an overlap detection, then verifying line of fire with a boxcast
        /// </summary>
        /// <returns></returns>
        protected override bool ScanForTargets()
        {
            Target = null;
            
            float nearestDistance = float.MaxValue;
            float distance;

            _hit = Physics.OverlapSphere(_weapon.Owner.transform.position, ScanRadius, TargetsMask);

            if (_hit.Length > 0)
            {
                foreach(Collider collider in _hit)
                {
                    distance = (_raycastOrigin - collider.transform.position).sqrMagnitude;
                    if (distance < nearestDistance)
                    {
                        _potentialHit = collider;
                        nearestDistance = distance;
                    }
                }

                // we cast a ray to make sure there's no obstacle
                _raycastDirection = _potentialHit.transform.position - _raycastOrigin;
                RaycastHit hit = MMDebug.Raycast3D(_raycastOrigin, _raycastDirection, Vector3.Distance(_potentialHit.transform.position, _raycastOrigin), ObstacleMask.value, Color.yellow, true);
                if (hit.collider == null)
                {
                    Target = _potentialHit.transform;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the aim to the relative direction of the target
        /// </summary>
        protected override void SetAim()
        {
            _aimDirection = (Target.transform.position - _raycastOrigin).normalized;
            _weaponAim.SetCurrentAim(_aimDirection);
        }

        /// <summary>
        /// Determines the raycast origin
        /// </summary>
        protected override void DetermineRaycastOrigin()
        {
            _raycastOrigin = this.transform.position;
        }
    }
}
