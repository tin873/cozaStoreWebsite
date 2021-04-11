using cozaStore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace cozaStore.DataAccessLayer
{
    public class DbInitializer : CreateDatabaseIfNotExists<cozaStoreDbContext>
    {
        protected override void Seed(cozaStoreDbContext context)
        {

            #region Add Category
            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryName = "Đồ Nam",
                    Description = "Quần áo nam chất liệu tốt thời thượng."
                },
                new Category()
                {
                    CategoryName = "Đồ Nữ",
                    Description = "Quần áo nữ chất liệu tốt thời thượng."
                },
                new Category()
                {
                    CategoryName = "Đồ Đôi",
                    Description = "Quần áo đôi trẻ trung năng động."
                },
                new Category()
                {
                    CategoryName = "Áo Khoác",
                    Description = "Quần áo chất liệu đẹp không lo bị lạnh."
                }
            };
            context.Categories.AddRange(categories);
            #endregion

            #region Add Role
            var roles = new List<Role>()
            {
                new Role()
                {
                    RoleID = 1,
                    RoleName = "Admin"
                },
                new Role()
                {
                    RoleID = 2,
                    RoleName = "User"
                }
            };
            context.Roles.AddRange(roles);
            #endregion

            #region Add Coupon
            var coupons = new List<Coupon>()
            {
                new Coupon()
                {
                    CouponCode = "TETDENROI",
                    Discount = 20,
                    Description ="Giảm giá nhân dịp tết"
                },
                new Coupon()
                {
                    CouponCode = "SINHNHAT",
                    Discount = 10,
                    Description ="Giảm giá nhân dịp sinh nhật"
                },
                new Coupon()
                {
                    CouponCode = "KHONGGIAMGIA",
                    Discount = 0,
                },
            };
            context.Coupons.AddRange(coupons);
            #endregion

            #region Add Supplier
            var suppliers = new List<Supplier>()
            {
                new Supplier()
                {
                    SupplierName = "Nguyễn Duy",
                    Address = "Hà Nội",
                    Phone = "0367641095"
                },
                new Supplier()
                {
                    SupplierName = "Phan Thị",
                    Address = "Hà Nam",
                    Phone = "0914300231"
                },
                new Supplier()
                {
                    SupplierName = "Hải Nam",
                    Address = "Hà Đông",
                    Phone = "0367641065"
                },
                new Supplier()
                {
                    SupplierName = "Hùng Cường",
                    Address = "Bắc Giang",
                    Phone = "0984884182"
                },
                new Supplier()
                {
                    SupplierName = "Nhuận Phát",
                    Address = "Hà Tĩnh",
                    Phone = "0393219136"
                },
                new Supplier()
                {
                    SupplierName = "Bá Khiêm",
                    Address = "Bắc Giang",
                    Phone = "0376548935"
                }
            };
            context.Suppliers.AddRange(suppliers);
            #endregion

            #region Add User
            var users = new List<User>()
            {
                new User()
                {
                    FullName = "Nguyễn Duy Tín",
                    Email = "tinduy@gmail.com",
                    PassWord = "tin123",
                    Address = "Hà Nội",
                    Phone = "0367641095",
                    Role = roles.FirstOrDefault(r => r.RoleID ==1)
                },
                new User()
                {
                    FullName = "Nguyễn Thị Hà",
                    Email = "hanguyen@gmail.com",
                    PassWord = "ha123",
                    Address = "Hà Nội",
                    Phone = "0674693659",
                    Role = roles.FirstOrDefault(r => r.RoleID ==1)
                },
                new User()
                {
                    FullName = "Nguyễn Thị Thu",
                    Email = "thu@gmail.com",
                    PassWord = "thu123",
                    Address = "Hà Nội",
                    Phone = "0914300231",
                    Role = roles.FirstOrDefault(r => r.RoleID ==2)
                },
                new User()
                {
                    FullName = "Lương Đình Nam",
                    Email = "namluong@gmail.com",
                    PassWord = "nam123",
                    Address = "Vĩnh Phúc",
                    Phone = "0367641096",
                    Role = roles.FirstOrDefault(r => r.RoleID ==2)
                }
            };
            context.Users.AddRange(users);
            #endregion

            #region Add Product
            var products = new List<Product>()
            {
                new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Nguyễn Duy")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nam")),
                    ProductName = "Áo somi M2SMN3",
                    Image = "aococnam1b.jpg",
                    Description = "Áo sơ mi chất liệu đẹp tôn dáng người mặc thoải mái mát mẻ mùa hè phù hợp với việc mặc đi chơi dã ngoại...",
                    Price = 250000,
                },
                new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Nguyễn Duy")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nam")),
                    ProductName = "Áo somi M2SMN5",
                    Image = "aococnam2.jpg",
                    Description = "Áo sơ mi chất liệu đẹp tôn dáng người mặc thoải mái mát mẻ mùa hè phù hợp với việc mặc đi chơi dã ngoại...",
                    Price = 250000
                },
                new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Nguyễn Duy")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nam")),
                    ProductName = "Áo Phông M2SPN2",
                    Image = "aophongnam1.jpg",
                    Description = "Áo phông chất liệu tốt mát mẻ cho mùa hè, thoáng khí giảm đi sự tự ti trong bạn.",
                    Price = 300000,
                },
                new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Nguyễn Duy")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nam")),
                    ProductName = "Áo somi M2SMN9",
                    Image = "aosomiNam1.jpg",
                    Description = "Áo sơ mi dài tay tạo nên sự thanh lịch và quý phái khi khoác lên mình còn chần chờ gì nữa đặt mua ngay thôi!",
                    Price = 300000,
                },
                new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Nguyễn Duy")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nam")),
                    ProductName = "Quần jean M2SMJ8",
                    Image = "quanjeannam1.jpg",
                    Description = "Sản phẩm quần jean là một sản phẩm có chất liệu tốt có thể phối cùng chiếc áo phông để giúp bạn trông bụi hơn hoặc có thể đi kèm 1 chiếc áo sơ mi để tạo lên sự thanh lịch.",
                    Price = 325000,
                },
                new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Phan Thị")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nữ")),
                    ProductName = "Áo phông MN2SM3",
                    Image = "aococnu1b.jpg",
                    Description = "Áo phông chất liệu đẹp tôn dáng người mặc thoải mái mát mẻ mùa hè có thể mặc đi chơi dã ngoại...",
                    Price = 180000,
                },
                 new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Phan Thị")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nữ")),
                    ProductName = "Áo tay dài M2SDN2",
                    Image = "aodainu1.jpg",
                    Description = "Áo dài tay dành cho nữ kiểu dáng thời thượng đang là xu thế trên thị trường và được nhiều bạn nữ săn đón có rất nhiều mầu sắc khác nhau..",
                    Price = 300000,
                },
                  new Product()
                {
                     Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Phan Thị")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nữ")),
                    ProductName = "Chân váy M2SCV3",
                    Image = "chanvaynu.jpg",
                    Description = "Chân váy M2SCV3 đang là 1 mẫu hot trên thị trường và được rất nhiều bạn trẻ săn đón rất phù hợp khi đi built cùng 1 chiếc áo sơ mi trắng!",
                    Price = 225000,
                },
                   new Product()
                {
                     Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Phan Thị")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Nữ")),
                    ProductName = "Quần bò NUDE23",
                    Image = "quanbonu1.jpg",
                    Description = "Quần bò chất liệu vải bò bền bỉ không những thế chiếc quần còn rất hợp thời trang thể hiện sự cá tính trong con người bạn.",
                    Price = 300000,
                },

                    new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Hùng Cường")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Đôi")),
                    ProductName = "Áo Ðôi M2SDG7",
                    Image = "aokhoacdoi1.jpg",
                    Description = "Áo khoác đôi rất ấm cho mùa đông không còn sợ cô đơn việc tránh rét không thể dễ hơn!",
                    Price = 800000,
                },
                    new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Hùng Cường")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Đồ Đôi")),
                    ProductName = "Áo Ðôi M2SMD3",
                    Image = "aophongdoi1.jpg",
                    Description = "Áo phông đôi mặc thoải mái phù hợp cho các bạn trẻ!",
                    Price = 350000,
                },
                     new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Hùng Cường")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Áo Khoác")),
                    ProductName = "Áo Khoác M2SDG2",
                    Image = "aokhoacbo1.jpg",
                    Description = "Áo khoác chắn gió giúp đi đường cản gió tránh gió không lo bị lạnh mặc là ấm...",
                    Price = 700000,
                },
                         new Product()
                {
                    Supplier = suppliers.FirstOrDefault(s => s.SupplierName.Equals("Nguyễn Duy")),
                    Category = categories.FirstOrDefault(c => c.CategoryName.Equals("Áo Khoác")),
                    ProductName = "Áo Khoác M2SDG1",
                    Image = "aokhoacbo2.jpg",
                    Description = "Áo khoác chắn gió giúp đi đường cản gió tránh gió không lo bị lạnh mặc là ấm...",
                    Price = 650000,
                }
            };
            context.Products.AddRange(products);
            #endregion

            #region Add ProductDetail
            var productDetails = new List<ProductDetail>()
            {
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN3")),
                    ProductName = "Áo somi M2SMN3-M-B",
                    Image = "aococnam1b.jpg",
                    Price = 250000,
                    Size = "M",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN3")),
                    ProductName = "Áo somi M2SMN3-L-B",
                    Image = "aococnam1b.jpg",
                    Price = 250000,
                    Size = "L",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN3")),
                    ProductName = "Áo somi M2SMN3-XL-B",
                    Image = "aococnam1b.jpg",
                    Price = 250000,
                    Size = "XL",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN3")),
                    ProductName = "Áo somi M2SMN3-XL-W",
                    Image = "aococnam1w.jpg",
                    Price = 250000,
                    Size = "XL",
                    Color = "Trắng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN3")),
                    ProductName = "Áo somi M2SMN3-L-W",
                    Image = "aococnam1w.jpg",
                    Price = 250000,
                    Size = "L",
                    Color = "Trắng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN3")),
                    ProductName = "Áo somi M2SMN3-M-W",
                    Image = "aococnam1w.jpg",
                    Price = 250000,
                    Size = "M",
                    Color = "Trắng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN5")),
                    ProductName = "Áo somi M2SMN5-M-B",
                    Image = "aococnam2.jpg",
                    Price = 250000,
                    Size = "M",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN5")),
                    ProductName = "Áo somi M2SMN5-L-B",
                    Image = "aococnam2.jpg",
                    Price = 250000,
                    Size = "L",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN5")),
                    ProductName = "Áo somi M2SMN5-XL-B",
                    Image = "aococnam2.jpg",
                    Price = 250000,
                    Size = "XL",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Phông M2SPN2")),
                    ProductName = "Áo Phông M2SPN2-F-C",
                    Image = "aophongnam1.jpg",
                    Price = 300000,
                    Size = "Free size",
                    Color = "Cam",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN9")),
                    ProductName = "Áo somi M2SMN9-M-B",
                    Image = "aosomiNam1.jpg",
                    Price = 300000,
                    Size = "M",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN9")),
                    ProductName = "Áo somi M2SMN9-L-B",
                    Image = "aosomiNam1.jpg",
                    Price = 300000,
                    Size = "L",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo somi M2SMN9")),
                    ProductName = "Áo somi M2SMN9-XL-B",
                    Image = "aosomiNam1.jpg",
                    Price = 300000,
                    Size = "XL",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Quần jean M2SMJ8")),
                    ProductName = "Quần jean M2SMJ8-29-B",
                    Image = "quanjeannam1.jpg",
                    Price = 325000,
                    Size = "29",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Quần jean M2SMJ8")),
                    ProductName = "Quần jean M2SMJ8-30-B",
                    Image = "quanjeannam1.jpg",
                    Price = 325000,
                    Size = "30",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Quần jean M2SMJ8")),
                    ProductName = "Quần jean M2SMJ8-31-B",
                    Image = "quanjeannam1.jpg",
                    Price = 325000,
                    Size = "31",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Quần jean M2SMJ8")),
                    ProductName = "Quần jean M2SMJ8-32-B",
                    Image = "quanjeannam1.jpg",
                    Price = 325000,
                    Size = "32",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-M-B",
                    Image = "aococnu1b.jpg",
                    Price = 180000,
                    Size = "M",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-L-B",
                    Image = "aococnu1b.jpg",
                    Price = 180000,
                    Size = "L",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-XL-B",
                    Image = "aococnu1b.jpg",
                    Price = 180000,
                    Size = "XL",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-XL-R",
                    Image = "aococnu1r.jpg",
                    Price = 180000,
                    Size = "XL",
                    Color = "Đỏ",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-L-R",
                    Image = "aococnu1r.jpg",
                    Price = 180000,
                    Size = "L",
                    Color = "Đỏ",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-M-R",
                    Image = "aococnu1r.jpg",
                    Price = 180000,
                    Size = "M",
                    Color = "Đỏ",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-XL-Y",
                    Image = "aococnu1y.jpg",
                    Price = 180000,
                    Size = "XL",
                    Color = "Vàng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-L-Y",
                    Image = "aococnu1y.jpg",
                    Price = 180000,
                    Size = "L",
                    Color = "Vàng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo phông MN2SM3")),
                    ProductName = "Áo phông MN2SM3-M-Y",
                    Image = "aococnu1y.jpg",
                    Price = 180000,
                    Size = "M",
                    Color = "Vàng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo tay dài M2SDN2")),
                    ProductName = "Áo tay dài M2SDN2-M-W",
                    Image = "aodainu1.jpg",
                    Price = 300000,
                    Size = "M",
                    Color = "Trắng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo tay dài M2SDN2")),
                    ProductName = "Áo tay dài M2SDN2-L-W",
                    Image = "aodainu1.jpg",
                    Price = 300000,
                    Size = "L",
                    Color = "Trắng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo tay dài M2SDN2")),
                    ProductName = "Áo tay dài M2SDN2-XL-W",
                    Image = "aodainu1.jpg",
                    Price = 300000,
                    Size = "XL",
                    Color = "Trắng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Chân váy M2SCV3")),
                    ProductName = "Chân váy M2SCV3-29-P",
                    Image = "chanvaynu.jpg",
                    Price = 225000,
                    Size = "29",
                    Color = "Hồng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Chân váy M2SCV3")),
                    ProductName = "Chân váy M2SCV3-30-P",
                    Image = "chanvaynu.jpg",
                    Price = 225000,
                    Size = "30",
                    Color = "Hồng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Chân váy M2SCV3")),
                    ProductName = "Chân váy M2SCV3-31-P",
                    Image = "chanvaynu.jpg",
                    Price = 225000,
                    Size = "31",
                    Color = "Hồng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Quần bò NUDE23")),
                    ProductName = "Quần bò NUDE23-29-B",
                    Image = "quanbonu1.jpg",
                    Price = 300000,
                    Size = "29",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Quần bò NUDE23")),
                    ProductName = "Quần bò NUDE23-30-B",
                    Image = "quanbonu1.jpg",
                    Price = 300000,
                    Size = "30",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Quần bò NUDE23")),
                    ProductName = "Quần bò NUDE23-31-B",
                    Image = "quanbonu1.jpg",
                    Price = 300000,
                    Size = "31",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Quần bò NUDE23")),
                    ProductName = "Quần bò NUDE23-32-B",
                    Image = "quanbonu1.jpg",
                    Price = 300000,
                    Size = "32",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Ðôi M2SDG7")),
                    ProductName = "Áo Ðôi M2SDG7-M-B",
                    Image = "aokhoacdoi1.jpg",
                    Price = 800000,
                    Size = "M",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Ðôi M2SDG7")),
                    ProductName = "Áo Ðôi M2SDG7-L-B",
                    Image = "aokhoacdoi1.jpg",
                    Price = 800000,
                    Size = "L",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Ðôi M2SDG7")),
                    ProductName = "Áo Ðôi M2SDG7-XL-B",
                    Image = "aokhoacdoi1.jpg",
                    Price = 800000,
                    Size = "XL",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Ðôi M2SMD3")),
                    ProductName = "Áo Ðôi M2SMD3-F-B",
                    Image = "aophongdoi1.jpg",
                    Price = 350000,
                    Size = "Free Size",
                    Color = "Đen",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Ðôi M2SMD3")),
                    ProductName = "Áo Ðôi M2SMD3-F-W",
                    Image = "aophongdoi1w.jpg",
                    Price = 350000,
                    Size = "Free Size",
                    Color = "Trắng",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Khoác M2SDG2")),
                    ProductName = "Áo Khoác M2SDG2-M-B",
                    Image = "aokhoacbo1.jpg",
                    Price = 700000,
                    Size = "M",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Khoác M2SDG2")),
                    ProductName = "Áo Khoác M2SDG2-L-B",
                    Image = "aokhoacbo1.jpg",
                    Price = 700000,
                    Size = "L",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Khoác M2SDG2")),
                    ProductName = "Áo Khoác M2SDG2-XL-B",
                    Image = "aokhoacbo1.jpg",
                    Price = 700000,
                    Size = "XL",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Khoác M2SDG1")),
                    ProductName = "Áo Khoác M2SDG1-M-B",
                    Image = "aokhoacbo2.jpg",
                    Price = 650000,
                    Size = "M",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Khoác M2SDG1")),
                    ProductName = "Áo Khoác M2SDG1-L-B",
                    Image = "aokhoacbo2.jpg",
                    Price = 650000,
                    Size = "L",
                    Color = "Xanh",
                    Quantity = 20
                },
                new ProductDetail()
                {
                    Product = products.FirstOrDefault(s => s.ProductName.Equals("Áo Khoác M2SDG1")),
                    ProductName = "Áo Khoác M2SDG1-XL-B",
                    Image = "aokhoacbo2.jpg",
                    Price = 650000,
                    Size = "XL",
                    Color = "Xanh",
                    Quantity = 20
                }
            };
            context.ProductDetails.AddRange(productDetails);
            #endregion
            context.SaveChanges();
        }
    }
}
