using System.Collections.Generic;
using UnityEngine;

public class GlobalGameController : MonoBehaviour {

    [HideInInspector]
    public List<UnitsBase> selectedUnits;

    [HideInInspector]
    public List<UnitsBase> highlightedUnits;

    void Start()
    {
        selectedUnits = new List<UnitsBase>();
        highlightedUnits = new List<UnitsBase>();
    }

    void Update()
    {

    }
}
