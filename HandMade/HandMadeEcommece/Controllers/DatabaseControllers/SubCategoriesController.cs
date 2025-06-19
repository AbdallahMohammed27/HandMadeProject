//using HandMadeEcommece.Models.Data;
//using HandMadeEcommece.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HandMadeEcommece.Controllers.DatabaseControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SubCategoriesController : ControllerBase
//    {
//        private readonly AppDbContext Context;
//        public SubCategoriesController(AppDbContext _Context)
//        {
//            Context = _Context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetSubCategoiesAll()
//        {
//            var SubCategoies = await Context.SubCategories.ToListAsync();
//            if (SubCategoies == null) return NotFound();
//            return Ok(SubCategoies);
//        }


//        //[HttpGet]
//        //public async Task<IActionResult> GetSubCategory([FromQuery] List<int> ids)
//        //{
//        //    if (ids == null) return BadRequest();
//        //    var SubCategoies = new List<SubCategory>();
//        //    foreach (var id in ids)
//        //    {
//        //        if (id <= 0) continue;
//        //        var SubCategory = await Context.SubCategories.FindAsync(id);
//        //        if (SubCategory == null) continue;
//        //        SubCategoies.Add(SubCategory);
//        //    }
//        //    if (SubCategoies.Count == 0) return BadRequest();
//        //    return Ok(SubCategoies);
//        //}

//        [HttpPost]
//        public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryDto SubCategoryDto)
//        {
//            if (!ModelState.IsValid || SubCategoryDto == null) return BadRequest();


//            var SubCategory = new SubCategory
//            {
//                CategoryId = SubCategoryDto.CategoryId,
//                CreatedAt = DateTime.UtcNow,
//                UpdatedAt= DateTime.UtcNow,
//                Name = SubCategoryDto.Name,
//                Slug = SubCategoryDto.Slug,
//                Status = 1,
//            };
//            await Context.SubCategories.AddAsync(SubCategory);
//            await Context.SaveChangesAsync();
//            return Ok(SubCategory);
//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateSubCategory(int id, SubCategoryDto SubCategoryDto)
//        {
//            if (id <= 0 || SubCategoryDto == null) return BadRequest();
//            var SubCategory = await Context.SubCategories.FindAsync(id);
//            if (SubCategory == null) return NotFound();

//            SubCategory.Name = SubCategoryDto.Name;
//            SubCategory.Slug = SubCategoryDto.Slug;
//            SubCategory.Status = SubCategoryDto.Status;
//            SubCategory.CreatedAt = SubCategoryDto.CreatedAt;
//            SubCategory.CategoryId= SubCategoryDto.CategoryId;
//            SubCategory.UpdatedAt = DateTime.UtcNow;
            
//            Context.SubCategories.Update(SubCategory);
//            await Context.SaveChangesAsync();
//            return Ok(SubCategory);
//        }

//        [HttpDelete]
//        public async Task<IActionResult> DeleteSubCategory([FromQuery] List<int> ids)
//        {
//            if (ids == null) return BadRequest();
//            var SubCategoies = new List<SubCategory>();
//            foreach (var id in ids)
//            {
//                if (id <= 0) continue;
//                var SubCategory = await Context.SubCategories.FindAsync(id);
//                if (SubCategory == null) continue;
//                Context.SubCategories.Remove(SubCategory);
//                SubCategoies.Add(SubCategory);
//            }
//            await Context.SaveChangesAsync();
//            if (SubCategoies.Count == 0) return BadRequest();
//            return Ok(SubCategoies);
//        }
//    }
//}
