//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ChildCategoriesController : ControllerBase
//    {
//        private readonly AppDbContext Context;
//        public ChildCategoriesController(AppDbContext _Context)
//        {
//            Context = _Context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetChildCategoiesAll()
//        {
//            var ChildCategoies = await Context.ChildCategories.ToListAsync();
//            if (ChildCategoies == null) return NotFound();
//            return Ok(ChildCategoies);
//        }


//        //[HttpGet]
//        //public async Task<IActionResult> GetChildCategory([FromQuery] List<int> ids)
//        //{
//        //    if (ids == null) return BadRequest();
//        //    var ChildCategoies = new List<ChildCategory>();
//        //    foreach (var id in ids)
//        //    {
//        //        if (id <= 0) continue;
//        //        var ChildCategory = await Context.ChildCategories.FindAsync(id);
//        //        if (ChildCategory == null) continue;
//        //        ChildCategoies.Add(ChildCategory);
//        //    }
//        //    if (ChildCategoies.Count == 0) return BadRequest();
//        //    return Ok(ChildCategoies);
//        //}

//        [HttpPost]
//        public async Task<IActionResult> CreateChildCategory([FromBody] ChildCategoryDto ChildCategoryDto)
//        {
//            if (!ModelState.IsValid || ChildCategoryDto == null) return BadRequest();


//            var ChildCategory = new ChildCategory
//            {
//                CreatedAt= DateTime.Now,
//                UpdatedAt = DateTime.Now,
//                Slug = ChildCategoryDto.Slug,
//                Name = ChildCategoryDto.Name,
//                Status = 1,
//                SubCategoryId = ChildCategoryDto.SubCategoryId,
//            };
//            await Context.ChildCategories.AddAsync(ChildCategory);
//            await Context.SaveChangesAsync();
//            return Ok(ChildCategory);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateChildCategory(int id, ChildCategoryDto ChildCategoryDto)
//        {
//            if (id <= 0 || ChildCategoryDto == null) return BadRequest();
//            var ChildCategory = await Context.ChildCategories.FindAsync(id);
//            if (ChildCategory == null) return NotFound();

//            ChildCategory.Name = ChildCategoryDto.Name;
//            ChildCategory.Slug = ChildCategoryDto.Slug;
//            ChildCategory.Status = ChildCategoryDto.Status;
//            ChildCategory.SubCategoryId = ChildCategoryDto.SubCategoryId;
//            ChildCategory.UpdatedAt = DateTime.UtcNow;

//            Context.ChildCategories.Update(ChildCategory);
//            await Context.SaveChangesAsync();
//            return Ok(ChildCategory);
//        }

//        [HttpDelete]
//        public async Task<IActionResult> DeleteChildCategory([FromQuery] List<int> ids)
//        {
//            if (ids == null) return BadRequest();
//            var ChildCategoies = new List<ChildCategory>();
//            foreach (var id in ids)
//            {
//                if (id <= 0) continue;
//                var ChildCategory = await Context.ChildCategories.FindAsync(id);
//                if (ChildCategory == null) continue;
//                Context.ChildCategories.Remove(ChildCategory);
//                ChildCategoies.Add(ChildCategory);
//            }
//            await Context.SaveChangesAsync();
//            if (ChildCategoies.Count == 0) return BadRequest();
//            return Ok(ChildCategoies);
//        }
//    }
//}
