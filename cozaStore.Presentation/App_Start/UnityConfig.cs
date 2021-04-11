using cozaStore.BusinessLogicLayer;
using cozaStore.DataAccessLayer;
using cozaStore.Models;
using System;

using Unity;

namespace cozaStore.Presentation
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterSingleton<cozaStoreDbContext, cozaStoreDbContext>();
            container.RegisterSingleton<IDbFactory, DbFactory>();
            container.RegisterSingleton<IUnitOfWork, UnitOfWork>();

            container.RegisterType<ICheckOutServices, CheckOutServices>();

            container.RegisterType<IGenericReposistory<Category>, GenericReposistory<Category>>();
            container.RegisterType<ICategoryServices, CategoryServices>();

            container.RegisterType<IGenericReposistory<Comment>, GenericReposistory<Comment>>();
            container.RegisterType<ICommentServices, CommentServices>();

            container.RegisterType<IGenericReposistory<Contact>, GenericReposistory<Contact>>();
            container.RegisterType<IContactServices, ContactServices>();

            container.RegisterType<IGenericReposistory<Order>, GenericReposistory<Order>>();
            container.RegisterType<IOrderServices, OrderServices>();

            container.RegisterType<IGenericReposistory<OrderDetail>, GenericReposistory<OrderDetail>>();
            container.RegisterType<IOrderDetailServices, OrderDetailServices>();

            container.RegisterType<IGenericReposistory<Product>, GenericReposistory<Product>>();
            container.RegisterType<IProductServices, ProductServices>();

            container.RegisterType<IGenericReposistory<Supplier>, GenericReposistory<Supplier>>();
            container.RegisterType<ISupplierServices, SupplierServices>();

            container.RegisterType<IGenericReposistory<User>, GenericReposistory<User>>();
            container.RegisterType<IUserServieces, UserServices>();

            container.RegisterType<IGenericReposistory<Role>, GenericReposistory<Role>>();
            container.RegisterType<IRoleServices, RoleServices>();

            container.RegisterType<IGenericReposistory<Coupon>, GenericReposistory<Coupon>>();
            container.RegisterType<ICouponServices, CouponServices>();

            container.RegisterType<IGenericReposistory<ProductDetail>, GenericReposistory<ProductDetail>>();
            container.RegisterType<IProductDetailServices, ProductDetailServices>();
        }
    }
}