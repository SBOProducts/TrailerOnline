using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerOnline.BLL.BusinessObjects;
using TrailerOnline.BLL.MultiTenancy;
using TrailerOnline.DAL;
using TrailerOnline.DAL.DAL.dbo;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.BLL
{
    public static class CategoryBLL
    {

        

        /// <summary>
        /// Creates the category and returns the object with the updated category Id
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static CategoryBO Create(CategoryBO category)
        {
            category.TenantId = TenantBLL.CurrentTenant.TenantId;
            category.HtmlId = Guid.NewGuid();
            category.Sequence = GetNextCategorySequence(category.TenantId);
            category.CategoryId = Category.Create(category.GetDataObject());
            return category;
        }


        /// <summary>
        /// Deletes a category
        /// </summary>
        /// <param name="CategoryId"></param>
        public static void Delete(int CategoryId)
        {
            if (!TenantOwnsCategory(CategoryId))
                throw new UnauthorizedAccessException("You do not have permission to delete this category");

            CategoryDO category = new CategoryDO() { CategoryId = CategoryId, TenantId = TenantBLL.CurrentTenant.TenantId };
            Category.Delete(category);
        }


        /// <summary>
        /// Gets the next category sequence for the current tenant
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        private static int GetNextCategorySequence(int TenantId)
        {
            string sql = string.Format("select top 1 [Sequence] FROM [{0}].[Category] where tenantid={1} order by [Sequence] desc", ConfigurationManager.AppSettings["PID"], TenantId);
            int currentMax = DataCommon.ExecuteScalar(sql, ConfigurationManager.AppSettings["PID"]);
            return currentMax + 1;
        }


        /// <summary>
        /// Gets a list of publically visible categories for a tenant sorted by the sequence number
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public static List<CategoryBO> GetCategories(int TenantId)
        {

            List<CategoryBO> bos = new List<CategoryBO>();
            foreach (CategoryDO category in Category.GetByCategory_TenantId(TenantId).Where(c => c.DisplayToPublic).OrderBy(c => c.Sequence))
            {
                CategoryBO bo = new CategoryBO(category);
                bos.Add(bo);
            }
            return bos;
        }


        /// <summary>
        /// Gets a category by Id
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public static CategoryBO GetCategory(int CategoryId)
        {
            CategoryDO data = Category.GetByCategory_CategoryId(CategoryId).FirstOrDefault();
            return new CategoryBO(data);
        }


        /// <summary>
        /// Returns true if the category belongs to the current tenant
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public static bool TenantOwnsCategory(int CategoryId)
        {
            CategoryBO bo = GetCategory(CategoryId);
            return bo.TenantId == TenantBLL.CurrentTenant.TenantId;
        }


        /// <summary>
        /// Updates the category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static CategoryBO Update(CategoryBO category)
        {
            if (!TenantOwnsCategory(category.CategoryId))
                throw new UnauthorizedAccessException("You do not have permission to update this category");

            category.TenantId = TenantBLL.CurrentTenant.TenantId;
            Category.Update(category.GetDataObject());
            return category;
        }


        

    }
}
