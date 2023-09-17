namespace Web.Models
{
    public class PaginationInfoViewModel
    {
        public int PageId { get; set; }

        public int TotalItems { get; set; }

        public int ItemsOnPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / Constants.ITEMS_PER_PAGE);

        public bool HasPrevious => PageId > 1;

        public bool HasNext => PageId < TotalPages;

        public int RangeStart => (PageId - 1) * Constants.ITEMS_PER_PAGE + 1;

        public int RangeEnd => RangeStart + ItemsOnPage - 1;
    }
}
