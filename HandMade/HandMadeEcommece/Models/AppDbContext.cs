using System;
using System.Collections.Generic;
using HandMadeEcommece.Controllers.DatabaseControllers;
using HandMadeEcommece.helper;
using HandMadeEcommece.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HandMadeEcommece.Models;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

   

    public DbSet<Admin>Admins { get; set; }
    public DbSet<AdminBrand>AdminBrands { get; set; }
    public DbSet<AdminOrder> AdminOrders { get; set; }
    public DbSet<AdminProduct> AdminProducts { get; set; }
    public DbSet<AdminTransaction> AdminTransactions { get; set; }
    public DbSet<AdminVendor> AdminVendors { get; set; }
    public DbSet<AdminVendorConditions> AdminVendorConditions { get; set; }
    public DbSet<AdminCategory> AdminCategories { get; set; }
    public DbSet<Role> Roles {  get; set; }
    public DbSet<ClaimAdmin> ClaimAdmins { get; set; }
    public DbSet<ClaimRole> ClaimRoles { get; set; }
    public DbSet<ClaimUser>ClaimUsers { get; set; }
    public DbSet<ClaimVendor>ClaimVendors { get; set; }
    public DbSet<CheckUserNameAndEmail>checkUserNameAndEmails { get; set; }
    public DbSet<AdminAddress> AdminAddresses { get; set; }
    public DbSet<VendorAddress> VendorAddresses { get; set; }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Chat> Chats { get; set; }

   // public DbSet<ChildCategory> ChildCategories { get; set; }

    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<DeliveryCompany>DeliveryCompanies { get; set; }


    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }

    public DbSet<OrderVendor> OrderVendorOrders { get; set; }

    public DbSet<PaypalSetting> PaypalSettings { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductImageGallery> ProductImageGalleries { get; set; }

    public DbSet<ProductReview> ProductReviews { get; set; }

    public DbSet<ProductReviewGallery> ProductReviewGalleries { get; set; }

   // public DbSet<ProductVariant> ProductVariants { get; set; }

//    public DbSet<ProductVariantItem> ProductVariantItems { get; set; }

    public DbSet<PusherSetting> PusherSettings { get; set; }

   // public DbSet<SubCategory> SubCategories { get; set; }

    public DbSet<TransactionMoney> Transactions { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<UserCoupons> UserCoupons { get; set; }

    public DbSet<UserAddress> UserAddresses { get; set; }

    public DbSet<Vendor> Vendors { get; set; }

    public DbSet<VendorCondition> VendorConditions { get; set; }
   // public DbSet<VendorProduct> VendorProducts { get; set; }
    public DbSet<VendorTransaction>VendorTransactions { get; set; }
    public DbSet<WishList> WishList { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}
