using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MatrixContent.Framework;

namespace MatrixContent.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MatrixContent.Blog.Models.Blog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<bool>("EnableComments");

                    b.Property<bool>("EnablePostRatings");

                    b.Property<bool>("ModerateComments");

                    b.Property<string>("Name");

                    b.Property<bool>("ShowNameInTitle");

                    b.Property<bool>("ShowRelatedPosts");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("IPAddress");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("PostID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<DateTime?>("DatePublished");

                    b.Property<bool>("EnableComments");

                    b.Property<bool>("HasSplash");

                    b.Property<bool?>("IsDeleted");

                    b.Property<bool>("IsPublic");

                    b.Property<bool>("IsPublished");

                    b.Property<int?>("Rating");

                    b.Property<int?>("ReadCount");

                    b.Property<string>("Slug");

                    b.Property<string>("SplashUrl");

                    b.Property<string>("Title");

                    b.Property<int>("UserID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.PostAccessInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AccessDate");

                    b.Property<string>("Client");

                    b.Property<string>("IPAddress");

                    b.Property<int>("PostID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.PostCategory", b =>
                {
                    b.Property<int>("PostID");

                    b.Property<int>("CategoryID");

                    b.HasKey("PostID", "CategoryID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.PostRating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IPAddress");

                    b.Property<int>("PostID");

                    b.Property<DateTime?>("RateDate");

                    b.Property<float>("Rating");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.PostTag", b =>
                {
                    b.Property<int>("PostID");

                    b.Property<int>("TagID");

                    b.HasKey("PostID", "TagID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("MatrixContent.Models.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<DateTime>("Brithday");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("IconPath");

                    b.Property<bool>("IsEmailPublic");

                    b.Property<bool>("IsPhonePublic");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State");

                    b.Property<string>("Title");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.Comment", b =>
                {
                    b.HasOne("MatrixContent.Blog.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.PostCategory", b =>
                {
                    b.HasOne("MatrixContent.Blog.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("MatrixContent.Blog.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostID");
                });

            modelBuilder.Entity("MatrixContent.Blog.Models.PostTag", b =>
                {
                    b.HasOne("MatrixContent.Blog.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.HasOne("MatrixContent.Blog.Models.Tag")
                        .WithMany()
                        .HasForeignKey("TagID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MatrixContent.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MatrixContent.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("MatrixContent.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
