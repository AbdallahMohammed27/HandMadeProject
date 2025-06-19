
using HandMadeEcommece.Models.Data;

namespace HandMadeEcommece.Services
{
    public interface IAuth
    {
        Task<AuthModel> RegisterUserAsync(RegisterUserModel Model, HttpContext httpContext);
        Task<AuthModel> LogInUserAsync(LogInUserModel Model);

        Task<AuthModel>RegisterAdminAsync(RegisterAdminDto Model, HttpContext httpContext);
        Task<AuthModel> LogInAdminAsync(LogInAdmin Model);

        Task<AuthModel> RegisterVendorAsync(RegisterVendor Model, HttpContext httpContext);
        Task<AuthModel> LogInVendorAsync(LogInVendor Model);
        Task<Order> ProcessOfOrder(Order order, OrderDto orderDto);
        Task<ChangePasswordDto> ChangePassword(ChangePasswordDto ChangePassword);

    }
}
