// Simulator Boundaries|SDK_Simulator|004
namespace VRTK
{
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
    using UnityEngine.XR.WSA;
    using UnityEngine.XR;
#endif

    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// The Sim Boundaries SDK script provides dummy functions for the play area boundaries.
    /// </summary>
    [SDK_Description(typeof(SDK_WindowsMRSystem))]
    public class SDK_WindowsMRBoundaries : SDK_BaseBoundaries
    {
        protected GameObject area;

        /// <summary>
        /// The InitBoundaries method is run on start of scene and can be used to initialse anything on game start.
        /// </summary>
        public override void InitBoundaries()
        {
#if UNITY_WSA && UNITY_2017_2_OR_NEWER

            if (HolographicSettings.IsDisplayOpaque)
            {
                // Defaulting coordinate system to RoomScale in immersive headsets.
                // This puts the origin 0,0,0 on the floor if a floor has been established during RunSetup via MixedRealityPortal
                XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);
            }
            else
            {
                // Defaulting coordinate system to Stationary for HoloLens.
                // This puts the origin 0,0,0 at the first place where the user started the application.
                XRDevice.SetTrackingSpaceType(TrackingSpaceType.Stationary);
            }
#endif
        }

        /// <summary>
        /// The GetPlayArea method returns the Transform of the object that is used to represent the play area in the scene.
        /// </summary>
        /// <returns>A transform of the object representing the play area in the scene.</returns>
        public override Transform GetPlayArea()
        {
            //(SJ) Do we need a PlayAreaPosition?
            return cachedPlayArea;
        }

        /// <summary>
        /// The GetPlayAreaVertices method returns the points of the play area boundaries.
        /// </summary>
        /// <returns>A Vector3 array of the points in the scene that represent the play area boundaries.</returns>
        public override Vector3[] GetPlayAreaVertices()
        {
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
            var boundaryGeometry = new List<Vector3>(0);
            if (UnityEngine.Experimental.XR.Boundary.TryGetGeometry(boundaryGeometry))
            {
                if (boundaryGeometry.Count > 0)
                {
                    return boundaryGeometry.ToArray();
                }
            }
#endif
            return null;
        }

        /// <summary>
        /// The GetPlayAreaBorderThickness returns the thickness of the drawn border for the given play area.
        /// </summary>
        /// <returns>The thickness of the drawn border.</returns>
        public override float GetPlayAreaBorderThickness()
        {
            //(SJ) Do we need a boundary thickness?
            return 0.1f;
        }

        /// <summary>
        /// The IsPlayAreaSizeCalibrated method returns whether the given play area size has been auto calibrated by external sensors.
        /// </summary>
        /// <returns>Returns true if the play area size has been auto calibrated and set by external sensors.</returns>
        public override bool IsPlayAreaSizeCalibrated()
        {
#if UNITY_WSA && UNITY_2017_2_OR_NEWER

            return UnityEngine.Experimental.XR.Boundary.configured;
#else
            return false;
#endif
        }

        /// <summary>
        /// The GetDrawAtRuntime method returns whether the given play area drawn border is being displayed.
        /// </summary>
        /// <returns>Returns true if the drawn border is being displayed.</returns>
        public override bool GetDrawAtRuntime()
        {
            //(SJ) Is this needed for WindowsMR?
            return false;
        }

        /// <summary>
        /// The SetDrawAtRuntime method sets whether the given play area drawn border should be displayed at runtime.
        /// </summary>
        /// <param name="value">The state of whether the drawn border should be displayed or not.</param>
        public override void SetDrawAtRuntime(bool value)
        {
            //(SJ) Needed for WindowsMR?
        }
    }
}