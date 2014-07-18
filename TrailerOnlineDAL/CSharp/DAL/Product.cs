// CREATED BY: Nathan Townsend - Small Business Online, LLC
// CREATED DATE: 7/17/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using TrailerOnline.DAL.DAL;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.DAL.DAL.dbo
{
    /// <summary>
    /// Provides data access methods for the Product database table
    /// </summary>
    /// <remarks>
    public partial class Product
    {
        
        /// <summary>
        /// Creates a new Product record
        /// </summary>
        public static int Create(ProductDO DO)
        {
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
            SqlParameter _ProductId = new SqlParameter("ProductId", SqlDbType.Int);
            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
            SqlParameter _Price = new SqlParameter("Price", SqlDbType.Decimal);
            SqlParameter _Description = new SqlParameter("Description", SqlDbType.VarChar);
            SqlParameter _DisplayToPublic = new SqlParameter("DisplayToPublic", SqlDbType.Bit);
            SqlParameter _CreateDate = new SqlParameter("CreateDate", SqlDbType.DateTime);
            SqlParameter _Sequence = new SqlParameter("Sequence", SqlDbType.Int);
            
            _CategoryId.Value = DO.CategoryId;
            _ProductId.Value = DO.ProductId;
            _Name.Value = DO.Name;
            _Price.Value = DO.Price;
            _Description.Value = DO.Description;
            _DisplayToPublic.Value = DO.DisplayToPublic;
            _CreateDate.Value = DO.CreateDate;
            _Sequence.Value = DO.Sequence;
            
            SqlParameter[] _params = new SqlParameter[] {
                _CategoryId,
                _ProductId,
                _Name,
                _Price,
                _Description,
                _DisplayToPublic,
                _CreateDate,
                _Sequence
            };

            return DataCommon.ExecuteScalar("[dbo].[Product_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a Product record and returns the number of records affected
        /// </summary>
        public static int Update(ProductDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
            SqlParameter _ProductId = new SqlParameter("ProductId", SqlDbType.Int);
            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
            SqlParameter _Price = new SqlParameter("Price", SqlDbType.Decimal);
            SqlParameter _Description = new SqlParameter("Description", SqlDbType.VarChar);
            SqlParameter _DisplayToPublic = new SqlParameter("DisplayToPublic", SqlDbType.Bit);
            SqlParameter _CreateDate = new SqlParameter("CreateDate", SqlDbType.DateTime);
            SqlParameter _Sequence = new SqlParameter("Sequence", SqlDbType.Int);
            
            _TenantId.Value = DO.TenantId;
            _CategoryId.Value = DO.CategoryId;
            _ProductId.Value = DO.ProductId;
            _Name.Value = DO.Name;
            _Price.Value = DO.Price;
            _Description.Value = DO.Description;
            _DisplayToPublic.Value = DO.DisplayToPublic;
            _CreateDate.Value = DO.CreateDate;
            _Sequence.Value = DO.Sequence;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _CategoryId,
                _ProductId,
                _Name,
                _Price,
                _Description,
                _DisplayToPublic,
                _CreateDate,
                _Sequence
            };

            return DataCommon.ExecuteScalar("[dbo].[Product_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a Product record
        /// </summary>
        public static int Delete(ProductDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
            SqlParameter _ProductId = new SqlParameter("ProductId", SqlDbType.Int);
            
            _TenantId.Value = DO.TenantId;
            _CategoryId.Value = DO.CategoryId;
            _ProductId.Value = DO.ProductId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _CategoryId,
                _ProductId
            };

            return DataCommon.ExecuteScalar("[dbo].[Product_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all Product records
        /// </summary>
        public static ProductDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Product_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<ProductDO> objs = new List<ProductDO>();
            
            while(sr.Read()){

                ProductDO obj = new ProductDO();
                
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.ProductId = sr.GetInt32(sr.GetOrdinal("ProductId"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Price = sr.GetDecimal(sr.GetOrdinal("Price"));
                obj.Description = sr.GetString(sr.GetOrdinal("Description"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.CreateDate = sr.GetDateTime(sr.GetOrdinal("CreateDate"));
                obj.Sequence = sr.GetInt32(sr.GetOrdinal("Sequence"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects Product records by PK
        /// </summary>
        public static ProductDO[] GetByPK(Int32 TenantId,
 Int32 CategoryId,
 Int32 ProductId)
        {

            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
            SqlParameter _ProductId = new SqlParameter("ProductId", SqlDbType.Int);
			
            _TenantId.Value = TenantId;
            _CategoryId.Value = CategoryId;
            _ProductId.Value = ProductId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _CategoryId,
                _ProductId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Product_GetByPK]", _params, "dbo");

            List<ProductDO> objs = new List<ProductDO>();
			
            while(sr.Read())
            {
                ProductDO obj = new ProductDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.ProductId = sr.GetInt32(sr.GetOrdinal("ProductId"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Price = sr.GetDecimal(sr.GetOrdinal("Price"));
                obj.Description = sr.GetString(sr.GetOrdinal("Description"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.CreateDate = sr.GetDateTime(sr.GetOrdinal("CreateDate"));
                obj.Sequence = sr.GetInt32(sr.GetOrdinal("Sequence"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the Product Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "Product");
        }

    }
}