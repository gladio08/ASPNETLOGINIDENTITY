using ASPNETLOGINIDENTITY.viewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace ASPNETLOGINIDENTITY.Controllers
{
    public class RolesController : Controller
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Roles
        public ActionResult Index()
        {
            return View(GetDataRoles());
        }

        public async Task<ActionResult> GetDataRoles() //Mengambil Data dalam Table Roles
        {
            var result = await sqlConnection.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role");
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Create(RoleVM roleVM)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_Insert_Role @name", new { Name = roleVM.Name});
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await sqlConnection.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role_By_Id @id", new {Id = id });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Edit(RoleVM roleVM)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_Update_Role @id, @name", new { Name = roleVM.Name, Id = roleVM.Id });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_Delete_Role @id", new { Id = id });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }
    }
}