using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VinaOfficeWebsite.Database;

public partial class BzVinaofficeContext : DbContext
{
    public BzVinaofficeContext()
    {
    }

    public BzVinaofficeContext(DbContextOptions<BzVinaofficeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminFunctionAdminGroupUser> AdminFunctionAdminGroupUsers { get; set; }

    public virtual DbSet<BzAbout> BzAbouts { get; set; }

    public virtual DbSet<BzAboutList> BzAboutLists { get; set; }

    public virtual DbSet<BzAd> BzAds { get; set; }

    public virtual DbSet<BzAdminFunction> BzAdminFunctions { get; set; }

    public virtual DbSet<BzAdminFunctionGroup> BzAdminFunctionGroups { get; set; }

    public virtual DbSet<BzAdminLang> BzAdminLangs { get; set; }

    public virtual DbSet<BzAdminUser> BzAdminUsers { get; set; }

    public virtual DbSet<BzAdminUserGroup> BzAdminUserGroups { get; set; }

    public virtual DbSet<BzAdsSend> BzAdsSends { get; set; }

    public virtual DbSet<BzBanner> BzBanners { get; set; }

    public virtual DbSet<BzContact> BzContacts { get; set; }

    public virtual DbSet<BzKho> BzKhos { get; set; }

    public virtual DbSet<BzLang> BzLangs { get; set; }

    public virtual DbSet<BzList> BzLists { get; set; }

    public virtual DbSet<BzListPic> BzListPics { get; set; }

    public virtual DbSet<BzLog> BzLogs { get; set; }

    public virtual DbSet<BzMenu> BzMenus { get; set; }

    public virtual DbSet<BzOrder> BzOrders { get; set; }

    public virtual DbSet<BzOrderNew> BzOrderNews { get; set; }

    public virtual DbSet<BzOrderNewProduct> BzOrderNewProducts { get; set; }

    public virtual DbSet<BzOrderProduct> BzOrderProducts { get; set; }

    public virtual DbSet<BzProduct> BzProducts { get; set; }

    public virtual DbSet<BzProductCate> BzProductCates { get; set; }

    public virtual DbSet<BzProductPicture> BzProductPictures { get; set; }

    public virtual DbSet<BzProductPrice> BzProductPrices { get; set; }

    public virtual DbSet<BzProductSize> BzProductSizes { get; set; }

    public virtual DbSet<BzSeo> BzSeos { get; set; }

    public virtual DbSet<BzSiteOption> BzSiteOptions { get; set; }

    public virtual DbSet<BzSiteOptionGroup> BzSiteOptionGroups { get; set; }

    public virtual DbSet<BzSlide> BzSlides { get; set; }

    public virtual DbSet<BzSupport> BzSupports { get; set; }

    public virtual DbSet<BzTag> BzTags { get; set; }

    public virtual DbSet<BzThongKe> BzThongKes { get; set; }

    public virtual DbSet<BzWare> BzWares { get; set; }

    public virtual DbSet<BzWareDate> BzWareDates { get; set; }

    public virtual DbSet<BzYahoo> BzYahoos { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<WareProduct> WareProducts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=103.238.215.248;Database=vinaofficedemo_db;Integrated Security=False;User ID= dev.vina;Password=Cl0ui5?71;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("vinaoffice");

        modelBuilder.Entity<AdminFunctionAdminGroupUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AdminFunction_AdminGroupUser", "dbo");

            entity.Property(e => e.FunctionName).HasMaxLength(255);
            entity.Property(e => e.GroupUser).HasMaxLength(255);
            entity.Property(e => e.SecurityCode).HasMaxLength(255);

            entity.HasOne(d => d.FunctionNameNavigation).WithMany()
                .HasForeignKey(d => d.FunctionName)
                .HasConstraintName("FK_AdminFunction_AdminGroupUser_bzAdminFunction");

            entity.HasOne(d => d.GroupUserNavigation).WithMany()
                .HasForeignKey(d => d.GroupUser)
                .HasConstraintName("FK_AdminFunction_AdminGroupUser_bzAdminUserGroup");
        });

