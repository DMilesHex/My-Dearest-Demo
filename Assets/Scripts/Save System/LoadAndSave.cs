using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadAndSave : MonoBehaviour
{
    private  string savePath => $"{Application.persistentDataPath}/MyDearest.game";

    [ContextMenu("Save")]
    public void Save()
    {
        var state = LoadFile();
        CaptureState(state);
        SaveFile(state);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        var state = LoadFile();
        RestoreState(state);
    }



    /// <summary>
    /// Load the file
    /// </summary>
    /// <returns></returns>
    private  Dictionary<string, object> LoadFile()
    {
        if (!File.Exists(savePath))
            return new Dictionary<string, object>();

        using (FileStream stream = File.Open(savePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }
    }

    /// <summary>
    /// Save the file
    /// </summary>
    /// <param name="state"></param>
    private void SaveFile(object state)
    {
        using (var stream = File.Open(savePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    private void CaptureState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<Saveable>())
        {
            state[saveable.ID] = saveable.CaptureState();
        }
    }

    private void RestoreState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<Saveable>())
        {
            if (state.TryGetValue(saveable.ID, out object value))
                saveable.RestoreState(value);
        }
    }
}
