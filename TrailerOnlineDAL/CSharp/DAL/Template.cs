// CREATED BY: Nathan Townsend
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
    /// Provides data access methods for the Template database table
    /// </summary>
    /// <remarks>
    public partial class Template
    {
        
        /// <summary>
        /// Creates a new Template record
        /// </summary>
        public static int Create(TemplateDO DO)
        {
            SqlParameter _Type = new SqlParameter("Type", SqlDbType.VarChar);
            SqlParameter _Category = new SqlParameter("Category", SqlDbType.VarChar);
            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
            SqlParameter _Subject = new SqlParameter("Subject", SqlDbType.VarChar);
            SqlParameter _Content = new SqlParameter("Content", SqlDbType.VarChar);
            
            _Type.Value = DO.Type;
            _Category.Value = DO.Category;
            _Name.Value = DO.Name;
            _Subject.Value = DO.Subject;
            _Content.Value = DO.Content;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Type,
                _Category,
                _Name,
                _Subject,
                _Content
            };

            return DataCommon.ExecuteScalar("[dbo].[Template_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a Template record and returns the number of records affected
        /// </summary>
        public static int Update(TemplateDO DO)
        {
            SqlParameter _TemplateId = new SqlParameter("TemplateId", SqlDbType.Int);
            SqlParameter _Type = new SqlParameter("Type", SqlDbType.VarChar);
            SqlParameter _Category = new SqlParameter("Category", SqlDbType.VarChar);
            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
            SqlParameter _Subject = new SqlParameter("Subject", SqlDbType.VarChar);
            SqlParameter _Content = new SqlParameter("Content", SqlDbType.VarChar);
            
            _TemplateId.Value = DO.TemplateId;
            _Type.Value = DO.Type;
            _Category.Value = DO.Category;
            _Name.Value = DO.Name;
            _Subject.Value = DO.Subject;
            _Content.Value = DO.Content;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TemplateId,
                _Type,
                _Category,
                _Name,
                _Subject,
                _Content
            };

            return DataCommon.ExecuteScalar("[dbo].[Template_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a Template record
        /// </summary>
        public static int Delete(TemplateDO DO)
        {
            SqlParameter _TemplateId = new SqlParameter("TemplateId", SqlDbType.Int);
            
            _TemplateId.Value = DO.TemplateId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TemplateId
            };

            return DataCommon.ExecuteScalar("[dbo].[Template_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all Template records
        /// </summary>
        public static TemplateDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Template_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<TemplateDO> objs = new List<TemplateDO>();
            
            while(sr.Read()){

                TemplateDO obj = new TemplateDO();
                
                obj.TemplateId = sr.GetInt32(sr.GetOrdinal("TemplateId"));
                obj.Type = sr.GetString(sr.GetOrdinal("Type"));
                obj.Category = sr.GetString(sr.GetOrdinal("Category"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Subject = sr.GetString(sr.GetOrdinal("Subject"));
                obj.Content = sr.GetString(sr.GetOrdinal("Content"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects Template records by PK
        /// </summary>
        public static TemplateDO[] GetByPK(Int32 TemplateId)
        {

            SqlParameter _TemplateId = new SqlParameter("TemplateId", SqlDbType.Int);
			
            _TemplateId.Value = TemplateId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _TemplateId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Template_GetByPK]", _params, "dbo");

            List<TemplateDO> objs = new List<TemplateDO>();
			
            while(sr.Read())
            {
                TemplateDO obj = new TemplateDO();
				
                obj.TemplateId = sr.GetInt32(sr.GetOrdinal("TemplateId"));
                obj.Type = sr.GetString(sr.GetOrdinal("Type"));
                obj.Category = sr.GetString(sr.GetOrdinal("Category"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Subject = sr.GetString(sr.GetOrdinal("Subject"));
                obj.Content = sr.GetString(sr.GetOrdinal("Content"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects Template records by Template_Name
        /// </summary>
        public static TemplateDO[] GetByTemplate_Name(String Name)
        {

            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
			
            _Name.Value = Name;
			
            SqlParameter[] _params = new SqlParameter[] {
                _Name
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Template_GetByTemplate_Name]", _params, "dbo");

            List<TemplateDO> objs = new List<TemplateDO>();
			
            while(sr.Read())
            {
                TemplateDO obj = new TemplateDO();
				
                obj.TemplateId = sr.GetInt32(sr.GetOrdinal("TemplateId"));
                obj.Type = sr.GetString(sr.GetOrdinal("Type"));
                obj.Category = sr.GetString(sr.GetOrdinal("Category"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Subject = sr.GetString(sr.GetOrdinal("Subject"));
                obj.Content = sr.GetString(sr.GetOrdinal("Content"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the Template Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "Template");
        }

    }
}