        modelBuilder.Entity<BzAbout>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("bzAbout", "dbo");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ContentEn)
                .HasColumnType("ntext")
                .HasColumnName("ContentEN");
            entity.Property(e => e.ContentVn)
                .HasColumnType("ntext")
                .HasColumnName("ContentVN");
            entity.Property(e => e.DescriptionEn)
                .HasColumnType("ntext")
                .HasColumnName("DescriptionEN");
            entity.Property(e => e.DescriptionVn)
                .HasColumnType("ntext")
                .HasColumnName("DescriptionVN");
        });

        modelBuilder.Entity<BzAboutList>(entity =>
        {
            entity.HasKey(e => e.AboutId);

            entity.ToTable("bzAboutList", "dbo");

            entity.Property(e => e.AboutId).HasColumnName("AboutID");
            entity.Property(e => e.ContentEn)
                .HasColumnType("ntext")
                .HasColumnName("ContentEN");
            entity.Property(e => e.ContentVn)
                .HasColumnType("ntext")
                .HasColumnName("ContentVN");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleVn)
                .HasMaxLength(255)
                .HasColumnName("TitleVN");
            entity.Property(e => e.Upload).HasMaxLength(255);
        });

        modelBuilder.Entity<BzAd>(entity =>
        {
            entity.HasKey(e => e.AdsId).HasName("PK_Ads");

            entity.ToTable("bzAds", "dbo");

            entity.Property(e => e.AdsId).HasColumnName("AdsID");
            entity.Property(e => e.Banner).HasMaxLength(255);
            entity.Property(e => e.Company).HasColumnType("ntext");
            entity.Property(e => e.Domain).HasMaxLength(255);
            entity.Property(e => e.Footer).HasColumnType("ntext");
            entity.Property(e => e.Hotline).HasMaxLength(255);
            entity.Property(e => e.Logo).HasMaxLength(255);
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
            entity.Property(e => e.Product).HasColumnType("ntext");
            entity.Property(e => e.Time).HasMaxLength(255);
            entity.Property(e => e.Ware).HasMaxLength(255);
        });

        modelBuilder.Entity<BzAdminFunction>(entity =>
        {
            entity.HasKey(e => e.FunctionName);

            entity.ToTable("bzAdminFunction", "dbo");

            entity.Property(e => e.FunctionName).HasMaxLength(255);
            entity.Property(e => e.GroupName).HasMaxLength(255);
            entity.Property(e => e.TableName).HasMaxLength(255);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");

            entity.HasOne(d => d.GroupNameNavigation).WithMany(p => p.BzAdminFunctions)
                .HasForeignKey(d => d.GroupName)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_bzAdminFunction_bzAdminFunctionGroup");
        });

        modelBuilder.Entity<BzAdminFunctionGroup>(entity =>
        {
            entity.HasKey(e => e.GroupName);

            entity.ToTable("bzAdminFunctionGroup", "dbo");

            entity.Property(e => e.GroupName).HasMaxLength(255);
        });

        modelBuilder.Entity<BzAdminLang>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("bzAdminLang", "dbo");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.ValueEn)
                .HasMaxLength(255)
                .HasColumnName("ValueEN");
            entity.Property(e => e.ValueVn)
                .HasMaxLength(255)
                .HasColumnName("ValueVN");
        });

        modelBuilder.Entity<BzAdminUser>(entity =>
        {
            entity.HasKey(e => e.AdminUser);

            entity.ToTable("bzAdminUser", "dbo");

            entity.Property(e => e.AdminUser).HasMaxLength(255);
            entity.Property(e => e.AdminCreate).HasMaxLength(255);
            entity.Property(e => e.AdminEdit).HasMaxLength(255);
            entity.Property(e => e.AdminPassword).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.DateEdit).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GroupUser).HasMaxLength(255);
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.LoginId)
                .HasMaxLength(255)
                .HasColumnName("LoginID");
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.PassChange).HasMaxLength(255);

            entity.HasOne(d => d.GroupUserNavigation).WithMany(p => p.BzAdminUsers)
                .HasForeignKey(d => d.GroupUser)
                .HasConstraintName("FK_bzAdminUser_bzAdminUserGroup");
        });

        modelBuilder.Entity<BzAdminUserGroup>(entity =>
        {
            entity.HasKey(e => e.GroupUser);

            entity.ToTable("bzAdminUserGroup", "dbo");

            entity.Property(e => e.GroupUser).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(255);
        });

        modelBuilder.Entity<BzAdsSend>(entity =>
        {
            entity.HasKey(e => e.SendId).HasName("PK_AdsSend");

            entity.ToTable("bzAdsSend", "dbo");

            entity.Property(e => e.SendId).HasColumnName("SendID");
            entity.Property(e => e.Admin).HasMaxLength(255);
            entity.Property(e => e.AdsId).HasColumnName("AdsID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<BzBanner>(entity =>
        {
            entity.HasKey(e => e.BannerId).HasName("PK_vnBanner");

            entity.ToTable("bzBanner", "dbo");

            entity.Property(e => e.BannerId).HasColumnName("BannerID");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<BzContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("bzContact", "dbo");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.NameFull).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(255);
        });

        modelBuilder.Entity<BzKho>(entity =>
        {
            entity.ToTable("bzKho", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("NameVN");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<BzLang>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("bzLang", "dbo");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.ValueEn)
                .HasMaxLength(255)
                .HasColumnName("ValueEN");
            entity.Property(e => e.ValueVn)
                .HasMaxLength(255)
                .HasColumnName("ValueVN");
        });

        modelBuilder.Entity<BzList>(entity =>
        {
            entity.HasKey(e => e.ListId);

            entity.ToTable("bzList", "dbo");

            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.ActiveDate).HasColumnType("datetime");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.ContentEn)
                .HasColumnType("ntext")
                .HasColumnName("ContentEN");
            entity.Property(e => e.ContentVn)
                .HasColumnType("ntext")
                .HasColumnName("ContentVN");
            entity.Property(e => e.DesEn)
                .HasColumnType("ntext")
                .HasColumnName("DesEN");
            entity.Property(e => e.DesVn)
                .HasColumnType("ntext")
                .HasColumnName("DesVN");
            entity.Property(e => e.IsDes).HasColumnName("isDes");
            entity.Property(e => e.IsPicture).HasColumnName("isPicture");
            entity.Property(e => e.NoteEn)
                .HasMaxLength(255)
                .HasColumnName("NoteEN");
            entity.Property(e => e.NoteVn)
                .HasMaxLength(255)
                .HasColumnName("NoteVN");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.PicFull).HasMaxLength(255);
            entity.Property(e => e.PicThumb).HasMaxLength(255);
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleLink).HasMaxLength(255);
            entity.Property(e => e.TitleVn)
                .HasMaxLength(255)
                .HasColumnName("TitleVN");
        });

        modelBuilder.Entity<BzListPic>(entity =>
        {
            entity.HasKey(e => e.PicId);

            entity.ToTable("bzListPic", "dbo");

            entity.Property(e => e.PicId).HasColumnName("PicID");
            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PicFull).HasMaxLength(255);
            entity.Property(e => e.PicThumb).HasMaxLength(255);
        });

        modelBuilder.Entity<BzLog>(entity =>
        {
            entity.HasKey(e => e.Idlogin);

            entity.ToTable("bzLog", "dbo");

            entity.Property(e => e.Idlogin).HasColumnName("IDLogin");
            entity.Property(e => e.AdminUser).HasMaxLength(255);
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<BzMenu>(entity =>
        {
            entity.ToTable("bzMenu", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("NameVN");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<BzOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("bzOrder", "dbo");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Giaonhan).HasMaxLength(255);
            entity.Property(e => e.Mst)
                .HasMaxLength(255)
                .HasColumnName("MST");
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<BzOrderNew>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("bzOrderNew", "dbo");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
            entity.Property(e => e.Subject).HasColumnType("ntext");
        });

        modelBuilder.Entity<BzOrderNewProduct>(entity =>
        {
            entity.ToTable("bzOrderNew_Product", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
        });

        modelBuilder.Entity<BzOrderProduct>(entity =>
        {
            entity.ToTable("bzOrder_Product", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
        });

        modelBuilder.Entity<BzProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("bzProduct", "dbo");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.ContentEn)
                .HasColumnType("ntext")
                .HasColumnName("ContentEN");
            entity.Property(e => e.ContentVn)
                .HasColumnType("ntext")
                .HasColumnName("ContentVN");
            entity.Property(e => e.DesEn)
                .HasColumnType("ntext")
                .HasColumnName("DesEN");
            entity.Property(e => e.DesVn)
                .HasColumnType("ntext")
                .HasColumnName("DesVN");
            entity.Property(e => e.PicFull).HasMaxLength(255);
            entity.Property(e => e.PicThumb).HasMaxLength(255);
            entity.Property(e => e.Tags).HasMaxLength(255);
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleVn)
                .HasMaxLength(255)
                .HasColumnName("TitleVN");
        });

        modelBuilder.Entity<BzProductCate>(entity =>
        {
            entity.HasKey(e => e.CateId);

            entity.ToTable("bzProductCate", "dbo");

            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.DesEn)
                .HasColumnType("ntext")
                .HasColumnName("DesEN");
            entity.Property(e => e.DesVn)
                .HasColumnType("ntext")
                .HasColumnName("DesVN");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("NameVN");
        });

        modelBuilder.Entity<BzProductPicture>(entity =>
        {
            entity.HasKey(e => e.PictureId);

            entity.ToTable("bzProductPicture", "dbo");

            entity.Property(e => e.PictureId).HasColumnName("PictureID");
            entity.Property(e => e.PicFull).HasMaxLength(255);
            entity.Property(e => e.PicThumb).HasMaxLength(255);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
        });

        modelBuilder.Entity<BzProductPrice>(entity =>
        {
            entity.HasKey(e => new { e.SizeId, e.ProductId });

            entity.ToTable("bzProductPrice", "dbo");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.DesEn)
                .HasMaxLength(255)
                .HasColumnName("DesEN");
            entity.Property(e => e.DesVn)
                .HasMaxLength(255)
                .HasColumnName("DesVN");
        });

        modelBuilder.Entity<BzProductSize>(entity =>
        {
            entity.HasKey(e => e.SizeId);

            entity.ToTable("bzProductSize", "dbo");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.AddDate).HasMaxLength(255);
            entity.Property(e => e.AddUser).HasMaxLength(255);
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.DesEn)
                .HasColumnType("ntext")
                .HasColumnName("DesEN");
            entity.Property(e => e.DesVn)
                .HasColumnType("ntext")
                .HasColumnName("DesVN");
            entity.Property(e => e.Order).HasMaxLength(255);
            entity.Property(e => e.Photo).HasMaxLength(255);
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleVn)
                .HasMaxLength(255)
                .HasColumnName("TitleVN");
        });

        modelBuilder.Entity<BzSeo>(entity =>
        {
            entity.HasKey(e => e.Seoid);

            entity.ToTable("bzSEO", "dbo");

            entity.Property(e => e.Seoid).HasColumnName("SEOID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.DescriptionEn)
                .HasColumnType("ntext")
                .HasColumnName("DescriptionEN");
            entity.Property(e => e.DescriptionVn)
                .HasColumnType("ntext")
                .HasColumnName("DescriptionVN");
            entity.Property(e => e.KeywordsEn)
                .HasColumnType("ntext")
                .HasColumnName("KeywordsEN");
            entity.Property(e => e.KeywordsVn)
                .HasColumnType("ntext")
                .HasColumnName("KeywordsVN");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleVn)
                .HasMaxLength(255)
                .HasColumnName("TitleVN");
        });

        modelBuilder.Entity<BzSiteOption>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("bzSiteOption", "dbo");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.GroupOption).HasMaxLength(255);
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("NameVN");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.ValueNameEn)
                .HasMaxLength(511)
                .HasColumnName("ValueNameEN");
            entity.Property(e => e.ValueNameVn)
                .HasMaxLength(511)
                .HasColumnName("ValueNameVN");
            entity.Property(e => e.ValueOption).HasMaxLength(511);
            entity.Property(e => e.ValueSelect).HasColumnType("ntext");

            entity.HasOne(d => d.GroupOptionNavigation).WithMany(p => p.BzSiteOptions)
                .HasForeignKey(d => d.GroupOption)
                .HasConstraintName("FK_bzSiteOption_bzSiteOptionGroup");
        });

        modelBuilder.Entity<BzSiteOptionGroup>(entity =>
        {
            entity.HasKey(e => e.GroupOption);

            entity.ToTable("bzSiteOptionGroup", "dbo");

            entity.Property(e => e.GroupOption).HasMaxLength(255);
        });

        modelBuilder.Entity<BzSlide>(entity =>
        {
            entity.HasKey(e => e.SlideId);

            entity.ToTable("bzSlide", "dbo");

            entity.Property(e => e.SlideId).HasColumnName("SlideID");
            entity.Property(e => e.DesEn)
                .HasColumnType("ntext")
                .HasColumnName("DesEN");
            entity.Property(e => e.DesVn)
                .HasColumnType("ntext")
                .HasColumnName("DesVN");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleVn)
                .HasMaxLength(255)
                .HasColumnName("TitleVN");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<BzSupport>(entity =>
        {
            entity.HasKey(e => e.SupportId);

            entity.ToTable("bzSupport", "dbo");

            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Images).HasMaxLength(255);
            entity.Property(e => e.NameFull).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.Skype).HasMaxLength(255);
            entity.Property(e => e.Viber).HasMaxLength(255);
            entity.Property(e => e.Yahoo).HasMaxLength(255);
            entity.Property(e => e.Zalo).HasMaxLength(255);
        });

        modelBuilder.Entity<BzTag>(entity =>
        {
            entity.HasKey(e => e.TagsId);

            entity.ToTable("bzTags", "dbo");

            entity.Property(e => e.TagsId).HasColumnName("TagsID");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("NameVN");
        });

        modelBuilder.Entity<BzThongKe>(entity =>
        {
            entity.HasKey(e => e.OnlineId).HasName("PK__bzThongK__4AF3A22E59FA5E80");

            entity.ToTable("bzThongKe", "dbo");

            entity.Property(e => e.OnlineId).HasColumnName("OnlineID");
            entity.Property(e => e.Times).HasColumnType("datetime");
        });

        modelBuilder.Entity<BzWare>(entity =>
        {
            entity.HasKey(e => e.Phone);

            entity.ToTable("bzWare", "dbo");

            entity.Property(e => e.Phone).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.Ware).HasMaxLength(255);
        });

        modelBuilder.Entity<BzWareDate>(entity =>
        {
            entity.HasKey(e => e.WareId);

            entity.ToTable("bzWareDate", "dbo");

            entity.Property(e => e.WareId).HasColumnName("WareID");
            entity.Property(e => e.AddressDelivery).HasColumnType("ntext");
            entity.Property(e => e.DateCongno).HasColumnType("datetime");
            entity.Property(e => e.DateDelivery).HasColumnType("datetime");
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
            entity.Property(e => e.UserLast).HasMaxLength(255);
            entity.Property(e => e.Ware).HasMaxLength(255);
            entity.Property(e => e.WareDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<BzYahoo>(entity =>
        {
            entity.HasKey(e => e.YahooId);

            entity.ToTable("bzYahoo", "dbo");

            entity.Property(e => e.YahooId).HasColumnName("YahooID");
            entity.Property(e => e.DepartmentEn)
                .HasMaxLength(255)
                .HasColumnName("DepartmentEN");
            entity.Property(e => e.DepartmentVn)
                .HasMaxLength(255)
                .HasColumnName("DepartmentVN");
            entity.Property(e => e.NameFull).HasMaxLength(255);
            entity.Property(e => e.NickName).HasMaxLength(255);
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("Order_Product", "dbo");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.NameProduct).HasMaxLength(255);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<WareProduct>(entity =>
        {
            entity.HasKey(e => new { e.WareId, e.ProductId, e.Phone });

            entity.ToTable("Ware_Product", "dbo");

            entity.Property(e => e.WareId).HasColumnName("WareID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.PicFull).HasMaxLength(255);
            entity.Property(e => e.PicThumb).HasMaxLength(255);
            entity.Property(e => e.TitleVn)
                .HasMaxLength(255)
                .HasColumnName("TitleVN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
