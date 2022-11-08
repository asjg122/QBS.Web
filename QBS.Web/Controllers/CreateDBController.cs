using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QBS.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateDBController : ControllerBase
    {
        private readonly DbManager.DbContexts.QBSDbContext m_db;
        public CreateDBController(DbManager.DbContexts.QBSDbContext db)
        {
            m_db = db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            m_db.Database.EnsureDeleted();
            m_db.Database.EnsureCreated();
            return Ok("数据库创建成功");
        }
    }
}
