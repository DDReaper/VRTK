// Simulator System|SDK_Simulator|001
namespace VRTK
{
    #if UNITY_WSA && UNITY_2017_2_OR_NEWER
using UnityEngine.XR.WSA;
using UnityEngine.XR;
#endif

    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// The Sim System SDK script provides dummy functions for system functions.
    /// </summary>
    [SDK_Description("Windows Mixed Reality (WSA:WindowsMR)", null, null, "WSA")]
    public class SDK_WindowsMRSystem : SDK_BaseSystem
    {
        /// <summary>
        /// The IsDisplayOnDesktop method returns true if the display is extending the desktop.
        /// </summary>
        /// <returns>Returns true if the display is extending the desktop</returns>
        public override bool IsDisplayOnDesktop()
        {
            //(SJ) Needed for MR?
            return false;
        }

        /// <summary>
        /// The ShouldAppRenderWithLowResources method is used to determine if the Unity app should use low resource mode. Typically true when the dashboard is showing.
        /// </summary>
        /// <returns>Returns true if the Unity app should render with low resources.</returns>
        public override bool ShouldAppRenderWithLowResources()
        {
            // MR has Basic plus Ultra, not sure if Unity exposes it?
            return false;
        }

        /// <summary>
        /// The ForceInterleavedReprojectionOn method determines whether Interleaved Reprojection should be forced on or off.
        /// </summary>
        /// <param name="force">If true then Interleaved Reprojection will be forced on, if false it will not be forced on.</param>
        public override void ForceInterleavedReprojectionOn(bool force)
        {
            //(SJ) No idea what this is for, revisit later.
        }
    }
}