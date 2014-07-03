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
        /// Creates a new Html record
        /// </summary>
        /// <param name="HtmlId"></param>
        /// <param name="TenantId"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static HtmlBO CreateHtml(Guid HtmlId, int TenantId, string Content)
        {
            HtmlDO data = new HtmlDO() { Content = Content, HtmlId = HtmlId, TenantId = TenantId };
            Html.Create(data);
            return new HtmlBO(data);
        }
        
        
        /// <summary>
        /// Gets a html business object
        /// </summary>
        /// <param name="HtmlId"></param>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public static HtmlBO GetHtml(Guid HtmlId, int TenantId)
        {
            HtmlDO dataObject = Html.GetByPK(TenantId, HtmlId).FirstOrDefault();

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
