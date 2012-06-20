using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOILib.Contracts;

namespace GOILib
{
    public class EvolutionRuleFactory : IEvolutionRuleFactory
    {
        public IEvolutionRule CreateEvolutionRule(INeighbourRule neighbourRule)
        {
            // for now return hard coded rule. TODO: This needs to become dynamic
            return new BasicTwoDimensionalEvolutionRule(neighbourRule);
        }
    }
}
