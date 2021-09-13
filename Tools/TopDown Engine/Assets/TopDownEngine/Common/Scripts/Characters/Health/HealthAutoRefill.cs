﻿using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// Add this class to a character or object with a Health class, and its health will auto refill based on the settings here
    /// </summary>
    [AddComponentMenu("TopDown Engine/Character/Health/Health Auto Refill")]
    public class HealthAutoRefill : MonoBehaviour
    {
        /// the possible refill modes :
        /// - linear : constant health refill at a certain rate per second
        /// - bursts : periodic bursts of health
        public enum RefillModes { Linear, Bursts }

        [Header("Mode")]
        /// the selected refill mode 
        [Tooltip("the selected refill mode ")]
        public RefillModes RefillMode;

        [Header("Cooldown")]
        /// how much time, in seconds, should pass before the refill kicks in
        [Tooltip("how much time, in seconds, should pass before the refill kicks in")]
        public float CooldownAfterHit = 1f;
        
        [Header("Refill Settings")]
        /// if this is true, health will refill itself when not at full health
        [Tooltip("if this is true, health will refill itself when not at full health")]
        public bool RefillHealth = true;
        /// the amount of health per second to restore when in linear mode
        [MMEnumCondition("RefillMode", (int)RefillModes.Linear)]
        [Tooltip("the amount of health per second to restore when in linear mode")]
        public int HealthPerSecond;
        /// the amount of health to restore per burst when in burst mode
        [MMEnumCondition("RefillMode", (int)RefillModes.Bursts)]
        [Tooltip("the amount of health to restore per burst when in burst mode")]
        public int HealthPerBurst = 5;
        /// the duration between two health bursts, in seconds
        [MMEnumCondition("RefillMode", (int)RefillModes.Bursts)]
        [Tooltip("the duration between two health bursts, in seconds")]
        public float DurationBetweenBursts = 2f;

        protected Health _health;
        protected float _lastHitTime = 0f;
        protected float _healthToGive = 0f;
        protected float _lastBurstTimestamp;

        /// <summary>
        /// On Awake we do our init
        /// </summary>
        protected virtual void Awake()
        {
            Initialization();
        }

        /// <summary>
        /// On init we grab our Health component
        /// </summary>
        protected virtual void Initialization()
        {
            _health = this.gameObject.GetComponent<Health>();
        }

        /// <summary>
        /// On Update we refill
        /// </summary>
        protected virtual void Update()
        {
            ProcessRefillHealth();
        }  

        /// <summary>
        /// Tests if a refill is needed and processes it
        /// </summary>
        protected virtual void ProcessRefillHealth()
        {
            if (!RefillHealth)
            {
                return;
            }

            if (Time.time - _lastHitTime < CooldownAfterHit)
            {
                return;
            }

            if (_health.CurrentHealth < _health.MaximumHealth)
            {
                switch (RefillMode)
                {
                    case RefillModes.Bursts:
                        if (Time.time - _lastBurstTimestamp > DurationBetweenBursts)
                        {
                            _health.GetHealth(HealthPerBurst, this.gameObject);
                            _lastBurstTimestamp = Time.time;
                        }
                        break;

                    case RefillModes.Linear:
                        _healthToGive += HealthPerSecond * Time.deltaTime;
                        if (_healthToGive > 1f)
                        {
                            int givenHealth = (int)_healthToGive;
                            _healthToGive -= givenHealth;
                            _health.GetHealth(givenHealth, this.gameObject);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// On hit we store our time
        /// </summary>
        public virtual void OnHit()
        {
            _lastHitTime = Time.time;
        }
        
        /// <summary>
        /// On enable we start listening for hits
        /// </summary>
        protected virtual void OnEnable()
        {
            _health.OnHit += OnHit;
        }

        /// <summary>
        /// On disable we stop listening for hits
        /// </summary>
        protected virtual void OnDisable()
        {
            _health.OnHit -= OnHit;
        }
    }
}
