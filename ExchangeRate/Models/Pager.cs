namespace ExchangeRate.Models
{
    public class Pager
    {
        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var startPage = 1;
            var endPage = totalPages;

            TotalItems = totalItems;
            CurrentPage = 1;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }
    }
}
