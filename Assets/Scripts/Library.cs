using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Library
{
    public Dictionary<string, Type> entriesDict;

    public Library()
    {
        entriesDict = new Dictionary<string, Type>
        {
            { "entry1", typeof(E1) },
            // Add more entries as needed
        };
    }

    public Entry GetEntry(string entryName)
    {
        // Check if the entry type exists in the dictionary
        if (entriesDict.TryGetValue(entryName, out Type entryType))
        {
            // Create an instance of the specified entry type
            return (Entry)Activator.CreateInstance(entryType);
        }
        else
        {
            // Entry type not found, you can handle this case accordingly
            return null;
        }
    }
}
