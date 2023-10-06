using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DecisionMakingLibrary
{
    public class Set<T>
    {
        private Notion Notion;
        private List<T> Items;
        public Set(Notion notion)
        {
            Notion = notion;
            Items = new List<T>();
        }
        public Set(Notion notion, List<T> items)
        {
            Notion = notion;
            Items = new List<T>();
            for (int i = 0; i < items.Count; i++)
            {
                AddItem(items[i]);
            }
        }
        public Notion GetNotion()
        {
            return Notion;
        }
        public int GetCount()
        {
            return Items.Count;
        }
        public T GetItem(int i)
        {
            if (i < 0 || i >= Items.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Items[i];
        }
        public Value<T> GetItemAsValue(int index)
        {
            if (index < 0 || index >= Items.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Value<T>(Notion, Items[index]);
        }
        public void AddItem(T newItem)
        {
            foreach (var item in Items)
            {
                if (Equals(item, newItem))
                {
                    return;
                }
            }
            Items.Add(newItem);
        }
        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }
        public void Clear()
        {
            Items = new List<T>();
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Equals(item, Items[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsSubSet(Set<T> potentialSubSet)
        {
            if (potentialSubSet.GetNotion() != Notion)
            {
                return false;
            }
            for (int i = 0; i < potentialSubSet.GetCount(); i++)
            {
                if (!Contains(potentialSubSet.GetItem(i)))
                {
                    return false;
                }
            }
            return true;
        }
        public static Set<T> Union(Set<T> firstSet, Set<T> secondSet)
        {
            if (firstSet.GetNotion() != secondSet.GetNotion())
            {
                throw new Exception();
            }
            Set<T> result = new Set<T>(firstSet.GetNotion());
            for (int i = 0; i < firstSet.Items.Count; i++)
            {
                result.AddItem(firstSet.Items[i]);
            }
            for (int i = 0; i < secondSet.Items.Count; i++)
            {
                result.AddItem(secondSet.Items[i]);
            }
            return result;
        }
        public static Set<T> Intersection(Set<T> firstSet, Set<T> secondSet)
        {
            if (firstSet.GetNotion() != secondSet.GetNotion())
            {
                throw new Exception();
            }
            Set<T> result = new Set<T>(firstSet.GetNotion());
            for (int i = 0; i < firstSet.GetCount(); i++)
            {
                for (int j = 0; j < secondSet.GetCount(); j++)
                {
                    if (Equals(firstSet.GetItem(i), secondSet.GetItem(j)))
                    {
                        T item = firstSet.GetItem(i);
                        result.AddItem(item);
                    }
                }
            }
            return result;
        }
        public static Set<T> Difference(Set<T> firstSet, Set<T> secondSet)
        {
            if (firstSet.GetNotion() != secondSet.GetNotion())
            {
                throw new Exception();
            }
            Set<T> result = new Set<T>(firstSet.GetNotion());
            for (int i = 0; i < firstSet.GetCount(); i++)
            {
                result.AddItem(firstSet.GetItem(i));
            }
            for (int i = 0; i < secondSet.GetCount(); i++)
            {
                result.RemoveItem(secondSet.GetItem(i));
            }
            return result;
        }
        public static Set<T> SymmetricDifference(Set<T> firstSet, Set<T> secondSet)
        {
            if (firstSet.GetNotion() != secondSet.GetNotion())
            {
                throw new Exception();
            }
            Set<T> result = new Set<T>(firstSet.GetNotion());
            Set<T> subResult1 = Difference(firstSet, secondSet);
            Set<T> subResult2 = Difference(secondSet, firstSet);
            result = subResult1 + subResult2;
            return result;
        }
        public override string ToString()
        {
            string result = "---Set---\n";
            result += Notion.ToString() + "\n---------\n";
            for (int i = 0; i < Items.Count; i++)
            {
                result += "№" + i.ToString() + " Item: " + Items[i].ToString() + "\n";
            }
            result += "---------";
            return result;
        }
        public static Set<T> operator +(Set<T> leftSet, Set<T> rightSet)
        {
            if (leftSet.GetNotion() != rightSet.GetNotion())
            {
                throw new Exception();
            }
            Set<T> result = Union(leftSet, rightSet);
            return result;
        }
        public static Set<T> operator -(Set<T> leftSet, Set<T> rightSet)
        {
            if (leftSet.GetNotion() != rightSet.GetNotion())
            {
                throw new Exception();
            }
            Set<T> result = Difference(leftSet, rightSet);
            return result;
        }
    }
}
