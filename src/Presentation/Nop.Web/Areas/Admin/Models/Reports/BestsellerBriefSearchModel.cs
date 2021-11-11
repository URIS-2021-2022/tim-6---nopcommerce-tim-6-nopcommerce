using Nop.Services.Orders;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a bestseller brief search model
    /// </summary>
    public partial record BestsellerBriefSearchModel : BaseSearchModel
    {
        #region Properties

        public OrderBy OrderBy { get; set; }

        #endregion
    }
}