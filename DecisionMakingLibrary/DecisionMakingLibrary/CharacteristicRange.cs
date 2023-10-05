﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary
{
    public class CharacteristicRange<T>
    {
        protected Range range;
        protected Set<T> characteristics;
        public CharacteristicRange(Range range, Set<T> characteristics)
        {
            this.range = range;
            this.characteristics = characteristics;
        }
        public Range GetRange()
        {
            return range;
        }
        public Set<T> GetCharacteristics()
        {
            return characteristics;
        }
    }
    public class FunctionalRange<K, T, P> : CharacteristicRange<K>
    {
        private Func<T, P> function;
        public FunctionalRange(Range range, Set<K> characteristics, Func<T, P> function) : base(range, characteristics)
        {
            this.function = function;
        }
        public P GetFunctionResult(T input)
        {
            return function(input);
        }
    } 
    public class InstanceRange<T, K> : CharacteristicRange<K>
    { 
        public InstanceRange(Range range, Set<K> characteristics) : base(range, characteristics)
        {

        }
    } 
}