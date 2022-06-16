using NFTAnalyser.Models;
using System.Collections.Generic;

namespace NFTAnalyser.Contracts
{
    public interface ILoadedCollection : IReadOnlyList<NFT>
    {
    }
}
