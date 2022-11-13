using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IImpact
    {
        public double CostImpact { get; }

        public double TimeImpact { get; }
    }
}
