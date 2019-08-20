using System;
using System.Linq;
using System.Collections.Generic;

namespace CometX.Entities.TableEntity
{
    public class TablePaginationModel : Table
    {
        public object SearchResults { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public int PageMin { get; set; }
        public int PageMax { get; set; }
        public bool IsPaginationBeginning { get; set; }
        public bool IsPaginationEnd { get; set; }
        public void SetPagination<T>(List<T> records, int currentPage = 1, int recordsPerPage = 15) where T: new()
        {
            CurrentPage = currentPage;
            Pages = Convert.ToInt32(Math.Ceiling((decimal)records.Count() / recordsPerPage));
            PageMin = Convert.ToInt32(Math.Floor((decimal)CurrentPage / 10) * 10) + 1;
            PageMax = CurrentPage > 10 ? Convert.ToInt32(Math.Ceiling((decimal)CurrentPage / 10) * 10) : 10;
            IsPaginationEnd = (Pages - PageMax) <= 0;

            // Correct PageMin & PageMax if applicatable 
            if (PageMin > PageMax) PageMin -= 10;
            if (PageMax > Pages) PageMax = Pages;
            if (CurrentPage > PageMax) CurrentPage = PageMax;
        }

        public TablePaginationModel()
        {

        }
    }
}
