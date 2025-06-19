using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandMadeEcommece.Models.Data;

public class Product
{
    public int Id { get; set; }
    public int VendorId { get; set; }   

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    [Column(TypeName = "VARCHAR(255)")]
    public string ThumbImage { get; set; }


    //public int? ChildCategoryId { get; set; }
    public int? CategoryId { get; set; }
    public int? BrandId { get; set; }
    public int? CouponId {  get; set; }

    public int Qty { get; set; }

    public string ShortDescription { get; set; } = null!;

    public string LongDescription { get; set; } = null!;

    public string? Sku { get; set; }

    public double Price { get; set; }

    public double? OfferPrice { get; set; }

    public DateTime? OfferStartDate { get; set; }

    public DateTime? OfferEndDate { get; set; }

    public string? ProductType { get; set; }

    public int IsApproved { get; set; }

    public string? SeoTitle { get; set; }

    public string? SeoDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Brand Brand { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public Vendor Vendor { get; set; } = null!;
    //public ChildCategory ChildCategory { get; set; } = null!;
    public Coupon Coupon { get; set; } = null!;
   // public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
   public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<Cart> Carts { get; set; } = new List<Cart>(); 
    public ICollection<ProductImageGallery> ProductImagesGallery { get; set; } = new List<ProductImageGallery>();
    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    public ICollection<WishList> WishList { get; set; } = new List<WishList>();
    public ICollection<User> Users { get; set; }=new List<User>();
    public ICollection<AdminProduct> AdminProducts { get; set; } = new List<AdminProduct>();
    public ICollection<Admin>admins { get; set; } = new List<Admin>();
   // public ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
   // public ICollection<VendorProduct> VendorProducts { get; set; } = new List<VendorProduct>();
    public ICollection<Order> orders { get; set;} = new List<Order>();
    public ICollection<OrderProduct> ordersProducts { get; set; } = new List<OrderProduct>();
}
