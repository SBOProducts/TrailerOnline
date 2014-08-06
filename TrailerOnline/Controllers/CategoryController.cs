using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.BLL;
using TrailerOnline.BLL.BusinessObjects;
using TrailerOnline.BLL.MultiTenancy;
using TrailerOnline.Filters;
using TrailerOnline.ViewModels;

namespace TrailerOnline.Controllers
{
    public class CategoryController : Controller
    {
        /// <summary>
        /// This is the inventory page, the index of all categories
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

              

        /// <summary>
        /// Return a form for editing details of a category 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [TenantAuthorization]
        public ActionResult Edit(int Id)
        {
            CategoryBO bo = CategoryBLL.GetCategory(Id);
            CategoryVM model = new CategoryVM(bo);
            return View(model);
        }


        /// <summary>
        /// Update the details of a category and redirect to the details page
        /// </summary>
        /// <returns></returns>
        [TenantAuthorization]
        [HttpPost]
        public ActionResult Edit(CategoryVM model)
        {
            CategoryBLL.Update(model.GetBusinessObject());
            return RedirectToAction("Details", "Category", new { Id = model.CategoryId });
        }
        

        /// <summary>
        /// Returns an empty form to create a new category
        /// </summary>
        /// <returns></returns>
        [TenantAuthorization]
        public ActionResult Create()
        {
            CategoryVM model = new CategoryVM() { DisplayToPublic = true };
            return View(model);
        }

        
        /// <summary>
        /// Processes the request to create a new category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [TenantAuthorization]
        public ActionResult Create(CategoryVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                CategoryBO bo = CategoryBLL.Create(model.GetBusinessObject());
                return RedirectToAction("Details", "Category", new { Id = bo.CategoryId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }


        /// <summary>
        /// Confirms the user wants to delete a category 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [TenantAuthorization]
        public ActionResult Delete(int Id)
        {
            if(!CategoryBLL.TenantOwnsCategory(Id))
                throw new UnauthorizedAccessException("You do not have permission to delete this category");

            CategoryBO bo = CategoryBLL.GetCategory(Id);
            CategoryVM model = new CategoryVM(bo);
            return View(model);
        }


        /// <summary>
        /// Performs the delete once confirmed
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [TenantAuthorization]
        public ActionResult DeleteConfirmed(int Id)
        {

            // remove each product
            // delete the image records
            // delete the images
            // remove the category record

            CategoryBLL.Delete(Id);

            return RedirectToAction("Index");
        }

        
        /// <summary>
        /// Displays a category details and products
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Details(int Id)
        {
            CategoryBO bo = CategoryBLL.GetCategory(Id);
            CategoryVM model = new CategoryVM(bo);
            return View(model);
        }

        
        /// <summary>
        /// Displays the categories on the inventory page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult CategoryPreviews()
        {
            List<CategoryBO> model = CategoryBLL.GetCategories(TenantBLL.CurrentTenant.TenantId);
            return PartialView(model);
        }
       

        /*

        public ActionResult MenuItems()
        {
            
            List<Category> items = new List<Category>();
            using (WebContext db = new WebContext())
            {

                string controller = Request.RequestContext.RouteData.Values["controller"].ToString();
                string action = Request.RequestContext.RouteData.Values["action"].ToString();

                if (controller == "Category" && action == "Details")
                    ViewBag.SelectedCategory = Request.RequestContext.RouteData.Values["Id"].ToString();

                if (controller == "Product" && action == "Details")
                {
                    int productId = Convert.ToInt32(Request.RequestContext.RouteData.Values["Id"].ToString());
                    Product product = db.Products.Find(productId);
                    ViewBag.SelectedCategory = product.CategoryID.ToString();
                }

                items = db.Categories.ToList();
            }
            // return PartialView(items);

            // [2/6/14] sort by KeyWords - this is a hack until db moves to SQL Server
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            foreach (Category category in items)
            {
                int seq = Convert.ToInt32(category.KeyWords);
                if (categories.ContainsKey(seq))
                {
                    seq = categories.Last().Key + 1;
                    category.KeyWords = seq.ToString();
                }

                categories.Add(seq, category);
            }

            Category[] sorted = (from d in categories.OrderBy(c => c.Key) select d.Value).ToArray();

            return PartialView(sorted);
            // end hack
            
        }


        */
    }
}
