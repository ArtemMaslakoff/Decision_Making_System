using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary
{
    public class Range
    {
        protected string name;
        protected Notion notion;
        public Range(string name, Notion notion)
        {
            this.name = name;
            this.notion = notion;
        }
        public string GetName()
        {
            return name;
        }
        public Notion GetNotion()
        {
            return notion;
        }
        public virtual object GetMinimum() { return new object(); }
        public virtual object GetMaximum() { return new object(); }
        public virtual bool IsInRange(object obj) { return false; }
    }
    public class DiscreteRange : Range
    {
        public Value<int> MinimumValue { get; set; }
        public Value<int> MaximumValue { get; set; }
        public DiscreteRange(string name, Notion notion) : base(name, notion)
        {
            MinimumValue = new Value<int>(notion, 0);
            MaximumValue = new Value<int>(notion, 10);
        }
        public DiscreteRange(string name, Notion notion, int minimum, int maximum) : base(name, notion)
        {
            MinimumValue = new Value<int>(base.notion, minimum);
            if (minimum > maximum)
            {
                MaximumValue = new Value<int>(base.notion, minimum);
            }
            else
            {
                MaximumValue = new Value<int>(base.notion, maximum);
            }
        }
        public override Value<int> GetMinimum()
        {
            return MinimumValue;
        }
        public override Value<int> GetMaximum()
        {
            return MaximumValue;
        }
        public override bool IsInRange(object meaning)
        {
            if (meaning.GetType() != typeof(int))
            {
                throw new ArgumentException();
            }
            return (int)meaning >= MinimumValue.Meaning && (int)meaning <= MaximumValue.Meaning;
        }
    }
    public class ContinuousRange : Range
    {
        public Value<double> MinimumValue { get; set; }
        public Value<double> MaximumValue { get; set; }
        public ContinuousRange(string name, Notion notion) : base(name, notion)
        {
            MinimumValue = new Value<double>(notion, 0);
            MaximumValue = new Value<double>(notion, 10);
        }
        public ContinuousRange(string name, Notion notion, double minimum, double maximum) : base(name, notion)
        {
            MinimumValue = new Value<double>(base.notion, minimum);
            if (minimum > maximum)
            {
                MaximumValue = new Value<double>(base.notion, minimum);
            }
            else
            {
                MaximumValue = new Value<double>(base.notion, maximum);
            }
        }
        public override Value<double> GetMinimum()
        {
            return MinimumValue;
        }
        public override Value<double> GetMaximum()
        {
            return MaximumValue;
        }
        public override bool IsInRange(object meaning)
        {
            if (meaning.GetType() != typeof(double))
            {
                throw new ArgumentException();
            }
            return (double)meaning >= MinimumValue.Meaning && (double)meaning <= MaximumValue.Meaning;
        }
    }
}
