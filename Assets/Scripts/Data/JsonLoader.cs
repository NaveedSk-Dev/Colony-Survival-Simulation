using UnityEngine;

public static class JsonLoader
{
    public static T Load<T>(string fileName)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(fileName);

        if (jsonFile == null)
        {
            Debug.LogError($"Could not load JSON file: {fileName}");
            return default;
        }
        return JsonUtility.FromJson<T>(jsonFile.text);
    }
}
