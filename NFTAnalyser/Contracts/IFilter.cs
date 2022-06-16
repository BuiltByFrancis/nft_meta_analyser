using System;
using System.Collections.Generic;
using NFTAnalyser.Models;

namespace NFTAnalyser.Contracts
{
    public interface IFilter
    {
        string Title { get; }

        Action Delete { get; }

        IEnumerable<NFT> Apply(IEnumerable<NFT> nfts);
    }
}
