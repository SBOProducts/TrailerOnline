using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerOnline.BLL.BusinessObjects;
using TrailerOnline.DAL.DAL.dbo;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.BLL
{
    public static class HtmlBLL
    {
        /// <summary>
        /// Gets a html business object
        /// </summary>
        /// <param name="HtmlId"></param>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public static HtmlBO GetHtml(int HtmlId, int TenantId)
        {
            HtmlDO dataObject = Html.GetByPK(HtmlId, TenantId).FirstOrDefault();

            // ensure the data object exists
            if (dataObject == null)
            {
                dataObject = new HtmlDO() { TenantId = TenantId, HtmlId = HtmlId, Content = "<p></p>" };
                Html.Create(dataObject);
            }

            return new HtmlBO(dataObject);
        }


        /// <summary>
        /// Saves a html business object
        /// </summary>
        /// <param name="data"></param>
        public static void UpdateHtml(HtmlBO data)
        {
            Html.Update(data.GetDataObject());
        }
    }
}
