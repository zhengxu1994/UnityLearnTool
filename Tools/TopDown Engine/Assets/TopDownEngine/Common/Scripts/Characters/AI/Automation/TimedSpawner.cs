﻿using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// A class meant to be used in conjunction with an object pool (simple or multiple)
    /// to spawn objects regularly, at a frequency randomly chosen between the min and max values set in its inspector
    /// </summary>
    [AddComponentMenu("TopDown Engine/Character/AI/Automation/TimedSpawner")]
    public class TimedSpawner : MonoBehaviour 
	{
		/// whether or not this spawner can spawn
		[Tooltip("whether or not this spawner can spawn")]
		public bool CanSpawn = true;
		/// the minimum frequency possible, in seconds
		[Tooltip("the minimum frequency possible, in seconds")]
		public float MinFrequency = 1f;
		/// the maximum frequency possible, in seconds
		[Tooltip("the maximum frequency possible, in seconds")]
		public float MaxFrequency = 1f;
		/// the object pooler associated to this spawner
		public MMObjectPooler ObjectPooler { get; set; }

        [MMInspectorButton("ToggleSpawn")]
        /// a test button to spawn an object
        public bool CanSpawnButton;

		protected float _lastSpawnTimestamp = 0f;
		protected float _nextFrequency = 0f;

		/// <summary>
		/// On Start we initialize our spawner
		/// </summary>
		protected virtual void Start()
		{
			Initialization ();
		}

		/// <summary>
		/// Grabs the associated object pooler if there's one, and initalizes the frequency
		/// </summary>
		protected virtual void Initialization()
		{
			if (GetComponent<MMMultipleObjectPooler>() != null)
			{
				ObjectPooler = GetComponent<MMMultipleObjectPooler>();
			}
			if (GetComponent<MMSimpleObjectPooler>() != null)
			{
				ObjectPooler = GetComponent<MMSimpleObjectPooler>();
			}
			if (ObjectPooler == null)
			{
				Debug.LogWarning(this.name+" : no object pooler (simple or multiple) is attached to this Projectile Weapon, it won't be able to shoot anything.");
				return;
			}
			DetermineNextFrequency ();
		}

		/// <summary>
		/// Every frame we check whether or not we should spawn something
		/// </summary>
		protected virtual void Update()
		{
			if ((Time.time - _lastSpawnTimestamp > _nextFrequency)  && CanSpawn)
            {
				Spawn ();
			}
		}

		/// <summary>
		/// Spawns an object out of the pool if there's one available.
		/// If it's an object with Health, revives it too.
		/// </summary>
		protected virtual void Spawn()
		{
			GameObject nextGameObject = ObjectPooler.GetPooledGameObject();

			// mandatory checks
			if (nextGameObject==null) { return; }
			if (nextGameObject.GetComponent<MMPoolableObject>()==null)
			{
				throw new Exception(gameObject.name+" is trying to spawn objects that don't have a PoolableObject component.");		
			}	

			// we activate the object
			nextGameObject.gameObject.SetActive(true);
			nextGameObject.gameObject.MMGetComponentNoAlloc<MMPoolableObject>().TriggerOnSpawnComplete();

			// we check if our object has an Health component, and if yes, we revive our character
			Health objectHealth = nextGameObject.gameObject.MMGetComponentNoAlloc<Health> ();
			if (objectHealth != null) 
			{
				objectHealth.Revive ();
            }

            // we position the object
            nextGameObject.transform.position = this.transform.position;

            // we reset our timer and determine the next frequency
            _lastSpawnTimestamp = Time.time;
			DetermineNextFrequency ();
		}

		/// <summary>
		/// Determines the next frequency by randomizing a value between the two specified in the inspector.
		/// </summary>
		protected virtual void DetermineNextFrequency()
		{
			_nextFrequency = UnityEngine.Random.Range (MinFrequency, MaxFrequency);
		}

        /// <summary>
        /// Toggles spawn on and off
        /// </summary>
        public virtual void ToggleSpawn()
        {
            CanSpawn = !CanSpawn;
        }

        /// <summary>
        /// Turns spawning off
        /// </summary>
        public virtual void TurnSpawnOff()
        {
            CanSpawn = false;
        }

        /// <summary>
        /// Turns spawning on
        /// </summary>
        public virtual void TurnSpawnOn()
        {
            CanSpawn = true;
        }
	}
}