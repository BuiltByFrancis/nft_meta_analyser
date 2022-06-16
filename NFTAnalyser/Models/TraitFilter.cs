using NFTAnalyser.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFTAnalyser.Models
{
    public class TraitFilter : IFilter
    {
        public TraitFilter(TraitFilters owner, string category, string trait)
        {
            Category = category;
            Title = trait;
            Delete = () => owner.Remove(this);
        }

        public string Category { get; }

        public string Title { get; }

        public Action Delete { get; }

        public IEnumerable<NFT> Apply(IEnumerable<NFT> nfts)
        {
            foreach (var nft in nfts)
            {
                if (nft.Data.Traits.Any(t => t.Trait == Category && t.Value == Title))
                {
                    yield return nft;
                }
            }
        }
    }
}
