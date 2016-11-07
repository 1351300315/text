namespace text
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    public class BlogDatabase : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“BlogDatabase”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“text.BlogDatabase”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“BlogDatabase”
        //连接字符串。
        public BlogDatabase()
            : base("name=BlogDatabase")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
         public virtual DbSet<BlogArticle> BlogArticles { get; set; }
 
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             var blogTable = modelBuilder.Entity<Blog>();
             var blogArtticleTable = modelBuilder.Entity<BlogArticle>();
 
             //blogTable.Property(o => o.Id).IsRequired();
             blogTable.HasKey(o => o.Id);
 
             //blogArtticleTable.Property(o => o.Id).IsRequired();
            blogArtticleTable.HasKey(o => o.Id);
 
 
            base.OnModelCreating(modelBuilder);
        }
     }

 
     /// <summary>
     /// 博客
    /// </summary>
 
    public class Blog
     {
         /// <summary>
         /// ID
         /// </summary>
         public int Id { get; set; }
 
         /// <summary>
         /// 博客
         /// </summary>
         public string Title { get; set; }
 
     }
 
     /// <summary>
     /// 博客文章
     /// </summary>
     public class BlogArticle
     {
         public int Id { get; set; }
 
         public int BlogId { get; set; }

        /// <summary>
        /// 标题
         [Required]
        [StringLength(maximumLength: 20, MinimumLength = 5)]
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        [Required]
        public string Body { get; set; }
 
         /// <summary>
         /// 创建时间
         /// </summary>
 
         public DateTime DateCreated { get; set; }
     }
 
 
 } 

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
