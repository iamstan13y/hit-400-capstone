using Newtonsoft.Json;

namespace iDent.ModelLibrary.Utility
{
    public class Pageable<T>
    {
        public Pageable() { }
        public Pageable(IEnumerable<T> list, int? page = null, int? pageSize = null)
        {
            _list = list;
            _page = page;
            _pageSize = pageSize;
        }

        private IEnumerable<T>? _list;
        [JsonProperty("items")]
        public IEnumerable<T>? Items
        {
            get
            {
                if (_list == null) return null;
                return _list.Skip((Page - 1) * PageSize).Take(PageSize);
            }
        }

        private int? _page;
        [JsonProperty("page")]
        public int Page
        {
            get
            {
                if (!_page.HasValue)
                {
                    return 1;
                }
                else
                {
                    return _page.Value;
                }
            }
        }

        private int? _pageSize;
        [JsonProperty("pageSize")]
        public int PageSize
        {
            get
            {
                if (!_pageSize.HasValue)
                {
                    return _list == null ? 0 : _list.Count();
                }
                else
                {
                    return _pageSize.Value;
                }
            }
        }

        [JsonProperty("totalItemCount")]
        public int TotalItemCount
        {
            get
            {
                return _list == null ? 0 : _list.Count();
            }
        }

        [JsonProperty("totalPageCount")]
        public int TotalPageCount
        {
            get
            {
                return _list == null ? 0 : _list.Count() % PageSize > 0 ? _list.Count() / PageSize + 1 : _list.Count() / PageSize;
            }
        }
    }
}