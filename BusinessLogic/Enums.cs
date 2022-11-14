using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public enum IpcClass
    {
        Class1,
        Class2,
        Class3
    }

    public enum FluxType
    {
        Clean,
        NoClean
    }

    public enum ControlledImpedance
    {
        None,
        SeeNotes
    }

    public enum TentingForVias
    {
        BothSides,
        TopSide,
        BottomSide,
        None
    }

    public enum Stackup
    {
        Standard,
        SeeNotes
    }

    public enum QuoteElementType
    {
        Fabrication = 0,
        Assembly = 1,
        Components = 2
    }
}
