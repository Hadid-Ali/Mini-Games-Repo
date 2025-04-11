using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static T GetRandom<T>(this T[] list) => list[Random.Range(0, list.Length)];
    public static T GetRandom<T>(this List<T> list) => list[Random.Range(0, list.Count)];
    
    public static void SetActive(this List<GameObject> gameObjects, bool status)
    {
        gameObjects.ToArray().SetActive(status);
    }
    
    public static void SetActive(this GameObject[] gameObjects, bool status)
    {
        foreach (GameObject childObject in gameObjects)
        {
            childObject.SetActive(status);
        }
    }
    
    public static Transform GetRandom(this Transform[] array) => array[Random.Range(0, array.Length)];

    public static void SetParentAndReset(this Transform source, Transform point,bool useScale)
    {
        source.SetParent(point);
            
        source.localPosition = Vector3.zero;
        source.localRotation = Quaternion.identity;
        
        if (!useScale)
            return;
        
        source.localScale = Vector3.one;
    }
}
