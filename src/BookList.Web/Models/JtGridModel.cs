using Castle.Core.Internal;

namespace BookList.Web.Models
{
    public class JtGridModel
    {
        private const string defaultSorting = "Title ASC";
        private string sorting;

        public string JtSorting
        {
            get { return sorting.IsNullOrEmpty() ? defaultSorting : sorting; }
            set { sorting = value; }
        }
    }
}