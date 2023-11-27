using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Library : MonoBehaviour
{
    [SerializeField] Transform toNewRoadsCollection;
    [UDictionary.Split(30, 70)]
    public LibraryDict LibDict_ToNewRoads;
    [Serializable]
    public class LibraryDict : UDictionary<int, Entry> { }

    [Serializable]
    public class Key
    {
        public string id;

        public string file;
    }

    [Serializable]
    public class Value
    {
        public string firstName;

        public string lastName;
    }

    public void PopulateLibrary(AdventureBook adventureBook)
    {
        switch (adventureBook)
        {
            case AdventureBook.ToNewRoads:

                foreach (Transform t in toNewRoadsCollection)
                {
                    var e = t.GetComponent<Entry>();
                    LibDict_ToNewRoads.Add(e.EntryID, e);
                }
                break;

            default:
                Debug.LogWarning("Unable to populate library - adventure book switch statement default.");
                break;
        }


    }
}
