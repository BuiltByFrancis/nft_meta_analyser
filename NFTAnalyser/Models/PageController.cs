using NFTAnalyser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFTAnalyser.Models
{
    public class PageController
    {
        private const int pageSize = 15;
        private IEnumerable<NFT> collection;

        public int PageNumber { get; set; }

        public int PageCount { get; set; }

        public PageController(IEnumerable<NFT> collection)
        {
            this.collection = collection;
            PageCollection(collection);
        }

        public void PageCollection(IEnumerable<NFT> collection)
        {
            this.collection = collection;

            PageNumber = 1;
            PageCount = (int)Math.Ceiling(collection.Count() / (double)pageSize);
            PageChanged?.Invoke();
        }

        public IEnumerable<ImageVM> CreatePage()
        {
            if (collection?.Any() == true && PageNumber > 0)
            {
                for (int i = 0; i < pageSize; i++)
                {
                    int index = ((PageNumber - 1) * pageSize) + i;
                    if (index < collection.Count())
                    {
                        yield return new ImageVM(collection.Skip(index).First());
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void Next()
        {
            if (CanNext())
            {
                ++PageNumber;
                PageChanged?.Invoke();
            }
        }

        public bool CanNext()
        {
            return PageNumber != PageCount;
        }

        public void Previous()
        {
            if (CanPrevious())
            {
                --PageNumber;
                PageChanged?.Invoke();
            }
        }

        public bool CanPrevious()
        {
            return PageNumber != 1;
        }

        public event Action? PageChanged;
    }
}
