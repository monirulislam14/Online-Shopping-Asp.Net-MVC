using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public IPagedList<Tbl_Product> ListOfProducts { get; set; }
        dbMyOnlineShoppingEntities context = new dbMyOnlineShoppingEntities();
        public HomeIndexViewModel CreateModel(string search, int pageSize, int? page)
        {
            
                SqlParameter[] param = new SqlParameter[] {
                   new SqlParameter("@search",search??(object)DBNull.Value)
                   };
               IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
                return new HomeIndexViewModel
                {
                    ListOfProducts = data
                };

            
        }
       
    }
}
    
