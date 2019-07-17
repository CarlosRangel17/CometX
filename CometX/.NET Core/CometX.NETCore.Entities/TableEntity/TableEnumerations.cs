using System.ComponentModel.DataAnnotations;

namespace CometX.NETCore.Entities.TableEntity
{
    public enum SortDirection
    {
        [Display(Name = "ASC")]
        Ascending = 0,
        [Display(Name = "DESC")]
        Descending = 1
    }
}
