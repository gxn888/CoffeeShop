using System.Data.Common;
using System.Data.Entity;
using Abp.Application.Editions;
using Abp.Organizations;
using Abp.Zero.EntityFramework;
using YT.Authorizations;
using YT.Managers.MultiTenancy;
using YT.Managers.Roles;
using YT.Managers.Users;
using YT.Models;
using YT.MultiTenancy;
using YT.Navigations;
using YT.Organizations;
using YT.Storage;

namespace YT.EntityFramework
{
    /* Constructors of this DbContext is important and each one has it's own use case.
     * - Default constructor is used by EF tooling on design time.
     * - constructor(nameOrConnectionString) is used by ABP on runtime.
     * - constructor(existingConnection) is used by unit tests.
     * - constructor(existingConnection,contextOwnsConnection) can be used by ABP if DbContextEfTransactionStrategy is used.
     * See http://www.aspnetboilerplate.com/Pages/Documents/EntityFramework-Integration for more.
     */
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MilkDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
       /// <summary>
       /// 对象存储
       /// </summary>
        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }
        /// <summary>
        /// 菜单配置
        /// </summary>
        public virtual IDbSet<Menu> Menus { get; set; }
        /// <summary>
        /// 权限配置
        /// </summary>
        public virtual IDbSet<YtPermission> YtPermissions { get; set; }

        public new virtual IDbSet<Organization> OrganizationUnits { get; set; }
        /// <summary>
        /// 点位
        /// </summary>
        public virtual  IDbSet<Point> Points { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public virtual  IDbSet<Order> Orders { get; set; }
        /// <summary>
        /// 故障
        /// </summary>
        public virtual  IDbSet<Warn> Warns { get; set; }
        
        /// <summary>
        /// 产品
        /// </summary>
        public virtual  IDbSet<Product> Products { get; set; }
        public virtual  IDbSet<SignRecord> SignRecords { get; set; }
        public virtual  IDbSet<SignProfile> SignProfiles { get; set; }
        /// <summary>
        /// 用户点位对应
        /// </summary>
        public virtual  IDbSet<UserPoint> UserPoints { get; set; }
        /// <summary>
        /// 商品订单
        /// </summary>
        public virtual  IDbSet<StoreOrder> StoreOrders { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual  IDbSet<StoreUser> StoreUsers { get; set; }
        /// <summary>
        /// 用户卡券
        /// </summary>
        public virtual  IDbSet<UserCard> UserCards { get; set; }
        /// <summary>
        /// 充值类型
        /// </summary>
        public virtual IDbSet<ChargeType> ChargeTypes { get; set; }
        
        public MilkDbContext()
            : base("Default")
        {

        }

        public MilkDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public MilkDbContext(DbConnection existingConnection)
           : base(existingConnection, false)
        {

        }

        public MilkDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Ignore(a => a.Surname);
            modelBuilder.Entity<User>().Property(a => a.EmailAddress).IsOptional();
          
        }
    }
}
