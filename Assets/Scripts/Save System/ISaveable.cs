using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for saving the state of the object
/// </summary>
public interface ISaveable
{
    /// <summary>
    /// Capture the current state of the object
    /// </summary>
    /// <returns></returns>
    object CaptureState();

    /// <summary>
    /// Restore the state of the object
    /// </summary>
    void RestoreState(object state);
}
