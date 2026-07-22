namespace PayFlow.Domain.Common.Models
{
    public class PagedResult<T>(IEnumerable<T> items, int pageNumber, int pageSize, int totalCount)
    {
        public IEnumerable<T> Data { get; set; } = items;
        public int PageNumber { get; set; } = pageNumber;
        public int PageSize { get; set; } = pageSize;
        public int TotalCount { get; set; } = totalCount;
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}