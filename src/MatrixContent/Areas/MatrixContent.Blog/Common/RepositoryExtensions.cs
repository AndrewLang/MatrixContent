using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Blog.Models;
using MatrixContent.Framework;

namespace MatrixContent.Blog
{
    /// <summary>
    /// 
    /// </summary>
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Gets the entity count.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static int GetEntityCount<TEntity>(this IRepository repository) where TEntity : class, new()
        {
            return repository.GetQuery<TEntity>().Count();
        }
        /// <summary>
        /// Gets the public posts.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static IQueryable<Post> GetPublicPosts(this IRepository repository)
        {
            return repository.GetQuery<Post>().Where(x => x.IsPublic);
        }
        /// <summary>
        /// Gets the paged posts.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public static IPagedList<Post> GetPagedPosts(this IRepository repository,int page,int pageSize)
        {
            var posts = repository.GetPublicPosts()
                                  .OrderByDescending(x => x.DatePublished)
                                  .ToPagedList(page,pageSize);

            posts.TrucateContent();

            return posts;
        }
        /// <summary>
        /// Trucates the content.
        /// </summary>
        /// <param name="posts">The posts.</param>
        private static void TrucateContent(this IPagedList<Post> posts)
        {
            posts.Items.ForEach(x =>
            {
                x.Content = x.Content.StripHtml().Truncate(400);
                x.DateCreated = x.DateCreated.Value.Date;
            });
        }
        /// <summary>
        /// Gets the post by slug.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="slug">The slug.</param>
        /// <returns></returns>
        public static Post GetPostBySlug(this IRepository repository,string slug)
        {
            var post = repository.GetQuery<Post>().FirstOrDefault(x => x.Slug == slug);

            return post;
        }
        /// <summary>
        /// Gets the post by identifier.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Post GetPostById(this IRepository repository,int id)
        {
            return repository.GetQuery<Post>().FirstOrDefault(x => x.ID == id);
        }
        /// <summary>
        /// Searches the specified repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public static IPagedList<Post> Search(this IRepository repository,string keyword,int? page = 1,int? pageSize = Consts.DefaultPageSize)
        {
            string term = keyword.Trim();
            var posts = repository.GetPublicPosts()
                                  .Where(x => x.Title.Contains(term) || x.Content.Contains(term))
                                  .OrderByDescending(x => x.DatePublished)
                                  .ToPagedList(page ?? 1,pageSize ?? Consts.DefaultPageSize);

            posts.TrucateContent();
            return posts;
        }
        /// <summary>
        /// Gets the posts by category.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="page">The page.</param>
        /// <param name="pagesize">The pagesize.</param>
        /// <returns></returns>
        public static IPagedList<Post> GetPostsByCategory(this IRepository repository,int id,string name,int? page,int? pagesize)
        {

            var posts = repository.GetPublicPosts()
                                  .Where(x => x.ID > 40)
                                  .OrderByDescending(x => x.DatePublished)
                                  .ToPagedList(page ?? 1,pagesize ?? Consts.DefaultPageSize);
            posts.TrucateContent();
            return posts;
        }
        /// <summary>
        /// Gets the posts by tag.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The pagesize.</param>
        /// <returns></returns>
        public static IPagedList<Post> GetPostsByTag(this IRepository repository,int id,string name,int? page,int? pageSize)
        {
            var posts = repository.GetPublicPosts()
                                  .Where(x => x.ID > 50)
                                  .OrderByDescending(x => x.DatePublished)
                                  .ToPagedList(page ?? 1,pageSize ?? Consts.DefaultPageSize);
            posts.TrucateContent();
            return posts;
        }
        /// <summary>
        /// Gets the posts by year.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="year">The year.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public static IPagedList<Post> GetPostsByYear(this IRepository repository,int year,int? page,int? pageSize)
        {
            var posts = repository.GetPublicPosts()
                                 .Where(x => x.DateCreated.HasValue && x.DateCreated.Value.Year == year)
                                 .OrderByDescending(x => x.DatePublished)
                                 .ToPagedList(page ?? 1,pageSize ?? Consts.DefaultPageSize);
            posts.TrucateContent();
            return posts;
        }
        /// <summary>
        /// Categorieses the specified repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static IEnumerable<Category> Categories(this IRepository repository)
        {
            return repository.GetQuery<Category>().OrderBy(x => x.DateCreated);
        }
        public static Category GetCategoryById(this IRepository repository,int id)
        {
            return repository.GetQuery<Category>().FirstOrDefault(x => x.ID == id);
        }
        /// <summary>
        /// Gets the name of the category by.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Category GetCategoryByName(this IRepository repository,string name)
        {
            return repository.GetQuery<Category>().FirstOrDefault(x => x.Name == name);
        }
        /// <summary>
        /// Gets the archieve years.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static IEnumerable<object> GetArchieveYears(this IRepository repository)
        {
            return repository.GetQuery<Post>()
                             .Where(x => x.DateCreated != null)
                             .GroupBy(x => x.DateCreated.Value.Year)
                             .Select(x => new { Year = x.Key,Count = x.Count() });
        }
        /// <summary>
        /// Gets the links.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static IEnumerable<Link> GetLinks(this IRepository repository)
        {
            return repository.GetQuery<Link>()
                             .OrderBy(x => x.Order);

        }
        /// <summary>
        /// Gets the link by identifier.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Link GetLinkById(this IRepository repository,int id)
        {
            return repository.GetQuery<Link>().FirstOrDefault(x => x.ID == id);
        }
        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static IEnumerable<Tag> GetTags(this IRepository repository)
        {
            return repository.GetQuery<Tag>();
        }
        /// <summary>
        /// Gets the tag by identifier.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Tag GetTagById(this IRepository repository,int id)
        {
            return repository.GetQuery<Tag>().FirstOrDefault(x => x.ID == id);
        }
        /// <summary>
        /// Gets the name of the tag by.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Tag GetTagByName(this IRepository repository,string name)
        {
            return repository.GetQuery<Tag>().FirstOrDefault(x => x.Name == name);
        }
        
        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static IEnumerable<Comment> GetComments(this IRepository repository)
        {
            return repository.GetQuery<Comment>()
                             .Where(x => !x.IsDeleted)
                             .OrderByDescending(x => x.DateCreated);
        }
        /// <summary>
        /// Gets the comment by identifier.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Comment GetCommentById(this IRepository repository,int id)
        {
            return repository.GetQuery<Comment>().FirstOrDefault(x => x.ID == id);
        }
        /// <summary>
        /// Gets the post rating.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="postId">The post identifier.</param>
        /// <returns></returns>
        public static int GetPostRating(this IRepository repository,int postId)
        {
            return (int)repository.GetQuery<PostRating>()
                             .Where(x => x.PostID == postId)
                             .Sum(x => Convert.ToInt32(x.Rating));
        }        
    }
}
