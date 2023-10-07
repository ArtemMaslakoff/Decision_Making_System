using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary
{
    public class DecisionMakingSystem
    {
        public MemoryBlock MemoryBlock { get; set; }
        public ConditionBlock ConditionBlock { get; set; }
        public PurposeFormationBlock PurposeFormationBlock { get; set; }
        public DecisionMakingBlock DecisionMakingBlock { get; set; }
    }
}
