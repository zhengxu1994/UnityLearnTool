using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.AI;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// Add this class to a 3D character and it'll be albe to navigate a navmesh (if there's one in the scene of course)
    /// </summary>
    [AddComponentMenu("TopDown Engine/Character/Abilities/Character Pathfinder 3D")]
    public class CharacterPathfinder3D : MonoBehaviour
    {
        [Header("PathfindingTarget")]

        /// the target the character should pathfind to
        [Tooltip("the target the character should pathfind to")]
        public Transform Target;
        /// the distance to waypoint at which the movement is considered complete
        [Tooltip("the distance to waypoint at which the movement is considered complete")]
        public float DistanceToWaypointThreshold = 1f;
        /// if the target point can't be reached, the distance threshold around that point in which to look for an alternative end point
        [Tooltip("if the target point can't be reached, the distance threshold around that point in which to look for an alternative end point")]
        public float ClosestPointThreshold = 3f;

        [Header("Debug")]

        /// whether or not we should draw a debug line to show the current path of the character
        [Tooltip("whether or not we should draw a debug line to show the current path of the character")]
        public bool DebugDrawPath;

        /// the current path
        [MMReadOnly]
        [Tooltip("the current path")]
        public NavMeshPath AgentPath;
        /// a list of waypoints the character will go through
        [MMReadOnly]
        [Tooltip("a list of waypoints the character will go through")]
        public Vector3[] Waypoints;
        /// the index of the next waypoint
        [MMReadOnly]
        [Tooltip("the index of the next waypoint")]
        public int NextWaypointIndex;
        /// the direction of the next waypoint
        [MMReadOnly]
        [Tooltip("the direction of the next waypoint")]
        public Vector3 NextWaypointDirection;
        /// the distance to the next waypoint
        [MMReadOnly]
        [Tooltip("the distance to the next waypoint")]
        public float DistanceToNextWaypoint;

        protected Vector3 _direction;
        protected Vector2 _newMovement;
        protected TopDownController _topDownController;
        protected CharacterMovement _characterMovement;
        protected Vector3 _lastValidTargetPosition;
        protected Vector3 _closestNavmeshPosition;
        protected NavMeshHit _navMeshHit;
        protected bool _pathFound;

        /// <summary>
        /// On Awake we grab our components
        /// </summary>
        protected virtual void Awake()
        {
            AgentPath = new NavMeshPath();
            _topDownController = GetComponentInParent<TopDownController>();
            _characterMovement = GetComponentInParent<Character>()?.FindAbility<CharacterMovement>();
            _lastValidTargetPosition = this.transform.position;
        }

        /// <summary>
        /// Sets a new destination the character will pathfind to
        /// </summary>
        /// <param name="destinationTransform"></param>
        public virtual void SetNewDestination(Transform destinationTransform)
        {
            if (destinationTransform == null)
            {
                Target = null;
                return;
            }
            Target = destinationTransform;
            DeterminePath(this.transform.position, destinationTransform.position);
        }

        /// <summary>
        /// On Update, we draw the path if needed, determine the next waypoint, and move to it if needed
        /// </summary>
        protected virtual void Update()
        {
            if (Target == null)
            {
                return;
            }

            DrawDebugPath();
            DetermineNextWaypoint();
            DetermineDistanceToNextWaypoint();
            MoveController();
        }
        
        /// <summary>
        /// Moves the controller towards the next point
        /// </summary>
        protected virtual void MoveController()
        {
            if ((Target == null) || (NextWaypointIndex <= 0))
            {
                _characterMovement.SetMovement(Vector2.zero);
                return;
            }
            else
            {
                _direction = (Waypoints[NextWaypointIndex] - this.transform.position).normalized;
                _newMovement.x = _direction.x;
                _newMovement.y = _direction.z;
                _characterMovement.SetMovement(_newMovement);
            }
        }

        /// <summary>
        /// Determines the next path position for the agent. NextPosition will be zero if a path couldn't be found
        /// </summary>
        /// <param name="startingPos"></param>
        /// <param name="targetPos"></param>
        /// <returns></returns>        
        protected virtual void DeterminePath(Vector3 startingPosition, Vector3 targetPosition)
        {
            NextWaypointIndex = 0;

            _closestNavmeshPosition = targetPosition;
            if (NavMesh.SamplePosition(targetPosition, out _navMeshHit, ClosestPointThreshold, NavMesh.AllAreas))
            {
                _closestNavmeshPosition = _navMeshHit.position;
            }

            _pathFound = NavMesh.CalculatePath(startingPosition, _closestNavmeshPosition, NavMesh.AllAreas, AgentPath);
            if (_pathFound)
            {
                _lastValidTargetPosition = _closestNavmeshPosition;
            }
            else
            {
                NavMesh.CalculatePath(startingPosition, _lastValidTargetPosition, NavMesh.AllAreas, AgentPath);
            }

            Waypoints = AgentPath.corners;
            if (AgentPath.corners.Length >= 2)
            {
                NextWaypointIndex = 1;
            }
        }
        
        /// <summary>
        /// Determines the next waypoint based on the distance to it
        /// </summary>
        protected virtual void DetermineNextWaypoint()
        {
            if (Waypoints.Length <= 0)
            {
                return;
            }
            if (NextWaypointIndex < 0)
            {
                return;
            }

            if (Vector3.Distance(this.transform.position, Waypoints[NextWaypointIndex]) <= DistanceToWaypointThreshold)
            {
                if (NextWaypointIndex + 1 < Waypoints.Length)
                {
                    NextWaypointIndex++;
                }
                else
                {
                    NextWaypointIndex = -1;
                }
            }
        }

        /// <summary>
        /// Determines the distance to the next waypoint
        /// </summary>
        protected virtual void DetermineDistanceToNextWaypoint()
        {
            if (NextWaypointIndex <= 0)
            {
                DistanceToNextWaypoint = 0;
            }
            else
            {
                DistanceToNextWaypoint = Vector3.Distance(this.transform.position, Waypoints[NextWaypointIndex]);
            }
        }

        /// <summary>
        /// Draws a debug line to show the current path
        /// </summary>
        protected virtual void DrawDebugPath()
        {
            if (DebugDrawPath)
            {
                for (int i = 0; i < AgentPath.corners.Length - 1; i++)
                {
                    Debug.DrawLine(AgentPath.corners[i], AgentPath.corners[i + 1], Color.red);
                }
            }
        }
    }
}
