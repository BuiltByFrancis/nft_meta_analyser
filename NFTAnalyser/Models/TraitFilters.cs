using NFTAnalyser.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NFTAnalyser.Models
{
    public class TraitFilters : IEnumerable<IFilter>
    {
        private readonly List<IFilter> appliedFilters = new();

        public IEnumerable<NFT> FilterLoadedCollection()
        {
            IEnumerable<NFT> collection = Globals.Get<ILoadedCollection>();

            foreach (var filter in appliedFilters)
            {
                collection = filter.Apply(collection);
            }

            return collection.OrderBy(c => c.Data.Id);
        }

        public bool Contains(IFilter filter)
        {
            return appliedFilters.Contains(filter);
        }

        public void Add(IFilter filter)
        {
            appliedFilters.Add(filter);
            FilterChanged.Invoke();
        }

        public void Remove(IFilter filter)
        {
            if (appliedFilters.Remove(filter))
            {
                FilterChanged.Invoke();
            }
        }

        public bool IsEmpty()
        {
            return !appliedFilters.Any();
        }

        public void Clear()
        {
            appliedFilters.Clear();
            FilterChanged.Invoke();
        }

        public IEnumerator<IFilter> GetEnumerator()
        {
            return ((IEnumerable<IFilter>)appliedFilters).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)appliedFilters).GetEnumerator();
        }

        public event Action? FilterChanged;
    }
}
