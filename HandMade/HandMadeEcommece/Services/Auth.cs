
global using Microsoft.AspNetCore.Identity;
global using HandMadeEcommece.helper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using HandMadeEcommece.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using HandMadeEcommece.Models.Data;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using HandMadeEcommece.Models.Dto;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.OutputCaching;



namespace HandMadeEcommece.Services
{
    public class Auth : IAuth
    {
        private readonly UserManager<AppUser> _Manager;
        private readonly JWT _jwt;
        private readonly AppDbContext _Context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;
        public Auth(UserManager<AppUser> Manager, IOptions<JWT> jwt, AppDbContext Context, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _Manager = Manager;
            _jwt = jwt.Value;
            _Context = Context;
            this.httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
        }


        public async Task<AuthModel> RegisterUserAsync(RegisterUserModel Model, HttpContext httpContext)
        {

            var checkEmail = await _Context.checkUserNameAndEmails.FirstOrDefaultAsync(e => e.Email == Model.Email);
            var checkUserName = await _Context.checkUserNameAndEmails.FirstOrDefaultAsync(e => e.UserName == Model.UserName);

            if (checkEmail != null) { return new AuthModel { Message = "This Email is already found" }; }
            if (checkUserName != null) { return new AuthModel { Message = "This UserName is already found" }; }
            //if(Model.RoleId <= 0 ||await _Context.Roles.FirstOrDefaultAsync(e=>e.Id == Model.RoleId) == null) { return new AuthModel { Message = "This Role Is Not Found" }; }
            if(!await Methods.IsValidEmail(Model.Email)) { return new AuthModel { Message = "This Email is not valid." }; }
            if(!await Methods.IsValidPhone(Model.Phone)) { return new AuthModel { Message = "This Phone is not valid in egypt." }; }
           // var httpContext = httpContextAccessor.HttpContext;
            var user = new User// change from appuser to user
            {
                Email = Model.Email,
                Phone = Model.Phone,
                UserName = Model.UserName,
                FName = Model.FName,
                LName = Model.LName,
                Password = Model.Password,
                Image = Model.Image,
                RoleId = 1
            };


            await _Context.Users.AddAsync(user);
            await _Context.checkUserNameAndEmails.AddAsync(new CheckUserNameAndEmail { UserName = Model.UserName, Email = Model.Email });
            await _Context.SaveChangesAsync();
            //var GetUser = await _Context.Users.FirstOrDefaultAsync(e => e.UserName == Model.UserName);

            var token = await CreateJwtToken(user);
            return new AuthModel
            {
                Id = user.Id,
                Email = user.Email,
                ExpiresOn = token.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Customer" },
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<AuthModel> LogInUserAsync(LogInUserModel Model)
        {
            var authModel = new AuthModel();
            var user = await _Context.checkUserNameAndEmails.FirstOrDefaultAsync(e=>e.UserName == Model.UserName);
            var password = ""; 
            var role = "";
            int id=0;
            var token = new JwtSecurityToken();
            if(await _Context.Vendors.FirstOrDefaultAsync(e=>e.UserName == Model.UserName) != null)
            {
                var vendor = await _Context.Vendors.FirstOrDefaultAsync(e => e.UserName == Model.UserName);
                token = await CreateJwtToken(vendor);
                password = vendor.Password;
                id = vendor.Id;
                role = "Vendor";
            }
           else if (await _Context.Users.FirstOrDefaultAsync(e => e.UserName == Model.UserName) != null)
            {
                var User = await _Context.Users.FirstOrDefaultAsync(e => e.UserName == Model.UserName);
                token = await CreateJwtToken(User);
                password = User.Password;
                id = User.Id;
                role = "Customer";
            }
           else if (await _Context.Admins.FirstOrDefaultAsync(e => e.UserName == Model.UserName) != null)
            {
                var admin = await _Context.Admins.FirstOrDefaultAsync(e => e.UserName == Model.UserName);
                token = await CreateJwtToken(admin);
                password = admin.Password;
                id = admin.Id;
                role = "Admin";
            }
            if (user == null || (Model.Password != null && Model.Password != password))
            {
                authModel.Message = "UserName Or Password Is InCorrect";
                return authModel;
            }


            authModel.Id = id;
            authModel.ExpiresOn = token.ValidTo;
            authModel.UserName = user.UserName;
            authModel.IsAuthenticated = true;
            authModel.Email = user.Email;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authModel.Roles = new List<string> { role };


            return authModel;
        }

        public async Task<AuthModel> RegisterAdminAsync(RegisterAdminDto Model,HttpContext httpContext)
        {

            var checkEmail = await _Context.checkUserNameAndEmails.FirstOrDefaultAsync(e => e.Email == Model.Email);
            var checkUserName = await _Context.checkUserNameAndEmails.FirstOrDefaultAsync(e => e.UserName == Model.UserName);

            if (checkEmail != null) { return new AuthModel { Message = "This Email is already found" }; }
            if (checkUserName != null) { return new AuthModel { Message = "This UserName is already found" }; }
           // if (Model.RoleId <= 0 || await _Context.Roles.FirstOrDefaultAsync(e => e.Id == Model.RoleId) == null) { return new AuthModel { Message = "This Role Is Not Found" }; }
            if (!await Methods.IsValidEmail(Model.Email)) { return new AuthModel { Message = "This Email is not valid." }; }
            if (!await Methods.IsValidPhone(Model.Phone)) { return new AuthModel { Message = "This Phone is not valid in egypt." }; }
           // var httpContext = httpContextAccessor.HttpContext;
            var admin = new Admin
            {
                UserName = Model.UserName,
                Password = Model.Password,
                Email = Model.Email,
                LName = Model.LName,
                FName = Model.FName,
                Phone = Model.Phone,
                Salary = Model.Salary,
                Image  = Model.image,
                Address = Model.Address,
                RoleId = 3
            };

      


            await _Context.Admins.AddAsync(admin);
            await _Context.checkUserNameAndEmails.AddAsync(new CheckUserNameAndEmail { UserName = Model.UserName, Email = Model.Email });
            await _Context.SaveChangesAsync();


            var token = await CreateJwtToken(admin);
            return new AuthModel
            {
                Id = admin.Id,
                Email = admin.Email,
                ExpiresOn = token.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Admin" },
                UserName = admin.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }


        public async Task<AuthModel> LogInAdminAsync(LogInAdmin Model)
        {
            var authModel = new AuthModel();
            var user = await _Context.Admins.FirstOrDefaultAsync(e=>e.UserName == Model.UserName);
            if (user == null || Model.Password != user.Password)
            {
                authModel.Message = "UserName Or Password Is InCorrect";
                return authModel;
            }

            var token = await CreateJwtToken(user);
            return new AuthModel
            {
                Id = user.Id,
                IsAuthenticated = true,
                Email = user.Email,
                UserName = user.UserName,
                Roles = new List<string> { "Admin"},
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo,
            };

        }

        public async Task<AuthModel> RegisterVendorAsync(RegisterVendor Model, HttpContext httpContext)
        {
            var checkEmail = await _Context.checkUserNameAndEmails.FirstOrDefaultAsync(e=>e.Email == Model.Email);
            var checkUserName = await _Context.checkUserNameAndEmails.FirstOrDefaultAsync(e=>e.UserName == Model.UserName);

            if (checkEmail != null) { return new AuthModel { Message = "This Email is already found" }; }
            if (checkUserName != null) { return new AuthModel { Message = "This UserName is already found" }; }
           // if (Model.RoleId <= 0 || await _Context.Roles.FirstOrDefaultAsync(e => e.Id == Model.RoleId) == null) { return new AuthModel { Message = "This Role Is Not Found" }; }
            if (!await Methods.IsValidEmail(Model.Email)) { return new AuthModel { Message = "This Email is not valid." }; }
            if (!await Methods.IsValidPhone(Model.Phone)) { return new AuthModel { Message = "This Phone is not valid in egypt." }; }
            // var httpContext = httpContextAccessor.HttpContext;
            var vendor = new Vendor
            {
                Email = Model.Email,
                Phone = Model.Phone,
                UserName = Model.UserName,
                FName = Model.FName,
                LName = Model.LName,
                Image = Model.Image,
                RoleId = 2,
                FbLink = Model.FbLink,
                InstaLink = Model.InstaLink,
                TwLink = Model.TwLink,
                Status = 1,
                ShopName = Model.ShopName,
                Banner = Model.Image,
                Address = Model.Address,
                Description = Model.Description,
                Password = Model.Password,
            };



            await _Context.Vendors.AddAsync(vendor);
            await _Context.checkUserNameAndEmails.AddAsync(new CheckUserNameAndEmail { UserName = Model.UserName, Email = Model.Email });
            await _Context.SaveChangesAsync();



            var token = await CreateJwtToken(vendor);
            return new AuthModel
            {
                Id = vendor.Id,
                Email = vendor.Email,
                ExpiresOn = token.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Vendor" },
                UserName = vendor.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
        public async Task<AuthModel> LogInVendorAsync(LogInVendor Model)
        {
            var authModel = new AuthModel();
            var user = await _Context.Vendors.FirstOrDefaultAsync(e=>e.UserName == Model.UserName);
            if (user == null || Model.Password != user.Password)
            {
                authModel.Message = "UserName Or Password Is InCorrect";
                return authModel;
            }
            var Vendor = await _Context.Vendors.FirstOrDefaultAsync(e=>e.UserName == Model.UserName);
            if (Vendor == null || Vendor.Status == 0) { return new AuthModel { Message = "This Vendor Is Broken" }; }

            var token = await CreateJwtToken(user);
            return new AuthModel
            {
                Id = user.Id,
                IsAuthenticated = true,
                Email = user.Email,
                UserName = user.UserName,
                Roles = new List<string> { "Vendor"},
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo,
            };
        }


        public async Task<ChangePasswordDto> ChangePassword(ChangePasswordDto ChangePassword)
        {
                
            var user = await _Context.checkUserNameAndEmails.FirstOrDefaultAsync(e=>e.UserName == ChangePassword.UserName);
            if (user == null) { return new ChangePasswordDto { Message = "This User Not Found" }; }
            string password = "";
            bool us = false, ad = false, vd = false;
            if(await _Context.Users.FirstOrDefaultAsync(e=>e.UserName == ChangePassword.UserName) != null)
            {
                var ur = await _Context.Users.FirstOrDefaultAsync(e => e.UserName == ChangePassword.UserName);
                if (ur != null) { password = ur.Password;us = true; }
            }
            else if(await _Context.Admins.FirstOrDefaultAsync(e => e.UserName == ChangePassword.UserName) != null)
            {
                var ur = await _Context.Admins.FirstOrDefaultAsync(e => e.UserName == ChangePassword.UserName);
                if (ur != null) { password = ur.Password;ad = true; }
            }
            else
            {
                var ur = await _Context.Vendors.FirstOrDefaultAsync(e => e.UserName == ChangePassword.UserName);
                if (ur != null) { password = ur.Password; vd = true; }
            }
            if (ChangePassword.CurrentPassword != password) 
            { 
                return new ChangePasswordDto { Message = "The Password Is Wrong!!!" }; 
            }

                if(ad == true)
                {
                    var adn = await _Context.Admins.FirstOrDefaultAsync(e => e.UserName == ChangePassword.UserName);
                    adn.Password = ChangePassword.NewPassword;
                    _Context.Admins.Update(adn);
                }
                else if(us == true)
                {
                    var uer = await _Context.Users.FirstOrDefaultAsync(e => e.UserName == ChangePassword.UserName);
                    uer.Password = ChangePassword.NewPassword;
                    _Context.Users.Update(uer);
                }
                else
                {
                    var ved = await _Context.Vendors.FirstOrDefaultAsync(e => e.UserName == ChangePassword.UserName);
                    ved.Password = ChangePassword.NewPassword;
                    _Context.Vendors.Update(ved);
                }
               await _Context.SaveChangesAsync();

           

            return new ChangePasswordDto
            {
                UserName = ChangePassword.UserName,
                CurrentPassword = ChangePassword.CurrentPassword,
                NewPassword = ChangePassword.NewPassword,
                Message = "PasswordChangedSuccess",
                IsChange = true
            };
        }


        public async Task<Order> ProcessOfOrder(Order order, OrderDto orderDto)
        {
            //first->product_ID
            //second->Qty_product

            var vendors = new List<Vendor>();
            var products = new List<Product>();
            User user = null!;
            DeliveryCompany company = null!;
            if (orderDto.UserId != null) user = await _Context.Users.FindAsync(orderDto.UserId);
            if (orderDto.CompanyDeliveryId != null) company = await _Context.DeliveryCompanies.FindAsync(orderDto.CompanyDeliveryId);
            bool ok = false;
            foreach (var t in orderDto.ProductsOrder)
            {
                if (t.ProductId <= 0 || t.Quantity < 0) continue;
                var product = await _Context.Products.FindAsync(t.ProductId);
                if (product == null) continue;
                product.Qty -= t.Quantity;
                products.Add(product);
            }

            var VendorIds = orderDto.ProductsOrder.Select(e => e.VendorId).Distinct().ToList();
            if (VendorIds != null)
            {

                foreach (var id in VendorIds)
                {


                    

                    var vendor = await _Context.Vendors.FindAsync(id);
                    if (vendor == null) continue;
                    //var vendorAddress = await _Context.VendorAddresses.Where(e => e.VendorId == vendor.Id).ToListAsync();

                    vendors.Add(vendor);
                    var email = vendor.Email;


                    // Get products for this vendor
                    var vendorProducts = orderDto.ProductsOrder.Where(e => e.VendorId == id).ToList();


                    if (!vendorProducts.Any()) continue;

                    // Get detailed product data
                    var detailedProducts = new List<(string Name, double Price, int Quantity, string Image, string Type, string Desc, string VendorName, string Phone, string VendorAddress, string OrderAddress)>();
                    foreach (var po in vendorProducts)
                    {
                        var product = await _Context.Products.FindAsync(po.ProductId);
                        var Qun = orderDto.ProductsOrder.Where(e => e.ProductId == product.Id).Select(e => e.Quantity).ToList();
                        if (product != null)
                        {
                            detailedProducts.Add((
                                product.Name,
                                product.Price,
                                Qun.First(),
                                product.ThumbImage,
                                product.ProductType,
                                product.ShortDescription,
                                vendor.UserName,
                                vendor.Phone,
                                vendor.Address,
                                orderDto.OrderAddress
                            ));
                        }
                    }

                   // Construct HTML email
                   var bodyBuilder = new StringBuilder();
                    bodyBuilder.Append(@"
                    <div style='font-family: Arial, sans-serif; padding: 10px;'>
                        <h2 style='color: #4CAF50;'>🛒 Products Ordered from You</h2>
                        <table style='width: 100%; border-collapse: collapse;'>
                            <thead>
                                <tr style='background-color: #f2f2f2;'>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Name</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Price</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Quantity</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Image</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Type</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Description</th>
                                </tr>
                            </thead>
                            <tbody>");

                    foreach (var p in detailedProducts)
                    {
                        bodyBuilder.Append(@$"
                        <tr>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Name}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>${p.Price:0.00}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Quantity}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>
                                <img src='{p.Image}' alt='Product Image' style='max-width: 80px;' />
                            </td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Type}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Desc}</td>
                        </tr>");
                    }

                    bodyBuilder.Append(@"
                            </tbody>
                        </table>
                    </div>");




                    var bodyBuilderDelivery = new StringBuilder();
                    bodyBuilderDelivery.Append(@"
                    <div style='font-family: Arial, sans-serif; padding: 10px;'>
                        <h2 style='color: #2196F3;'>🚚 Products Ordered For Delivery</h2>
                        <table style='width: 100%; border-collapse: collapse;'>
                            <thead>
                                <tr style='background-color: #f9f9f9;'>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Name</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Price</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Quantity</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Image</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Type</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Description</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>VendorName</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Phone</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Vendor Address</th>
                                    <th style='border: 1px solid #ddd; padding: 8px;'>Order Address</th>
                                </tr>
                            </thead>
                            <tbody>");

                    foreach (var p in detailedProducts)
                    {
                        bodyBuilderDelivery.Append(@$"
                        <tr>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Name}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>${p.Price:0.00}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Quantity}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>
                                <img src='{p.Image}' alt='Product Image' style='max-width: 80px;' />
                            </td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Type}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Desc}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.VendorName}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.Phone}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.VendorAddress}</td>
                            <td style='border: 1px solid #ddd; padding: 8px;'>{p.OrderAddress}</td>
                        </tr>");
                    }

                    bodyBuilderDelivery.Append(@"
                            </tbody>
                        </table>
                    </div>");


                    var subject = "New Order for Your Products.";
                    var UserMessage = "Details To Your Order.";
                    var body = bodyBuilder.ToString();

                    if (user != null)
                    {
                        await Methods.Notifications(user.Email, "Customer", UserMessage, body);
                    }
                    var bodyDelivery = bodyBuilderDelivery.ToString();

                    await Methods.Notifications(email, "Vendor", subject, body);
                    if (company != null) await Methods.Notifications(company.Email, "Delivery", $"These Orders For Delivery From Vendor{vendor.UserName}", bodyDelivery);

                }
            }
            


            _Context.Products.UpdateRange(products);
            await _Context.SaveChangesAsync();


                order.CompanyDeliveryId = orderDto.CompanyDeliveryId;
                order.Amount = orderDto.SubTotal;//calucalate coupon and discount
                order.OrderStatus = orderDto.OrderStatus.ToString();
                order.UserId = orderDto.UserId;
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;
                order.CurrencyName = orderDto.CurrencyName.ToString();
                order.OrderAddress = orderDto.OrderAddress;
                order.PaymentMethod = orderDto.PaymentMethod.ToString();
                order.product = products;
                order.vendor = vendors;

                return order;
       }
        private async Task<JwtSecurityToken> CreateJwtToken<TEntity>(TEntity entity) where TEntity : class
        {
            var ClaimsEntity = new List<Claim>();
            var RolesEntity = new List<Role>();
            var user = new CheckUserNameAndEmail();
            if(typeof(TEntity).Name == "Admin")
            {
                var ProperityId = typeof(TEntity).GetProperty("Id");
                var adminId = ProperityId.GetValue(entity);
                var Id = Convert.ToInt32(adminId);
                ClaimsEntity = await _Context.ClaimAdmins.Where(e => e.AdminId == Id).Select(c=>new Claim ( c.ClaimType, c.ClaimValue)).ToListAsync();
                RolesEntity = await _Context.Roles.Where(e=>e.Id == Id).ToListAsync();
                var admin = await _Context.Admins.FindAsync(Id);
                user.UserName = admin.UserName;
                user.Email = admin.Email;
            }
            if(typeof(TEntity).Name == "Vendor")
            {
                var ProperityId = typeof(TEntity).GetProperty("Id");
                var vendorId = ProperityId.GetValue(entity);
                var Id = Convert.ToInt32(vendorId);
                ClaimsEntity = await _Context.ClaimVendors.Where(e => e.VendorId == Id).Select(c=>new Claim(c.ClaimType,c.ClaimType)).ToListAsync();
                RolesEntity = await _Context.Roles.Where(e => e.Id == Id).ToListAsync();
                var vendor = await _Context.Vendors.FindAsync(Id);
                user.UserName = vendor.UserName;
                user.Email = vendor.Email;
            }
            if(typeof(TEntity).Name == "User")
            {
                var ProperityId = typeof(TEntity).GetProperty("Id");
                var userId = ProperityId.GetValue(entity);
                var Id = Convert.ToInt32(userId);
                ClaimsEntity = await _Context.ClaimUsers.Where(e => e.UserId == Id).Select(c=>new Claim(c.ClaimType,c.ClaimValue)).ToListAsync();
                RolesEntity = await _Context.Roles.Where(e => e.Id == Id).ToListAsync();
                var User = await _Context.Users.FindAsync(Id);
                user.UserName = User.UserName;
                user.Email = User.Email;
            }
            //var userClaims = await _Manager.GetClaimsAsync(user);
            //var roles = await _Manager.GetRolesAsync(user);
            var roleClaims = RolesEntity
            .Select(role => new Claim("roles", role.Name)) 
                .ToList();


            var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    };

            claims.AddRange(roleClaims);
            claims.AddRange(ClaimsEntity);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_jwt.Expire)

            );
            return token;
        }
    }
}
